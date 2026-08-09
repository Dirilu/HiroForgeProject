using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

using BRDK2.DesignSystem;
using BRDK2.Models;
using BRDK2.Services;
using BRDK2.Theme;

namespace BRDK2.Widgets
{
    public static class HealthScoreWidget
    {
        public static VisualElement Create()
        {
            List<ScanResult> results =
                ProjectScannerService.Scan();

            int score =
                ProjectHealthCalculator.Calculate(results);

            VisualElement card =
                BRDKCard.Create(
                    "Project Health",
                    BRDKIcons.Heart);

            VisualElement content =
                BRDKCard.Content(card);

            //------------------------------------------
            // SCORE
            //------------------------------------------

            Label scoreLabel =
                new Label(score + "%");

            scoreLabel.style.fontSize = 48;
            scoreLabel.style.unityFontStyleAndWeight =
                FontStyle.Bold;

            scoreLabel.style.unityTextAlign =
                TextAnchor.MiddleCenter;

            scoreLabel.style.color =
                ProjectHealthCalculator.GetColor(score);

            content.Add(scoreLabel);

            //------------------------------------------
            // STATUS
            //------------------------------------------

            Label status =
                new Label(
                    ProjectHealthCalculator.GetStatus(score));

            status.style.fontSize = 16;
            status.style.unityTextAlign =
                TextAnchor.MiddleCenter;

            status.style.marginBottom = 15;

            status.style.color =
                BRDKTheme.SubText;

            content.Add(status);

            //------------------------------------------
            // PROGRESS BAR
            //------------------------------------------

            ProgressBar bar =
                new ProgressBar();

            bar.title = "";

            bar.value = score;

            bar.style.height = 22;

            bar.style.marginBottom = 15;

            content.Add(bar);

            //------------------------------------------
            // LAST SCAN
            //------------------------------------------

            Label scan =
                new Label(
                    "Last Scan\n" +
                    System.DateTime.Now.ToLongTimeString());

            scan.style.unityTextAlign =
                TextAnchor.MiddleCenter;

            scan.style.fontSize = 11;

            scan.style.color =
                BRDKTheme.SubText;

            content.Add(scan);

            return card;
        }
    }
}