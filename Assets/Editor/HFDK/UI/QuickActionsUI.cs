using UnityEngine;
using UnityEngine.UIElements;

using BRDK2.DesignSystem;

namespace BRDK2.UI
{
    public static class QuickActionsUI
    {
        public static VisualElement Create()
        {
            VisualElement panel = CardUI.Create("Quick Actions");

            panel.style.height = 290;

            panel.Add(CreateButton(
                BRDKIcons.Folder,
                "Create Folder Structure"));

            panel.Add(CreateButton(
                BRDKIcons.Film,
                "Create Scenes"));

            panel.Add(CreateButton(
                BRDKIcons.FileCode,
                "Create Scripts"));

            panel.Add(CreateButton(
                BRDKIcons.Check,
                "Verify Project"));

            panel.Add(CreateButton(
                BRDKIcons.Refresh,
                "Refresh Assets"));

            panel.Add(CreateButton(
                BRDKIcons.Folder,
                "Open Assets Folder"));

            return panel;
        }

        static VisualElement CreateButton(
            string icon,
            string text)
        {
            Button button = new Button();

            button.style.height = 42;
            button.style.marginBottom = 8;

            button.style.flexDirection = FlexDirection.Row;
            button.style.alignItems = Align.Center;
            button.style.justifyContent = Justify.FlexStart;

            button.style.paddingLeft = 12;
            button.style.paddingRight = 12;

            button.style.borderTopLeftRadius = 8;
            button.style.borderTopRightRadius = 8;
            button.style.borderBottomLeftRadius = 8;
            button.style.borderBottomRightRadius = 8;

            button.Add(BRDKIcon.Create(icon, 18));

            Label label = new Label(text);

            label.style.marginLeft = 10;
            label.style.flexGrow = 1;
            label.style.fontSize = 13;
            label.style.unityFontStyleAndWeight = FontStyle.Bold;

            button.Add(label);

            button.RegisterCallback<MouseEnterEvent>(_ =>
            {
                button.style.backgroundColor = new Color(.18f, .18f, .20f);
            });

            button.RegisterCallback<MouseLeaveEvent>(_ =>
            {
                button.style.backgroundColor = Color.clear;
            });

            return button;
        }
    }
}