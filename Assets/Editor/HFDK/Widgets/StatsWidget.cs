using UnityEngine;
using UnityEngine.UIElements;

using BRDK2.DesignSystem;
using BRDK2.Services;

namespace BRDK2.Widgets
{
    public static class StatsWidget
    {
        public static VisualElement Create()
        {
            VisualElement root = new VisualElement();

            root.style.flexDirection = FlexDirection.Row;
            root.style.justifyContent = Justify.SpaceBetween;
            root.style.flexGrow = 1;
            root.style.marginBottom = 18;

            root.Add(
                MetricCard.Create(
                    BRDKIcons.Film,
                    StatisticsService.SceneCount().ToString(),
                    "Scenes",
                    "Project Scenes"));

            root.Add(
                MetricCard.Create(
                    BRDKIcons.FileCode,
                    StatisticsService.ScriptCount().ToString(),
                    "Scripts",
                    "C# Scripts"));

            root.Add(
                MetricCard.Create(
                    BRDKIcons.Box,
                    StatisticsService.PrefabCount().ToString(),
                    "Prefabs",
                    "Game Prefabs"));

            root.Add(
                MetricCard.Create(
                    BRDKIcons.Palette,
                    StatisticsService.MaterialCount().ToString(),
                    "Materials",
                    "Project Materials"));

            return root;
        }
    }
}