using UnityEditor;
using UnityEngine;

using BRDK.Modules.Project;
using BRDK.Modules.Scenes;
using BRDK.Modules.Scripts;
using BRDK.Validators;
using BRDK.UI;

namespace BRDK.Core
{
    public class BRDKWindow : EditorWindow
    {
        private bool _projectExpanded = true;
        private bool _gameplayExpanded = false;
        private bool _contentExpanded = false;
        private bool _buildExpanded = false;

        [MenuItem("Tools/Balut Royale/Development Kit")]
        public static void Open()
        {
            GetWindow<BRDKWindow>("BRDK");
        }

        private void OnGUI()
        {
            DrawHeader();

            BRDKDashboard.Draw();

            GUILayout.Space(10);

            // PROJECT
            _projectExpanded =
                BRDKFoldout.Draw("📁 Project Tools", _projectExpanded);

            if (_projectExpanded)
                DrawProjectSection();

            BRDKFoldout.End();

            GUILayout.Space(5);

            // GAMEPLAY
            _gameplayExpanded =
                BRDKFoldout.Draw("🎮 Gameplay Tools", _gameplayExpanded);

            if (_gameplayExpanded)
                DrawGameplaySection();

            BRDKFoldout.End();

            GUILayout.Space(5);

            // CONTENT
            _contentExpanded =
                BRDKFoldout.Draw("🎨 Content Tools", _contentExpanded);

            if (_contentExpanded)
                DrawContentSection();

            BRDKFoldout.End();

            GUILayout.Space(5);

            // BUILD
            _buildExpanded =
                BRDKFoldout.Draw("📦 Build Tools", _buildExpanded);

            if (_buildExpanded)
                DrawBuildSection();

            BRDKFoldout.End();
        }

        private void DrawHeader()
        {
            GUILayout.Label(BRDKVersion.Name, BRDKStyles.Title);

            GUILayout.Label(
                "Version " + BRDKVersion.Version,
                EditorStyles.centeredGreyMiniLabel);

            GUILayout.Space(5);
        }

        private void DrawProjectSection()
        {
            if (GUILayout.Button("🚀 Create Complete Balut Royale Project", GUILayout.Height(35)))
            {
                BRDKProjectBuilder.CreateCompleteProject();
            }

            GUILayout.Space(5);

            if (GUILayout.Button("📁 Create Folder Structure"))
            {
                BRDKProjectGenerator.CreateProjectStructure();
            }

            if (GUILayout.Button("🎬 Create Scenes"))
            {
                BRDKSceneGenerator.CreateScenes();
            }

            if (GUILayout.Button("📜 Create Scripts"))
            {
                BRDKScriptGenerator.CreateScripts();
            }

            if (GUILayout.Button("✔ Verify Project"))
            {
                bool valid = BRDKProjectValidator.ProjectStructureIsValid();

                EditorUtility.DisplayDialog(
                    "Project Verification",
                    valid
                        ? "✅ Project structure looks good!"
                        : "❌ One or more required folders are missing.",
                    "OK");
            }
        }

        private void DrawGameplaySection()
        {
            GUILayout.Button("🎲 Create Scorecard");
            GUILayout.Button("🎲 Create Dice");
            GUILayout.Button("🤖 Create AI");
        }

        private void DrawContentSection()
        {
            GUILayout.Button("🏡 Create Venue");
            GUILayout.Button("🎲 Create Dice Set");
            GUILayout.Button("🛒 Create Shop Item");
        }

        private void DrawBuildSection()
        {
            GUILayout.Button("📱 Build Android");
            GUILayout.Button("🍎 Build iOS");
        }
    }
}