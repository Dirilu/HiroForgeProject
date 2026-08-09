using System;
using UnityEngine;
using UnityEngine.UIElements;

using BRDK2.Theme;

namespace BRDK2.DesignSystem
{
    public static class ActionTile
    {
        public static VisualElement Create(
            string icon,
            string title,
            string subtitle,
            Action action)
        {
            VisualElement tile = new VisualElement();

            tile.style.width = 190;
            tile.style.height = 145;

            tile.style.marginRight = 12;
            tile.style.marginBottom = 12;

            tile.style.paddingLeft = 18;
            tile.style.paddingRight = 18;
            tile.style.paddingTop = 18;
            tile.style.paddingBottom = 18;

            tile.style.backgroundColor = BRDKTheme.Card;

            tile.style.borderTopLeftRadius = 14;
            tile.style.borderTopRightRadius = 14;
            tile.style.borderBottomLeftRadius = 14;
            tile.style.borderBottomRightRadius = 14;

            tile.style.borderLeftWidth = 1;
            tile.style.borderRightWidth = 1;
            tile.style.borderTopWidth = 1;
            tile.style.borderBottomWidth = 1;

            Color border =
                new Color(.30f,.30f,.32f);

            tile.style.borderLeftColor = border;
            tile.style.borderRightColor = border;
            tile.style.borderTopColor = border;
            tile.style.borderBottomColor = border;

            //------------------------------------------

            VisualElement iconElement =
                BRDKIcon.Create(icon,32);

            iconElement.style.marginBottom = 12;

            tile.Add(iconElement);

            //------------------------------------------

            Label titleLabel =
                new Label(title);

            titleLabel.style.fontSize = 16;

            titleLabel.style.unityFontStyleAndWeight =
                FontStyle.Bold;

            titleLabel.style.color =
                BRDKTheme.Text;

            tile.Add(titleLabel);

            //------------------------------------------

            Label sub =
                new Label(subtitle);

            sub.style.marginTop = 6;

            sub.style.fontSize = 11;

            sub.style.color =
                BRDKTheme.SubText;

            tile.Add(sub);

            //------------------------------------------

            tile.RegisterCallback<MouseEnterEvent>(_ =>
            {
                tile.style.backgroundColor =
                    new Color(.24f,.24f,.26f);

                tile.style.translate =
                    new Translate(0,-2);
            });

            tile.RegisterCallback<MouseLeaveEvent>(_ =>
            {
                tile.style.backgroundColor =
                    BRDKTheme.Card;

                tile.style.translate =
                    new Translate(0,0);
            });

            tile.RegisterCallback<ClickEvent>(_ =>
            {
                action?.Invoke();
            });

            return tile;
        }
    }
}