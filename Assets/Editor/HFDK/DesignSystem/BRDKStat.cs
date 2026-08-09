using UnityEngine;
using UnityEngine.UIElements;

using BRDK2.Theme;

namespace BRDK2.DesignSystem
{
    public static class BRDKStat
    {
        public static VisualElement Create(
            string icon,
            string value,
            string title)
        {
            // Create card with no visible header
            VisualElement card = BRDKCard.Create("", null);

            card.style.minWidth = 180;
            card.style.height = 150;

            // Hide the default header and divider
            VisualElement header = card.Q<VisualElement>("Header");
            if (header != null)
                header.style.display = DisplayStyle.None;

            if (card.childCount > 1)
                card.ElementAt(1).style.display = DisplayStyle.None;

            VisualElement content = BRDKCard.Content(card);

            content.style.alignItems = Align.Center;
            content.style.justifyContent = Justify.Center;

            //-----------------------------------
            // Icon
            //-----------------------------------

            VisualElement iconElement =
                BRDKIcon.Create(icon, 34);

            iconElement.style.marginBottom = 12;

            content.Add(iconElement);

            //-----------------------------------
            // Value
            //-----------------------------------

            Label number = new Label(value);

            number.style.fontSize = 32;
            number.style.unityFontStyleAndWeight =
                FontStyle.Bold;

            number.style.color = BRDKTheme.Text;

            content.Add(number);

            //-----------------------------------
            // Title
            //-----------------------------------

            Label label = new Label(title);

            label.style.marginTop = 6;
            label.style.fontSize = 13;
            label.style.color = BRDKTheme.SubText;

            content.Add(label);

            return card;
        }
    }
}