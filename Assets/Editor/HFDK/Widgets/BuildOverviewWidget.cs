using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

using BRDK2.DesignSystem;
using BRDK2.Services;
using BRDK2.Theme;

namespace BRDK2.Widgets
{
    public static class BuildOverviewWidget
    {
        public static VisualElement Create()
        {
            VisualElement card =
                BRDKCard.Create(
                    "Build Overview",
                    BRDKIcons.Build);

            VisualElement content =
                BRDKCard.Content(card);

            List<BuildCheck> checks =
                BuildValidationService.Validate();

            int passed = 0;

            foreach (BuildCheck check in checks)
            {
                if (check.Passed)
                    passed++;
            }

            int score =
                Mathf.RoundToInt(
                    (float)passed /
                    checks.Count * 100f);

            //------------------------------------

            Label percent =
                new Label(score + "%");

            percent.style.fontSize = 46;
            percent.style.unityFontStyleAndWeight =
                FontStyle.Bold;

            percent.style.unityTextAlign =
                TextAnchor.MiddleCenter;

            percent.style.marginBottom = 10;

            percent.style.color =
                score >= 90
                    ? new Color(.3f,.85f,.4f)
                    : score >= 70
                        ? new Color(.95f,.75f,.2f)
                        : new Color(.95f,.3f,.3f);

            content.Add(percent);

            //------------------------------------

            ProgressBar bar =
                new ProgressBar();

            bar.title = "";

            bar.value = score;

            bar.style.height = 18;

            bar.style.marginBottom = 12;

            content.Add(bar);

            //------------------------------------

            Label status =
                new Label(
                    score >= 90
                        ? "Ready To Build"
                        : "Needs Attention");

            status.style.unityTextAlign =
                TextAnchor.MiddleCenter;

            status.style.fontSize = 14;

            status.style.color =
                BRDKTheme.SubText;

            content.Add(status);

            //------------------------------------

            Label last =
                new Label(
                    "Last Validation\n" +
                    System.DateTime.Now.ToLongTimeString());

            last.style.marginTop = 15;

            last.style.fontSize = 11;

            last.style.unityTextAlign =
                TextAnchor.MiddleCenter;

            last.style.color =
                BRDKTheme.SubText;

            content.Add(last);

            return card;
        }
    }
}