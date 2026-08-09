using UnityEngine;
using UnityEngine.UIElements;

namespace BRDK2.UI
{
    public static class StatCardUI
    {
        public static VisualElement Create(string icon, string title, string value)
        {
            VisualElement card = CardUI.Create("");

            card.style.height = 150;

            // Icon
            Label iconLabel = new Label(icon);
            iconLabel.style.fontSize = 22;
            iconLabel.style.marginBottom = 6;

            card.Add(iconLabel);

            // Title
            Label titleLabel = new Label(title);
            titleLabel.AddToClassList("subtitle");

            titleLabel.style.marginBottom = 8;

            card.Add(titleLabel);

            // Value
            Label valueLabel = new Label(value);
            valueLabel.AddToClassList("stat-value");

            card.Add(valueLabel);

            return card;
        }
    }
}