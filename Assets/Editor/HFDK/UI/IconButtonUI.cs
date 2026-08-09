using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace BRDK2.UI
{
    public static class IconButtonUI
    {
        public static Button Create(string unityIcon, string text, Action callback)
        {
            Button button = new Button(callback);

            button.AddToClassList("sidebar-button");

            button.style.flexDirection = FlexDirection.Row;
            button.style.justifyContent = Justify.FlexStart;
            button.style.alignItems = Align.Center;

            var icon = EditorGUIUtility.IconContent(unityIcon);

            if (icon.image != null)
            {
                Image img = new Image();

                img.image = icon.image;

                img.style.width = 18;
                img.style.height = 18;

                img.style.marginRight = 8;

                button.Add(img);
            }

            Label label = new Label(text);

            label.style.unityTextAlign = TextAnchor.MiddleLeft;
            label.style.flexGrow = 1;

            button.Add(label);

            return button;
        }
    }
}