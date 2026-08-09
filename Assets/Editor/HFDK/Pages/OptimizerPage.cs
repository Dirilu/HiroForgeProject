using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using BRDK2.Optimizers;

using BRDK2.DesignSystem;
using BRDK2.Models;
using BRDK2.Services;
using BRDK2.Theme;

namespace BRDK2.Pages
{
    public static class OptimizerPage
    {
        public static VisualElement Create()
        {
            VisualElement root = new VisualElement();

            root.style.flexGrow = 1;
            root.style.paddingLeft = 20;
            root.style.paddingRight = 20;
            root.style.paddingTop = 20;
            root.style.paddingBottom = 20;

            //---------------------------------------
            // Title
            //---------------------------------------

            Label title = new Label("Project Optimizer");

            title.style.fontSize = 28;
            title.style.unityFontStyleAndWeight =
                FontStyle.Bold;

            title.style.marginBottom = 6;

            root.Add(title);

            //---------------------------------------

            Label subtitle = new Label(
                "Find and fix common project issues.");

            subtitle.style.color =
                BRDKTheme.SubText;

            subtitle.style.marginBottom = 20;

            root.Add(subtitle);

            //---------------------------------------
            // Scan
            //---------------------------------------

            List<OptimizationTask> tasks =
                OptimizationService.Scan();

            int totalProblems = 0;

            foreach (OptimizationTask task in tasks)
                totalProblems += task.Count;

            //---------------------------------------
            // Overview Card
            //---------------------------------------

            VisualElement overview =
    BRDKCard.Create(
        "Optimization Overview",
        BRDKIcons.Search);

            VisualElement content =
                BRDKCard.Content(overview);

            Label problems =
                new Label("Problems Found: " + totalProblems);

            problems.style.fontSize = 22;
            problems.style.unityFontStyleAndWeight =
                FontStyle.Bold;

            content.Add(problems);

            Label estimate =
                new Label(
                    "Estimated Improvements\n" +
                    "• Cleaner Project\n" +
                    "• Faster Imports\n" +
                    "• Better Project Health");

            estimate.style.marginTop = 10;

            content.Add(estimate);

            Button fixAll = new Button();

            fixAll.text = "FIX EVERYTHING";

            fixAll.style.marginTop = 20;
            fixAll.style.height = 36;

            fixAll.clicked += () =>
            {
                EmptyFolderOptimizer.Fix();

                Debug.Log(
                    "[BRDK] Optimization Complete");
            };

            content.Add(fixAll);

            root.Add(overview);

            //---------------------------------------
            // Task Cards
            //---------------------------------------

            foreach (OptimizationTask task in tasks)
            {
                root.Add(CreateTask(task));
            }

            return root;
        }

        //------------------------------------------------

        static VisualElement CreateTask(
            OptimizationTask task)
        {
            VisualElement card =
                BRDKCard.Create(
                    task.Title,
                    BRDKIcons.Warning);

            VisualElement content =
                BRDKCard.Content(card);

            Label description =
                new Label(task.Description);

            description.style.marginBottom = 10;

            content.Add(description);

            Label count =
                new Label(
                    task.Count + " issue(s)");

            count.style.fontSize = 18;
            count.style.unityFontStyleAndWeight =
                FontStyle.Bold;

            content.Add(count);

            Button button =
                new Button();

            button.text = "Fix";

            button.style.marginTop = 12;

            button.clicked += () =>
            {
                switch (task.Title)
                {
                    case "Empty Folders":
                        EmptyFolderOptimizer.Fix();
                        break;

                    case "Large Textures":
                        LargeTextureOptimizer.Fix();
                        break;
                }
            };

            content.Add(button);

            return card;
        }
    }
}