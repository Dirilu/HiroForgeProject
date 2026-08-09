using UnityEditor;
using UnityEngine;

using BRDK.UI;
using BRDK.Validators;

namespace BRDK.Core
{
    public static class BRDKDashboard
    {
        public static void Draw()
        {
            BRDKHeader.Draw(BRDKVersion.Version);

            GUILayout.Space(10);

            GUILayout.BeginHorizontal();

            DrawLeftColumn();

            GUILayout.Space(8);

            DrawRightColumn();

            GUILayout.EndHorizontal();
        }

        private static void DrawLeftColumn()
        {
            GUILayout.BeginVertical();

            DrawQuickStart();

            GUILayout.Space(8);

            DrawProgress();

            GUILayout.EndVertical();
        }

        private static void DrawRightColumn()
        {
            GUILayout.BeginVertical();

            DrawHealth();

            GUILayout.Space(8);

            DrawActivity();

            GUILayout.EndVertical();
        }

        private static void DrawQuickStart()
        {
            BRDKPane.Begin();

            GUILayout.Label("🚀 QUICK START", BRDKStyles.Section);

            GUILayout.Space(5);

            if (BRDKPrimaryButton.Draw("CREATE COMPLETE PROJECT"))
            {
                BRDK.Modules.Project.BRDKProjectBuilder.CreateCompleteProject();
            }

            GUILayout.Space(5);

            if (GUILayout.Button("📁 Create Folder Structure"))
                BRDK.Modules.Project.BRDKProjectGenerator.CreateProjectStructure();

            if (GUILayout.Button("🎬 Create Scenes"))
                BRDK.Modules.Scenes.BRDKSceneGenerator.CreateScenes();

            if (GUILayout.Button("📜 Create Scripts"))
                BRDK.Modules.Scripts.BRDKScriptGenerator.CreateScripts();

            BRDKPane.End();
        }

        private static void DrawHealth()
        {
            BRDKPane.Begin();

            GUILayout.Label("📊 PROJECT HEALTH", BRDKStyles.Section);

            BRDKStatusRow.Draw(
                "Folder Structure",
                BRDKProjectValidator.ProjectStructureIsValid());

            BRDKStatusRow.Draw(
                "Scenes",
                AssetDatabase.IsValidFolder("Assets/Scenes"));

            BRDKStatusRow.Draw(
                "Scripts",
                AssetDatabase.IsValidFolder("Assets/Scripts"));

            BRDKStatusRow.Draw(
                "Scorecard",
                AssetDatabase.IsValidFolder("Assets/Scripts/Scorecard"));

            BRDKStatusRow.Draw(
                "Dice",
                AssetDatabase.IsValidFolder("Assets/Scripts/Dice"));

            BRDKStatusRow.Draw(
                "Online",
                AssetDatabase.IsValidFolder("Assets/Scripts/Online"));

            BRDKPane.End();
        }

        private static void DrawProgress()
        {
            BRDKPane.Begin();

            GUILayout.Label("📈 PROJECT PROGRESS", BRDKStyles.Section);

            float progress = CalculateProgress();

            Rect rect = GUILayoutUtility.GetRect(250, 22);

            EditorGUI.ProgressBar(
                rect,
                progress,
                Mathf.RoundToInt(progress * 100) + "% Complete");

            GUILayout.Space(20);

            BRDKPane.End();
        }

        private static void DrawActivity()
        {
            BRDKPane.Begin();

            GUILayout.Label("📜 RECENT ACTIVITY", BRDKStyles.Section);

            if (BRDKActivityLog.Entries.Count == 0)
            {
                GUILayout.Label("No activity yet.");
            }
            else
            {
                foreach (string entry in BRDKActivityLog.Entries)
                {
                    GUILayout.Label("• " + entry);
                }
            }

            BRDKPane.End();
        }

        private static float CalculateProgress()
        {
            int completed = 0;
            int total = 6;

            if (BRDKProjectValidator.ProjectStructureIsValid())
                completed++;

            if (AssetDatabase.IsValidFolder("Assets/Scenes"))
                completed++;

            if (AssetDatabase.IsValidFolder("Assets/Scripts"))
                completed++;

            if (AssetDatabase.IsValidFolder("Assets/Scripts/Scorecard"))
                completed++;

            if (AssetDatabase.IsValidFolder("Assets/Scripts/Dice"))
                completed++;

            if (AssetDatabase.IsValidFolder("Assets/Scripts/Online"))
                completed++;

            return completed / (float)total;
        }
    }
}