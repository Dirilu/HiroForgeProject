using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

using BRDK2.DesignSystem;
using BRDK2.Services;
using BRDK2.Theme;

namespace BRDK2.UI
{
    public static class HeroBannerUI
    {
        public static VisualElement Create()
        {
            VisualElement root = new VisualElement();

            root.style.height = 180;
            root.style.marginBottom = 25;

            root.style.paddingLeft = 30;
            root.style.paddingRight = 30;
            root.style.paddingTop = 25;
            root.style.paddingBottom = 25;

            root.style.backgroundColor = BRDKTheme.Card;

            root.style.borderTopWidth = 4;
            root.style.borderTopColor = BRDKTheme.Gold;

            //-------------------------------------------------
            // Title
            //-------------------------------------------------

            Label title = new Label("Build Balut Royale Faster");

            title.style.fontSize = 28;
            title.style.unityFontStyleAndWeight = FontStyle.Bold;
            title.style.color = BRDKTheme.Text;

            root.Add(title);

            //-------------------------------------------------
            // Subtitle
            //-------------------------------------------------

            Label subtitle = new Label(
                "Generate your project, validate your setup, refresh your assets, and build your game from one central dashboard.");

            subtitle.style.fontSize = 14;
            subtitle.style.color = BRDKTheme.SubText;

            subtitle.style.marginTop = 8;
            subtitle.style.marginBottom = 22;

            root.Add(subtitle);

            //-------------------------------------------------
            // Buttons
            //-------------------------------------------------

            VisualElement buttonRow = new VisualElement();

            buttonRow.style.flexDirection = FlexDirection.Row;

            // Create Project
            buttonRow.Add(
                BRDKButton.Primary(
                    "Create Project",
                    () =>
                    {
                        ProjectActions.CreateCompleteProject();
                    }));

            // Validate Project
            buttonRow.Add(
                BRDKButton.Secondary(
                    "Validate Project",
                    () =>
                    {
                        EditorUtility.DisplayDialog(
                            "BRDK",
                            "Project Validator is coming in the next sprint.",
                            "OK");
                    }));

            // Build Project
            buttonRow.Add(
                BRDKButton.Secondary(
                    "Build Project",
                    () =>
                    {
                        EditorUtility.DisplayDialog(
                            "BRDK",
                            "Build Center is coming soon.",
                            "OK");
                    }));

            // Refresh
            buttonRow.Add(
                BRDKButton.Secondary(
                    "Refresh",
                    () =>
                    {
                        AssetDatabase.Refresh();

                        ActivityService.Log("Assets refreshed.");

                        EditorUtility.DisplayDialog(
                            "BRDK",
                            "Unity assets have been refreshed.",
                            "OK");
                    }));

            root.Add(buttonRow);

            return root;
        }
    }
}