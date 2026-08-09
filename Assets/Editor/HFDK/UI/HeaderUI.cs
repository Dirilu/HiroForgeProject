using UnityEngine;
using UnityEngine.UIElements;
using BRDK2.Theme;

namespace BRDK2.UI
{
    public static class HeaderUI
    {
        public static VisualElement Create()
        {
            VisualElement header = new VisualElement();

            header.style.height = 90;
            header.style.backgroundColor = BRDKTheme.Sidebar;

            header.style.flexDirection = FlexDirection.Row;

            header.style.alignItems = Align.Center;

            header.style.paddingLeft = 20;
            header.style.paddingRight = 20;

            // Left side
            VisualElement left = new VisualElement();

            left.style.flexGrow = 1;

            Label logo = new Label("BRDK");

            logo.style.fontSize = 30;
            logo.style.unityFontStyleAndWeight = FontStyle.Bold;
            logo.style.color = BRDKTheme.Gold;

            left.Add(logo);

            Label subtitle = new Label("Balut Royale Development Kit");

            subtitle.style.color = BRDKTheme.SubText;
            subtitle.style.fontSize = 13;

            left.Add(subtitle);

            header.Add(left);

            // Right side
            VisualElement right = new VisualElement();

            right.style.alignItems = Align.FlexEnd;

            Label version = new Label("Version 2.0 Alpha");

            version.style.color = BRDKTheme.SubText;

            right.Add(version);

            Label unity = new Label(Application.unityVersion);

            unity.style.color = BRDKTheme.Text;

            right.Add(unity);

            header.Add(right);

            return header;
        }
    }
}