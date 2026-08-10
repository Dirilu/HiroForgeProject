using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

using BRDK2.DesignSystem;
using BRDK2.Layout;
using BRDK2.Services;
using BRDK2.Theme;
using BRDK2.Widgets;

namespace BRDK2.Pages
{
    public static class DashboardPage
    {
        public static VisualElement Create()
        {
            DashboardLayout layout = new DashboardLayout();

            layout.Hero.Add(HeroWidget.Create());
            layout.Stats.Add(StatsWidget.Create());
            layout.Health.Add(HealthScoreWidget.Create());
            layout.Health.Add(ProjectScannerWidget.Create());
            layout.Build.Add(BuildStatusWidget.Create());
            layout.Console.Add(CreateUnusedScriptsCard());
            layout.Tools.Add(CommandCenterWidget.Create());

            return layout.Root;
        }

        static VisualElement CreateUnusedScriptsCard()
        {
            VisualElement card = BRDKCard.Create(
                "Unused Scripts",
                BRDKIcons.FileCode);

            VisualElement content = BRDKCard.Content(card);

            // Run analysis for the dashboard list.
            HFDKAnalyzer.Analyze();

            Label summary = new Label(
                HFDKAnalyzer.unusedScripts.Count + " unused script(s)");

            summary.style.marginBottom = 10;
            summary.style.color = BRDKTheme.SubText;

            content.Add(summary);

            var scripts = HFDKAnalyzer.unusedScripts;

            if (scripts.Count == 0)
            {
                Label empty = new Label("No unused MonoBehaviour scripts found.");
                empty.style.color = BRDKTheme.SubText;
                content.Add(empty);
                return card;
            }

            int shown = Mathf.Min(8, scripts.Count);

            for (int i = 0; i < shown; i++)
            {
                var script = scripts[i];
                content.Add(CreateScriptRow(script.name, script.asset));
            }

            return card;
        }

        static VisualElement CreateScriptRow(string scriptName, Object asset)
        {
            VisualElement row = new VisualElement();

            row.style.flexDirection = FlexDirection.Row;
            row.style.justifyContent = Justify.SpaceBetween;
            row.style.alignItems = Align.Center;
            row.style.marginTop = 6;
            row.style.marginBottom = 4;

            Label name = new Label(scriptName ?? "Script");
            name.style.flexGrow = 1;
            name.style.color = BRDKTheme.Text;
            row.Add(name);

            Button ping = new Button(() =>
            {
                if (asset == null)
                    return;

                Selection.activeObject = asset;
                EditorGUIUtility.PingObject(asset);
            });

            ping.text = "Select";
            ping.style.height = 24;
            ping.style.minWidth = 70;

            row.Add(ping);

            return row;
        }
    }
}
