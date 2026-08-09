using UnityEngine;
using UnityEngine.UIElements;

using BRDK2.DesignSystem;
using BRDK2.Theme;

namespace BRDK2.Widgets
{
    public static class MetricCard
    {
        public static VisualElement Create(
            string icon,
            string value,
            string title,
            string subtitle = "")
        {
            // Create the card with no visible header.
            VisualElement card = BRDKCard.Create("", null);

            card.style.width = 210;
            card.style.minHeight = 170;

            VisualElement content = BRDKCard.Content(card);

            // Hide the default header and divider because
            // metric cards use their own layout.
            VisualElement header = card.Q<VisualElement>("Header");
            if (header != null)
                header.style.display = DisplayStyle.None;

            if (card.childCount > 1)
                card.ElementAt(1).style.display = DisplayStyle.None;

            content.style.justifyContent = Justify.Center;
            content.style.alignItems = Align.FlexStart;

            //--------------------------------------------------
            // Icon
            //--------------------------------------------------

            VisualElement iconElement = BRDKIcon.Create(icon, 28);

            iconElement.style.marginBottom = 16;

            content.Add(iconElement);

            //--------------------------------------------------
            // Value
            //--------------------------------------------------

            Label valueLabel = new Label(value);

            valueLabel.style.fontSize = 34;
            valueLabel.style.unityFontStyleAndWeight = FontStyle.Bold;
            valueLabel.style.color = BRDKTheme.Text;

            content.Add(valueLabel);

            //--------------------------------------------------
            // Title
            //--------------------------------------------------

            Label titleLabel = new Label(title);

            titleLabel.style.fontSize = 16;
            titleLabel.style.marginTop = 6;
            titleLabel.style.color = BRDKTheme.SubText;

            content.Add(titleLabel);

            //--------------------------------------------------
            // Subtitle
            //--------------------------------------------------

            if (!string.IsNullOrEmpty(subtitle))
            {
                Label subtitleLabel = new Label(subtitle);

                subtitleLabel.style.marginTop = 12;
                subtitleLabel.style.fontSize = 11;
                subtitleLabel.style.color = new Color(0.33f, 0.83f, 0.46f);

                content.Add(subtitleLabel);
            }

            return card;
        }
    }
}