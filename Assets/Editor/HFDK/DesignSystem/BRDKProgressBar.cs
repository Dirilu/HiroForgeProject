using UnityEngine;
using UnityEngine.UIElements;

namespace BRDK2.DesignSystem
{
    public static class BRDKProgressBar
    {
        public static VisualElement Create(
            float percent,
            float height = 10)
        {
            percent = Mathf.Clamp01(percent);

            VisualElement root = new VisualElement();

            root.style.height = height;
            root.style.flexGrow = 1;

            root.style.backgroundColor =
                new Color(.18f, .19f, .20f);

            root.style.borderTopLeftRadius = height / 2;
            root.style.borderTopRightRadius = height / 2;
            root.style.borderBottomLeftRadius = height / 2;
            root.style.borderBottomRightRadius = height / 2;

            //------------------------------------
            // Fill
            //------------------------------------

            VisualElement fill = new VisualElement();

            fill.style.width = Length.Percent(percent * 100);

            fill.style.height = height;

            fill.style.backgroundColor =
                new Color(.27f, .82f, .46f);

            fill.style.borderTopLeftRadius = height / 2;
            fill.style.borderTopRightRadius = height / 2;
            fill.style.borderBottomLeftRadius = height / 2;
            fill.style.borderBottomRightRadius = height / 2;

            root.Add(fill);

            return root;
        }
    }
}