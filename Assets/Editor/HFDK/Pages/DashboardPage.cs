using UnityEngine;
using UnityEngine.UIElements;

using BRDK2.Layout;
using BRDK2.Widgets;

namespace BRDK2.Pages
{
    public static class DashboardPage
    {
        public static VisualElement Create()
        {
            DashboardLayout layout = new DashboardLayout();

            //--------------------------------------------------
            // TOP HERO
            //--------------------------------------------------

            layout.Hero.Add(
                HeroWidget.Create());

            //--------------------------------------------------
            // METRICS
            //--------------------------------------------------

            layout.Stats.Add(
                StatsWidget.Create());

            //--------------------------------------------------
            // LEFT COLUMN
            //--------------------------------------------------

            layout.Health.Add(
                HealthScoreWidget.Create());

            layout.Health.Add(
                ProjectScannerWidget.Create());

            //--------------------------------------------------
            // CENTER COLUMN
            //--------------------------------------------------

            layout.Build.Add(
                BuildStatusWidget.Create());

            //--------------------------------------------------
            // RIGHT COLUMN
            //--------------------------------------------------

            layout.Console.Add(
                ActivityWidget.Create());

            layout.Tools.Add(
                CommandCenterWidget.Create());

            //--------------------------------------------------

            return layout.Root;
        }
    }
}