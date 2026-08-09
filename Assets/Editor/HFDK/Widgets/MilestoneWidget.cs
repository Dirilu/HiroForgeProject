using UnityEngine;
using UnityEngine.UIElements;
using BRDK2.UI;

namespace BRDK2.Widgets
{
    public static class MilestoneWidget
    {
        public static VisualElement Create()
        {
            VisualElement card = CardUI.Create("Current Milestone");

            card.Add(new Label("Current Sprint"));
            card.Add(new Label("Dashboard Polish"));

            card.Add(new Label(""));
            card.Add(new Label("Next"));
            card.Add(new Label("• Connect backend"));
            card.Add(new Label("• Add logo"));
            card.Add(new Label("• Custom icons"));

            return card;
        }
    }
}