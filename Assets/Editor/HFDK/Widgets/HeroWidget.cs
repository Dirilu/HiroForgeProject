using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

using BRDK2.DesignSystem;
using BRDK2.Services;
using BRDK2.Theme;

namespace BRDK2.Widgets
{
    public static class HeroWidget
    {
        public static VisualElement Create()
        {
            //------------------------------------------------
            // Card
            //------------------------------------------------

            VisualElement card = BRDKCard.Create(
                "Project Overview",
                BRDKIcons.Dashboard);

            card.style.flexGrow = 1;
            card.style.marginBottom = 20;

            // Hide BRDKCard default header because
            // HeroWidget has its own custom header.
            VisualElement defaultHeader =
                card.Q<VisualElement>("Header");

            if (defaultHeader != null)
                defaultHeader.style.display =
                    DisplayStyle.None;

            // Hide divider
            if (card.childCount > 1)
                card.ElementAt(1).style.display =
                    DisplayStyle.None;

            // Use BRDKCard content container
            VisualElement content =
                BRDKCard.Content(card);

            content.style.paddingLeft = 30;
            content.style.paddingRight = 30;
            content.style.paddingTop = 26;
            content.style.paddingBottom = 26;

            //------------------------------------------------
            // Hero Header
            //------------------------------------------------

            VisualElement header = new VisualElement();

            header.style.flexDirection =
                FlexDirection.Row;

            header.style.justifyContent =
                Justify.SpaceBetween;

            header.style.alignItems =
                Align.Center;

            //------------------------------------------------
            // Left
            //------------------------------------------------

            VisualElement left = new VisualElement();

            left.style.flexGrow = 1;

            Label title =
                new Label("Build Balut Royale");

            title.style.fontSize = 30;
            title.style.unityFontStyleAndWeight =
                FontStyle.Bold;

            title.style.color =
                BRDKTheme.Text;

            left.Add(title);

            Label subtitle =
                new Label(
                    "Everything you need to build and maintain your project in one place.");

            subtitle.style.marginTop = 6;
            subtitle.style.fontSize = 13;
            subtitle.style.color =
                BRDKTheme.SubText;

            left.Add(subtitle);

            header.Add(left);

            //------------------------------------------------
            // Status
            //------------------------------------------------

            VisualElement status =
                new VisualElement();

            status.style.flexDirection =
                FlexDirection.Row;

            status.style.alignItems =
                Align.Center;

            status.Add(
                BRDKIcon.Create(
                    BRDKIcons.Check,
                    18));

            Label healthy =
                new Label("Project Healthy");

            healthy.style.marginLeft = 8;
            healthy.style.color =
                BRDKTheme.Gold;

            healthy.style.fontSize = 13;

            healthy.style.unityFontStyleAndWeight =
                FontStyle.Bold;

            status.Add(healthy);

            header.Add(status);

            content.Add(header);

            //------------------------------------------------
            // Buttons
            //------------------------------------------------

            VisualElement buttons =
                new VisualElement();

            buttons.style.flexDirection =
                FlexDirection.Row;

            buttons.style.marginTop = 24;

            buttons.Add(
                BRDKButton.Primary(
                    "Create Project",
                    () =>
                    {
                        ProjectActions.CreateCompleteProject();
                    }));

            buttons.Add(
                BRDKButton.Secondary(
                    "Validate",
                    () =>
                    {
                        EditorUtility.DisplayDialog(
                            "BRDK",
                            "Project validation coming soon.",
                            "OK");
                    }));

            buttons.Add(
                BRDKButton.Secondary(
                    "Build",
                    () =>
                    {
                        EditorUtility.DisplayDialog(
                            "BRDK",
                            "Build Center coming soon.",
                            "OK");
                    }));

            content.Add(buttons);

            return card;
        }
    }
}