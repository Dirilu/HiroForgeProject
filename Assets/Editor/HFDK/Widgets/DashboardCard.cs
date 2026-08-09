using UnityEngine;
using UnityEngine.UIElements;
using BRDK2.Theme;

namespace BRDK2.DesignSystem
{
    public static class DashboardCard
    {
        public static VisualElement Create(
            string title,
            string value,
            string description)
        {
            VisualElement card = new VisualElement();

            //-------------------------------------------------
            // Card
            //-------------------------------------------------

            card.style.flexGrow = 1;
            card.style.minHeight = 180;

            card.style.marginRight = 14;
            card.style.marginBottom = 14;

            card.style.paddingLeft = 22;
            card.style.paddingRight = 22;
            card.style.paddingTop = 18;
            card.style.paddingBottom = 18;

            card.style.backgroundColor = BRDKTheme.Card;

            card.style.borderTopWidth = 1;
            card.style.borderBottomWidth = 1;
            card.style.borderLeftWidth = 1;
            card.style.borderRightWidth = 1;

            Color border = new Color(.28f,.28f,.30f);

            card.style.borderTopColor = border;
            card.style.borderBottomColor = border;
            card.style.borderLeftColor = border;
            card.style.borderRightColor = border;

            //-------------------------------------------------
            // Gold Accent
            //-------------------------------------------------

            VisualElement accent = new VisualElement();

            accent.style.position = Position.Absolute;

            accent.style.left = 0;
            accent.style.top = 0;
            accent.style.bottom = 0;

            accent.style.width = 4;

            accent.style.backgroundColor = BRDKTheme.Gold;

            card.Add(accent);

            //-------------------------------------------------
            // Title
            //-------------------------------------------------

            Label header = new Label(title);

            header.style.fontSize = 13;
            header.style.color = BRDKTheme.SubText;
            header.style.unityFontStyleAndWeight =
                FontStyle.Bold;

            card.Add(header);

            //-------------------------------------------------
            // Value
            //-------------------------------------------------

            Label mainValue = new Label(value);

            mainValue.style.marginTop = 18;

            mainValue.style.fontSize = 38;

            mainValue.style.color = BRDKTheme.Text;

            mainValue.style.unityFontStyleAndWeight =
                FontStyle.Bold;

            card.Add(mainValue);

            //-------------------------------------------------
            // Spacer
            //-------------------------------------------------

            VisualElement spacer = new VisualElement();

            spacer.style.flexGrow = 1;

            card.Add(spacer);

            //-------------------------------------------------
            // Footer
            //-------------------------------------------------

            VisualElement footer = new VisualElement();

            footer.style.height = 26;

            footer.style.justifyContent = Justify.Center;

            footer.style.borderTopWidth = 1;
            footer.style.borderTopColor = border;

            footer.style.paddingTop = 6;

            Label descriptionLabel = new Label(description);

            descriptionLabel.style.fontSize = 11;
            descriptionLabel.style.color = BRDKTheme.SubText;

            footer.Add(descriptionLabel);

            card.Add(footer);

            return card;
        }
    }
}