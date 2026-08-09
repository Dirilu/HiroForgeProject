using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

using BRDK2.DesignSystem;
using BRDK2.Services;

namespace BRDK2.Widgets
{
    public static class HealthWidget
    {
        public static VisualElement Create()
        {
            VisualElement card = DashboardCard.Create(
                "Project Health",
                ProjectHealthService.HealthPercent() + "%",
                "Overall Status");

            card.style.paddingTop = 14;

            AddStatus(card, "Scenes",
                ProjectHealthService.HasScenes(),
                "Assets/Scenes");

            AddStatus(card, "Scripts",
                ProjectHealthService.HasScripts(),
                "Assets/Scripts");

            AddStatus(card, "Resources",
                ProjectHealthService.HasResources(),
                "Assets/Resources");

            AddStatus(card, "Materials",
                ProjectHealthService.HasMaterials(),
                "Assets/Materials");

            AddStatus(card, "Prefabs",
                ProjectHealthService.HasPrefabs(),
                "Assets/Prefabs");

            AddStatus(card, "Settings",
                ProjectHealthService.HasSettings(),
                "Assets/Settings");

            AddStatus(card, "Addressables",
                ProjectHealthService.HasAddressables(),
                "Assets/AddressableAssetsData");

            return card;
        }

        static void AddStatus(
            VisualElement parent,
            string title,
            bool ok,
            string folder)
        {
            VisualElement row = new VisualElement();

            row.style.flexDirection = FlexDirection.Row;
            row.style.alignItems = Align.Center;

            row.style.justifyContent = Justify.SpaceBetween;

            row.style.marginTop = 8;
            row.style.paddingBottom = 4;

            //------------------------------------------------
            // LEFT
            //------------------------------------------------

            VisualElement left = new VisualElement();

            left.style.flexDirection = FlexDirection.Row;
            left.style.alignItems = Align.Center;
            left.style.flexGrow = 1;

            left.Add(
                BRDKIcon.Create(
                    ok
                        ? BRDKIcons.Check
                        : BRDKIcons.Warning,
                    16));

            Label label = new Label(title);

            label.style.marginLeft = 10;
            label.style.flexGrow = 1;
            label.style.fontSize = 13;

            left.Add(label);

            row.Add(left);

            //------------------------------------------------
            // RIGHT
            //------------------------------------------------

            if (ok)
            {
                Label status = new Label("Healthy");

                status.style.color =
                    new Color(.35f, .85f, .45f);

                status.style.unityFontStyleAndWeight =
                    FontStyle.Bold;

                row.Add(status);
            }
            else
            {
                Button fix = new Button();

                fix.text = "Fix";

                fix.style.height = 24;
                fix.style.minWidth = 60;

                fix.clicked += () =>
                {
                    ProjectFixService.CreateFolder(folder);

                    ActivityService.Log(
                        title + " repaired.");
                };

                row.Add(fix);
            }

            parent.Add(row);
        }
    }
}