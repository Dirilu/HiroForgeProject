using UnityEngine;
using UnityEngine.UIElements;

namespace BRDK2.UI
{
    public static class FooterUI
    {
        public static VisualElement Create()
        {
            VisualElement footer = new VisualElement();

            footer.style.height = 28;
            footer.style.backgroundColor = new Color(.10f, .10f, .10f);
            footer.style.justifyContent = Justify.Center;

            Label label = new Label(
                "Unity 6.5 | BRDK v2.0 | Ready");

            label.style.color = Color.white;

            footer.Add(label);

            return footer;
        }
    }
}