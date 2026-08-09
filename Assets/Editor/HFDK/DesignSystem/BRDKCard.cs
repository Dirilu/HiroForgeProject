using UnityEngine;
using UnityEngine.UIElements;

using BRDK2.Theme;

namespace BRDK2.DesignSystem
{
    public static class BRDKCard
    {
        public static VisualElement Create(
            string title,
            string icon = null)
        {
            VisualElement card = new VisualElement();

            //--------------------------------------------------
            // Card
            //--------------------------------------------------

            card.style.marginBottom = 20;

            card.style.paddingLeft = 20;
            card.style.paddingRight = 20;
            card.style.paddingTop = 18;
            card.style.paddingBottom = 18;

            card.style.backgroundColor = BRDKTheme.Card;

            card.style.borderTopLeftRadius = 14;
            card.style.borderTopRightRadius = 14;
            card.style.borderBottomLeftRadius = 14;
            card.style.borderBottomRightRadius = 14;

            card.style.borderTopWidth = 1;
            card.style.borderBottomWidth = 1;
            card.style.borderLeftWidth = 1;
            card.style.borderRightWidth = 1;

            Color border = new Color(.27f,.28f,.30f);

            card.style.borderTopColor = border;
            card.style.borderBottomColor = border;
            card.style.borderLeftColor = border;
            card.style.borderRightColor = border;

            //--------------------------------------------------
            // Hover animation
            //--------------------------------------------------

            card.RegisterCallback<MouseEnterEvent>(_ =>
            {
                card.style.backgroundColor =
                    new Color(.18f,.19f,.21f);

                card.style.borderTopColor =
                    new Color(.90f,.74f,.29f);

                card.style.borderBottomColor =
                    new Color(.90f,.74f,.29f);

                card.style.borderLeftColor =
                    new Color(.90f,.74f,.29f);

                card.style.borderRightColor =
                    new Color(.90f,.74f,.29f);

                card.style.translate =
                    new Translate(0,-2);
            });

            card.RegisterCallback<MouseLeaveEvent>(_ =>
            {
                card.style.backgroundColor =
                    BRDKTheme.Card;

                card.style.borderTopColor = border;
                card.style.borderBottomColor = border;
                card.style.borderLeftColor = border;
                card.style.borderRightColor = border;

                card.style.translate =
                    new Translate(0,0);
            });

            //--------------------------------------------------
            // Header
            //--------------------------------------------------

            VisualElement header = new VisualElement();

            header.name = "Header";

            header.style.flexDirection = FlexDirection.Row;
            header.style.justifyContent = Justify.SpaceBetween;
            header.style.alignItems = Align.Center;

            //--------------------------------------------------

            VisualElement left = new VisualElement();

            left.style.flexDirection = FlexDirection.Row;
            left.style.alignItems = Align.Center;

            if (!string.IsNullOrEmpty(icon))
            {
                left.Add(BRDKIcon.Create(icon,20));
            }

            Label titleLabel = new Label(title);

            titleLabel.style.fontSize = 18;
            titleLabel.style.unityFontStyleAndWeight =
                FontStyle.Bold;

            titleLabel.style.marginLeft = 8;

            titleLabel.style.color =
                BRDKTheme.Text;

            left.Add(titleLabel);

            header.Add(left);

            //--------------------------------------------------
            // Status Chip (placeholder)
            //--------------------------------------------------

            Label chip = new Label("READY");

            chip.style.fontSize = 10;
            chip.style.unityFontStyleAndWeight =
                FontStyle.Bold;

            chip.style.paddingLeft = 8;
            chip.style.paddingRight = 8;
            chip.style.paddingTop = 3;
            chip.style.paddingBottom = 3;

            chip.style.backgroundColor =
                new Color(.20f,.45f,.24f);

            chip.style.color =
                Color.white;

            chip.style.borderTopLeftRadius = 8;
            chip.style.borderTopRightRadius = 8;
            chip.style.borderBottomLeftRadius = 8;
            chip.style.borderBottomRightRadius = 8;

            header.Add(chip);

            card.Add(header);

            //--------------------------------------------------
            // Divider
            //--------------------------------------------------

            VisualElement divider = new VisualElement();

            divider.style.height = 1;

            divider.style.marginTop = 14;
            divider.style.marginBottom = 18;

            divider.style.backgroundColor =
                new Color(.28f,.29f,.31f);

            card.Add(divider);

            //--------------------------------------------------
            // Content
            //--------------------------------------------------

            VisualElement content = new VisualElement();

            content.name = "Content";

            content.style.flexGrow = 1;

            card.Add(content);

            return card;
        }

        //------------------------------------------------------

        public static VisualElement Content(
            VisualElement card)
        {
            return card.Q<VisualElement>("Content");
        }
    }
}