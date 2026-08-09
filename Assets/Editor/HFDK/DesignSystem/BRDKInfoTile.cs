using UnityEngine;
using UnityEngine.UIElements;
using BRDK2.Theme;

namespace BRDK2.DesignSystem
{
    public static class BRDKInfoTile
    {
        public static VisualElement Create(string value, string title)
        {
            var tile = new VisualElement();

            tile.style.width = 140;
            tile.style.height = 70;

            tile.style.marginRight = 12;

            tile.style.paddingLeft = 14;
            tile.style.paddingTop = 12;

            tile.style.backgroundColor =
                new Color(.17f,.17f,.19f);

            tile.style.borderTopLeftRadius = 10;
            tile.style.borderTopRightRadius = 10;
            tile.style.borderBottomLeftRadius = 10;
            tile.style.borderBottomRightRadius = 10;

            Label valueLabel = new Label(value);

            valueLabel.style.fontSize = 16;
            valueLabel.style.unityFontStyleAndWeight =
                FontStyle.Bold;

            valueLabel.style.color = Color.white;

            tile.Add(valueLabel);

            Label titleLabel = new Label(title);

            titleLabel.style.marginTop = 4;
            titleLabel.style.fontSize = 11;
            titleLabel.style.color = BRDKTheme.SubText;

            tile.Add(titleLabel);

            return tile;
        }
    }
}