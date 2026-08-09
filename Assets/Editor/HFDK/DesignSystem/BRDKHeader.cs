using UnityEngine;
using UnityEngine.UIElements;
using BRDK2.Theme;

namespace BRDK2.DesignSystem
{
    public static class BRDKHeader
    {
        public static VisualElement Create()
        {
            VisualElement header = new VisualElement();

            header.style.height = 90;
            header.style.flexDirection = FlexDirection.Row;
            header.style.alignItems = Align.Center;
            header.style.justifyContent = Justify.SpaceBetween;

            header.style.paddingLeft = 30;
            header.style.paddingRight = 30;

            header.style.backgroundColor = BRDKTheme.Sidebar;

            //-------------------------------------------------
            // LEFT SIDE
            //-------------------------------------------------

            VisualElement left = new VisualElement();

            left.style.flexDirection = FlexDirection.Row;
            left.style.alignItems = Align.Center;
            left.style.flexGrow = 1;

            // Logo
            left.Add(BRDKLogo.Create(52));

            // Text
            VisualElement textColumn = new VisualElement();

            textColumn.style.marginLeft = 16;

            Label title = new Label("BRDK Studio");

            title.style.fontSize = 26;
            title.style.unityFontStyleAndWeight = FontStyle.Bold;
            title.style.color = BRDKTheme.Text;

            textColumn.Add(title);

            Label subtitle = new Label("Balut Royale Development Kit");

            subtitle.style.fontSize = 13;
            subtitle.style.color = BRDKTheme.SubText;

            textColumn.Add(subtitle);

            left.Add(textColumn);

            //-------------------------------------------------
            // RIGHT SIDE
            //-------------------------------------------------

            VisualElement right = new VisualElement();

            right.style.alignItems = Align.FlexEnd;

            Label unity = new Label("Unity " + Application.unityVersion);

            unity.style.color = BRDKTheme.Text;
            unity.style.fontSize = 13;

            right.Add(unity);

            Label version = new Label("v2.0 Alpha");

version.style.color = Color.black;

version.style.backgroundColor = BRDKTheme.Gold;

version.style.paddingLeft = 10;
version.style.paddingRight = 10;
version.style.paddingTop = 3;
version.style.paddingBottom = 3;

version.style.unityFontStyleAndWeight = FontStyle.Bold;

version.style.marginTop = 6;

            version.style.paddingLeft = 10;
            version.style.paddingRight = 10;
            version.style.paddingTop = 4;
            version.style.paddingBottom = 4;

            version.style.marginTop = 6;

            version.style.unityFontStyleAndWeight = FontStyle.Bold;

            right.Add(version);

            //-------------------------------------------------
            // Assemble
            //-------------------------------------------------

            header.Add(left);
            header.Add(right);

            //-------------------------------------------------
            // Bottom Gold Divider
            //-------------------------------------------------

            VisualElement divider = new VisualElement();

            divider.style.position = Position.Absolute;

            divider.style.left = 0;
            divider.style.right = 0;
            divider.style.bottom = 0;

            divider.style.height = 2;
            divider.style.backgroundColor = BRDKTheme.Gold;

            header.Add(divider);

            return header;
        }
    }
}