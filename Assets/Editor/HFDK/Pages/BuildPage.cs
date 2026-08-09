using UnityEngine.UIElements;

using BRDK2.Layout;
using BRDK2.Widgets;

namespace BRDK2.Pages
{
    public static class BuildPage
    {
        public static VisualElement Create()
        {
            DashboardLayout layout = new DashboardLayout();

            layout.Hero.Add(BuildOverviewWidget.Create());

            layout.Health.Add(BuildChecksWidget.Create());

            return layout.Root;
        }
    }
}