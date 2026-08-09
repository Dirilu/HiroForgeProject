using UnityEngine;
using UnityEngine.UIElements;

using BRDK2.DesignSystem;

namespace BRDK2.Widgets
{
    public static class BuildStatusWidget
    {
        public static VisualElement Create()
        {
            VisualElement card = DashboardCard.Create(
                "Build Status",
                "Ready",
                "Current Build");

            card.style.paddingTop = 14;

            AddItem(card, BRDKIcons.Play,    "Platform",      "Windows");
            AddItem(card, BRDKIcons.Hammer,  "Configuration", "Development");
            AddItem(card, BRDKIcons.Tag,     "Version",       "0.1.0");
            AddItem(card, BRDKIcons.Clock,   "Last Build",    "Never");

            return card;
        }

        static void AddItem(
            VisualElement parent,
            string icon,
            string label,
            string value)
        {
            VisualElement row = new VisualElement();

            row.style.flexDirection = FlexDirection.Row;
            row.style.alignItems = Align.Center;
            row.style.justifyContent = Justify.SpaceBetween;

            row.style.marginTop = 8;
            row.style.paddingBottom = 4;

            //------------------------------------------------
            // LEFT
            //------------------------------------------------

            VisualElement left = new VisualElement();

            left.style.flexDirection = FlexDirection.Row;
            left.style.alignItems = Align.Center;
            left.style.flexGrow = 1;

            left.Add(BRDKIcon.Create(icon, 16));

            Label title = new Label(label);

            title.style.marginLeft = 10;
            title.style.fontSize = 13;
            title.style.flexGrow = 1;

            left.Add(title);

            row.Add(left);

            //------------------------------------------------
            // RIGHT
            //------------------------------------------------

            Label right = new Label(value);

            right.style.unityFontStyleAndWeight =
                FontStyle.Bold;

            right.style.color = Color.white;

            row.Add(right);

            parent.Add(row);
        }
    }
}