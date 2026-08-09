using UnityEngine;
using UnityEngine.UIElements;
using BRDK2.Theme;

namespace BRDK2.DesignSystem
{
    public static class BRDKBadge
    {
        public static VisualElement Create(
            string text,
            Color color)
        {
            var badge = new Label(text);

            badge.style.backgroundColor = color;

            badge.style.color = Color.white;

            badge.style.paddingLeft = 10;
            badge.style.paddingRight = 10;
            badge.style.paddingTop = 4;
            badge.style.paddingBottom = 4;

            badge.style.borderTopLeftRadius = 8;
            badge.style.borderTopRightRadius = 8;
            badge.style.borderBottomLeftRadius = 8;
            badge.style.borderBottomRightRadius = 8;

            badge.style.fontSize = 12;
            badge.style.unityFontStyleAndWeight =
                FontStyle.Bold;

            return badge;
        }

        public static VisualElement Healthy()
        {
            return Create("Healthy", new Color(.15f,.55f,.20f));
        }

        public static VisualElement Warning()
        {
            return Create("Warning", new Color(.75f,.55f,.10f));
        }

        public static VisualElement Error()
        {
            return Create("Error", new Color(.70f,.18f,.18f));
        }
    }
}