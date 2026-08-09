using UnityEngine;
using UnityEngine.UIElements;

using BRDK2.UI;
using BRDK2.Services;
using BRDK2.DesignSystem;

namespace BRDK2.Widgets
{
    public static class ActivityWidget
    {
        public static VisualElement Create()
        {
            VisualElement card = CardUI.Create("Recent Activity");

            card.style.paddingTop = 14;

            if (ActivityService.Activities.Count == 0)
            {
                Label empty = new Label("No activity recorded yet.");

                empty.style.color = new Color(.70f, .70f, .70f);
                empty.style.marginTop = 10;

                card.Add(empty);

                return card;
            }

            int count = Mathf.Min(8, ActivityService.Activities.Count);

            for (int i = ActivityService.Activities.Count - 1;
                 i >= ActivityService.Activities.Count - count;
                 i--)
            {
                card.Add(CreateActivityRow(
                    ActivityService.Activities[i]));
            }

            return card;
        }

        static VisualElement CreateActivityRow(string text)
        {
            VisualElement row = new VisualElement();

            row.style.flexDirection = FlexDirection.Row;
            row.style.alignItems = Align.Center;

            row.style.marginTop = 8;
            row.style.marginBottom = 4;

            //------------------------------------------------
            // Icon
            //------------------------------------------------

            row.Add(
                BRDKIcon.Create(
                    BRDKIcons.Check,
                    16));

            //------------------------------------------------
            // Text
            //------------------------------------------------

            Label label = new Label(text);

            label.style.marginLeft = 10;
            label.style.flexGrow = 1;
            label.style.fontSize = 12;

            row.Add(label);

            //------------------------------------------------
            // Time
            //------------------------------------------------

            Label time = new Label("Now");

            time.style.fontSize = 11;
            time.style.color = new Color(.60f, .60f, .60f);

            row.Add(time);

            return row;
        }
    }
}