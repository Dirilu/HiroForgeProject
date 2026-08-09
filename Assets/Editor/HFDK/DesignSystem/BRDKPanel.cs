using UnityEngine;
using UnityEngine.UIElements;
using BRDK2.Theme;

namespace BRDK2.DesignSystem
{
    public static class BRDKPanel
    {
        public static VisualElement Create(string title)
        {
            VisualElement panel = new VisualElement();

            panel.style.flexGrow = 1;

            panel.style.paddingLeft = 20;
            panel.style.paddingRight = 20;
            panel.style.paddingTop = 18;
            panel.style.paddingBottom = 18;

            panel.style.backgroundColor = BRDKTheme.Card;

            Color border = new Color(.28f,.28f,.30f);

            panel.style.borderTopWidth = 1;
            panel.style.borderBottomWidth = 1;
            panel.style.borderLeftWidth = 1;
            panel.style.borderRightWidth = 1;

            panel.style.borderTopColor = border;
            panel.style.borderBottomColor = border;
            panel.style.borderLeftColor = border;
            panel.style.borderRightColor = border;

            Label header = new Label(title);

            header.style.fontSize = 16;
            header.style.unityFontStyleAndWeight =
                FontStyle.Bold;

            header.style.marginBottom = 14;

            panel.Add(header);

            return panel;
        }
    }
}