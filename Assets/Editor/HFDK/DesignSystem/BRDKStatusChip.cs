using UnityEngine;
using UnityEngine.UIElements;

namespace BRDK2.DesignSystem
{
    public enum BRDKStatus
    {
        Success,
        Warning,
        Error,
        Info
    }

    public static class BRDKStatusChip
    {
        public static VisualElement Create(
            string text,
            BRDKStatus status)
        {
            Color color = status switch
            {
                BRDKStatus.Success => new Color(.22f,.75f,.42f),
                BRDKStatus.Warning => new Color(.95f,.70f,.20f),
                BRDKStatus.Error   => new Color(.90f,.28f,.28f),
                _                  => new Color(.35f,.55f,.90f)
            };

            Label chip = new Label(text);

            chip.style.paddingLeft = 10;
            chip.style.paddingRight = 10;
            chip.style.paddingTop = 4;
            chip.style.paddingBottom = 4;

            chip.style.backgroundColor = color;

            chip.style.color = Color.white;

            chip.style.unityTextAlign = TextAnchor.MiddleCenter;

            chip.style.fontSize = 11;

            chip.style.unityFontStyleAndWeight =
                FontStyle.Bold;

            chip.style.borderTopLeftRadius = 100;
            chip.style.borderTopRightRadius = 100;
            chip.style.borderBottomLeftRadius = 100;
            chip.style.borderBottomRightRadius = 100;

            return chip;
        }
    }
}