using UnityEngine;
using UnityEngine.UIElements;

namespace BRDK2.DesignSystem
{
    public static class BRDKMetricCard
    {
        public static VisualElement Create(
            string icon,
            string value,
            string title,
            string subtitle)
        {
            VisualElement card = new VisualElement();

            card.style.flexGrow = 1;
            card.style.height = 120;

            card.style.marginRight = 12;

            card.style.paddingLeft = 18;
            card.style.paddingRight = 18;
            card.style.paddingTop = 16;
            card.style.paddingBottom = 16;

            card.style.backgroundColor = new Color(0.18f, 0.18f, 0.20f);

            card.style.borderLeftWidth = 3;
            card.style.borderLeftColor = new Color(1f, 0.78f, 0.20f);

            card.style.borderTopWidth = 1;
            card.style.borderBottomWidth = 1;
            card.style.borderRightWidth = 1;

            card.style.borderTopColor = new Color(.25f,.25f,.25f);
            card.style.borderBottomColor = new Color(.25f,.25f,.25f);
            card.style.borderRightColor = new Color(.25f,.25f,.25f);

            //------------------------------------------------

            VisualElement header = new VisualElement();

            header.style.flexDirection = FlexDirection.Row;
            header.style.justifyContent = Justify.SpaceBetween;
            header.style.alignItems = Align.Center;

            //------------------------------------------------

            VisualElement iconHolder = new VisualElement();

            iconHolder.style.width = 28;
            iconHolder.style.height = 28;

            // We'll insert the Lucide icon here later.
            iconHolder.Add(new Label(icon));

            //------------------------------------------------

            Label valueLabel = new Label(value);

            valueLabel.style.fontSize = 22;
            valueLabel.style.unityFontStyleAndWeight = FontStyle.Bold;
            valueLabel.style.color = Color.white;

            //------------------------------------------------

            header.Add(iconHolder);
            header.Add(valueLabel);

            //------------------------------------------------

            Label titleLabel = new Label(title);

            titleLabel.style.marginTop = 12;
            titleLabel.style.fontSize = 14;
            titleLabel.style.color = Color.white;

            //------------------------------------------------

            Label subtitleLabel = new Label(subtitle);

            subtitleLabel.style.fontSize = 11;
            subtitleLabel.style.color = new Color(.65f,.65f,.65f);

            //------------------------------------------------

            card.Add(header);
            card.Add(titleLabel);
            card.Add(subtitleLabel);

            return card;
        }
    }
}