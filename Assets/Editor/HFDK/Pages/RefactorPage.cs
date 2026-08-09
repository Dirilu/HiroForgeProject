using BRDK2.Widgets;

using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

using BRDK2.DesignSystem;
using BRDK2.Models;
using BRDK2.Services;

namespace BRDK2.Pages
{
    public static class RefactorPage
    {
        static TextField findField;
        static TextField replaceField;

        static ScrollView resultsView;

        public static VisualElement Create()
        {
            VisualElement root = new VisualElement();

            root.style.flexGrow = 1;
            root.style.paddingLeft = 20;
            root.style.paddingRight = 20;
            root.style.paddingTop = 20;
            root.style.paddingBottom = 20;

            //-----------------------------------
            // Title
            //-----------------------------------

            Label title = new Label("Refactor Center");

            title.style.fontSize = 28;
            title.style.unityFontStyleAndWeight =
                FontStyle.Bold;

            root.Add(title);

            //-----------------------------------
            // Find
            //-----------------------------------

            findField = new TextField("Find");

            findField.value = "BRDK";

            root.Add(findField);

            //-----------------------------------
            // Replace
            //-----------------------------------

            replaceField = new TextField("Replace");

            replaceField.value = "HFDK";

            root.Add(replaceField);

            //-----------------------------------
            // Scan Button
            //-----------------------------------

            Button scanButton = new Button(Scan);

            scanButton.text = "Preview Changes";

            scanButton.style.marginTop = 15;

            root.Add(scanButton);

            //-----------------------------------
            // Results
            //-----------------------------------

            resultsView = new ScrollView();

            resultsView.style.flexGrow = 1;
            resultsView.style.marginTop = 20;

            root.Add(resultsView);

            return root;
        }

        static void Scan()
        {
            resultsView.Clear();

            List<RefactorItem> items =
                RefactorScanner.Scan(
                    Application.dataPath,
                    findField.value,
                    replaceField.value);

            resultsView.Add(
    RefactorResultsWidget.Create(items));

            resultsView.Add(new Label(
                $"{items.Count} replacement(s) found."));
        }

        
        
           
    }
}