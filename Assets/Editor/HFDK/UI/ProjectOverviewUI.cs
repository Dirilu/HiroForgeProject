using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor;

namespace BRDK2.UI
{
    public static class ProjectOverviewUI
    {
        public static VisualElement Create()
        {
            VisualElement card = CardUI.Create("📋 Project Overview");

            AddRow(card, "Project", Application.productName);
            AddRow(card, "Unity", Application.unityVersion);
            AddRow(card, "Platform", EditorUserBuildSettings.activeBuildTarget.ToString());

            return card;
        }

        static void AddRow(VisualElement parent, string label, string value)
        {
            VisualElement row = new VisualElement();

            row.style.flexDirection = FlexDirection.Row;
            row.style.justifyContent = Justify.SpaceBetween;
            row.style.marginTop = 6;

            Label left = new Label(label);
            left.style.unityFontStyleAndWeight = FontStyle.Bold;

            Label right = new Label(value);

            row.Add(left);
            row.Add(right);

            parent.Add(row);
        }
    }
}