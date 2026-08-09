using System;
using UnityEngine;
using UnityEngine.UIElements;

using BRDK2.Theme;
using BRDK2.DesignSystem;

namespace BRDK2.UI
{
    public static class BRDKNavigationItem
    {
        public static VisualElement Create(
            string title,
            string icon,
            bool selected,
            Action onClick)
        {
            Button button = new Button(onClick);

            // Size
            button.style.height = 52;

            // Margin
            button.style.marginLeft = 12;
            button.style.marginRight = 12;
            button.style.marginTop = 6;
            button.style.marginBottom = 6;

            // Padding
            button.style.paddingLeft = 18;
            button.style.paddingRight = 18;

            // Layout
            button.style.flexDirection = FlexDirection.Row;
            button.style.alignItems = Align.Center;
            button.style.justifyContent = Justify.FlexStart;

            // Rounded corners
            button.style.borderTopLeftRadius = 12;
            button.style.borderTopRightRadius = 12;
            button.style.borderBottomLeftRadius = 12;
            button.style.borderBottomRightRadius = 12;

            // Selected indicator
            button.style.borderLeftWidth = selected ? 4 : 0;
            button.style.borderLeftColor = BRDKTheme.Gold;

            // Background
            button.style.backgroundColor =
                selected
                ? new Color(0.20f, 0.20f, 0.22f)
                : Color.clear;

            //--------------------------------------------------
            // Icon
            //--------------------------------------------------

            VisualElement iconElement = BRDKIcon.Create(icon, 30);

            iconElement.style.marginRight = 16;

            button.Add(iconElement);

            //--------------------------------------------------
            // Label
            //--------------------------------------------------

            Label label = new Label(title);

            label.style.flexGrow = 1;
            label.style.fontSize = 15;
            label.style.unityFontStyleAndWeight = FontStyle.Bold;

            label.style.color =
                selected
                ? BRDKTheme.Gold
                : Color.white;

            button.Add(label);

            //--------------------------------------------------
            // Hover
            //--------------------------------------------------

            button.RegisterCallback<MouseEnterEvent>(_ =>
            {
                if (!selected)
                {
                    button.style.backgroundColor =
                        new Color(0.17f, 0.17f, 0.19f);
                }
            });

            button.RegisterCallback<MouseLeaveEvent>(_ =>
            {
                if (!selected)
                {
                    button.style.backgroundColor = Color.clear;
                }
            });

            return button;
        }
    }
}