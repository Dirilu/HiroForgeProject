using UnityEngine;
using UnityEngine.UIElements;

namespace BRDK2.UI
{
    public static class DashboardSectionUI
    {
        public static VisualElement Create(string title)
        {
            VisualElement section = new VisualElement();

            section.style.flexGrow = 1;
            section.style.marginBottom = 20;

            Label label = new Label(title);

            label.style.fontSize = 20;
            label.style.unityFontStyleAndWeight = FontStyle.Bold;
            label.style.marginBottom = 10;

            section.Add(label);

            return section;
        }
    }
}