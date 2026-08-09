using System;
using UnityEngine;
using UnityEngine.UIElements;
using BRDK2.Theme;

namespace BRDK2.DesignSystem
{
    public static class BRDKButton
    {
        public static Button Primary(string text, Action onClick)
        {
            Button button = new Button();

            button.text = text;

            button.clicked += onClick;

            button.style.height = 42;
            button.style.minWidth = 150;

            button.style.marginRight = 10;

            button.style.backgroundColor = BRDKTheme.Gold;

            button.style.color = Color.black;

            button.style.unityFontStyleAndWeight =
                FontStyle.Bold;

            button.style.fontSize = 13;

            button.style.borderTopLeftRadius = 8;
            button.style.borderTopRightRadius = 8;
            button.style.borderBottomLeftRadius = 8;
            button.style.borderBottomRightRadius = 8;

            button.style.paddingLeft = 20;
            button.style.paddingRight = 20;

            //------------------------------------------------
            // Hover
            //------------------------------------------------

            button.RegisterCallback<MouseEnterEvent>(_ =>
            {
                button.style.backgroundColor =
                    new Color(1f, .84f, .25f);
            });

            button.RegisterCallback<MouseLeaveEvent>(_ =>
            {
                button.style.backgroundColor =
                    BRDKTheme.Gold;
            });

            return button;
        }

        //--------------------------------------------------

        public static Button Secondary(string text, Action onClick)
        {
            Button button = new Button();

            button.text = text;

            button.clicked += onClick;

            button.style.height = 42;
            button.style.minWidth = 150;

            button.style.marginRight = 10;

            button.style.backgroundColor =
                new Color(.25f,.25f,.27f);

            button.style.color = Color.white;

            button.style.unityFontStyleAndWeight =
                FontStyle.Bold;

            button.style.fontSize = 13;

            button.style.borderTopLeftRadius = 8;
            button.style.borderTopRightRadius = 8;
            button.style.borderBottomLeftRadius = 8;
            button.style.borderBottomRightRadius = 8;

            button.style.paddingLeft = 20;
            button.style.paddingRight = 20;

            button.RegisterCallback<MouseEnterEvent>(_ =>
            {
                button.style.backgroundColor =
                    new Color(.33f,.33f,.35f);
            });

            button.RegisterCallback<MouseLeaveEvent>(_ =>
            {
                button.style.backgroundColor =
                    new Color(.25f,.25f,.27f);
            });

            return button;
        }
    }
}