using UnityEngine;
using UnityEngine.UIElements;

using BRDK2.UI;

namespace BRDK2.Widgets
{
    public static class BottomWidgets
    {
        public static VisualElement Create()
        {
            VisualElement root = new VisualElement();

            root.style.flexGrow = 1;
            root.style.flexDirection = FlexDirection.Column;

            //-------------------------------------------------
            // TOP ROW
            //-------------------------------------------------

            VisualElement top = new VisualElement();

            top.style.flexDirection = FlexDirection.Row;
            top.style.flexGrow = 1;
            top.style.marginBottom = 16;

            

            VisualElement health = HealthWidget.Create();
            VisualElement activity = ActivityWidget.Create();

            health.style.flexGrow = 1;
            activity.style.flexGrow = 1;

            health.style.marginRight = 8;
            activity.style.marginLeft = 8;

            top.Add(health);
            top.Add(activity);

            root.Add(top);

            //-------------------------------------------------
            // BOTTOM ROW
            //-------------------------------------------------

            VisualElement bottom = new VisualElement();

            bottom.style.flexDirection = FlexDirection.Row;
            bottom.style.flexGrow = 1;

            VisualElement build = BuildStatusWidget.Create();
            VisualElement tools = QuickActionsUI.Create();

            build.style.flexGrow = 1;
            tools.style.flexGrow = 1;

            build.style.marginRight = 8;
            tools.style.marginLeft = 8;

            bottom.Add(build);
            bottom.Add(tools);

            root.Add(bottom);

            return root;
        }
    }
}