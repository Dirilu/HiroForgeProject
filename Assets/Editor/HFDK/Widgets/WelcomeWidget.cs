using UnityEngine;
using UnityEngine.UIElements;
using BRDK2.DesignSystem;
using BRDK2.Services;
using BRDK2.Theme;

namespace BRDK2.Widgets
{
    public static class WelcomeWidget
    {
        public static VisualElement Create()
        {
            VisualElement card = new VisualElement();

            card.style.backgroundColor = BRDKTheme.Card;
            card.style.paddingLeft = 24;
            card.style.paddingRight = 24;
            card.style.paddingTop = 20;
            card.style.paddingBottom = 20;

            card.style.marginBottom = 20;

            Label title = new Label("Welcome back.");

            title.style.fontSize = 28;
            title.style.unityFontStyleAndWeight = FontStyle.Bold;
            title.style.color = BRDKTheme.Text;

            card.Add(title);

            Label subtitle = new Label(
                "Everything is ready to continue building Balut Royale.");

            subtitle.style.marginTop = 6;
            subtitle.style.marginBottom = 20;
            subtitle.style.color = BRDKTheme.SubText;

            card.Add(subtitle);

            VisualElement buttons = new VisualElement();

            buttons.style.flexDirection = FlexDirection.Row;

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
                        Debug.Log("Validate");
                    }));

            buttons.Add(
                BRDKButton.Secondary(
                    "Build",
                    () =>
                    {
                        Debug.Log("Build");
                    }));

            card.Add(buttons);

            return card;
        }
    }
}