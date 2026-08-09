using UnityEngine.UIElements;

namespace BRDK2.Layout
{
    public static class DashboardGrid
    {
        public static VisualElement Create()
        {
            var root = new VisualElement();

            root.style.flexGrow = 1;
            root.style.paddingLeft = 28;
            root.style.paddingRight = 28;
            root.style.paddingTop = 24;
            root.style.paddingBottom = 24;

            return root;
        }

        public static VisualElement Row()
        {
            var row = new VisualElement();

            row.style.flexDirection = FlexDirection.Row;
            row.style.marginBottom = 20;

            return row;
        }

        public static VisualElement Row(float height)
        {
            var row = Row();
            row.style.height = height;
            return row;
        }

        public static VisualElement Column(float flexGrow = 1f)
        {
            var column = new VisualElement();

            column.style.flexGrow = flexGrow;
            column.style.marginRight = 20;

            return column;
        }
    }
}