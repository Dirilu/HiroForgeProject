using UnityEngine;
using UnityEngine.UIElements;

namespace BRDK2.UI
{
    public static class CardUI
    {
        public static VisualElement Create(string title)
        {
            VisualElement card = new VisualElement();

            // Apply USS class
            card.AddToClassList("card");

            // Keep a few layout styles in code
            card.style.flexGrow = 1;
            card.style.height = 180;

            Label heading = new Label(title);

            // Apply USS class
            heading.AddToClassList("card-title");

            card.Add(heading);

            return card;
        }
    }
}