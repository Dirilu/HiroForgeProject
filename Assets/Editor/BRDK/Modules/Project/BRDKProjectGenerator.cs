using BRDK.Core;
using UnityEditor;
using UnityEngine;
using System.IO;

namespace BRDK.Modules.Project
{
    public static class BRDKProjectGenerator
    {
        private const string Root = "Assets";

        [MenuItem("Tools/Balut Royale/Create Project Structure")]
        public static void CreateProjectStructure()
        {
            string[] folders =
            {
                "Animations",

                "Art",
                "Art/Backgrounds",
                "Art/Dice",
                "Art/Icons",
                "Art/Logos",
                "Art/Scorecard",
                "Art/Themes",
                "Art/UI",
                "Art/VFX",

                "Audio",
                "Audio/Ambient",
                "Audio/Music",
                "Audio/SFX",

                "Fonts",
                "Materials",
                "Models",

                "Prefabs",
                "Prefabs/Dice",
                "Prefabs/Gameplay",
                "Prefabs/Scorecard",
                "Prefabs/UI",
                "Prefabs/Effects",
                "Prefabs/Venues",

                "Resources",

                "Scenes",

                "ScriptableObjects",

                "Scripts",
                "Scripts/AI",
                "Scripts/Core",
                "Scripts/Dice",
                "Scripts/Gameplay",
                "Scripts/Online",
                "Scripts/Scorecard",
                "Scripts/Shop",
                "Scripts/UI",
                "Scripts/Utilities",

                "Settings",

                "StreamingAssets",

                "Text",
                "Text/Chronicle",
                "Text/Legends",
                "Text/Localization",
                "Text/Trivia",
                "Text/Tutorials"
            };

            int created = 0;

            foreach (string folder in folders)
            {
                string fullPath = Path.Combine(Root, folder);

                if (!AssetDatabase.IsValidFolder(fullPath))
                {
                    string parent = Path.GetDirectoryName(fullPath);
                    string name = Path.GetFileName(fullPath);

                    AssetDatabase.CreateFolder(parent, name);
                    created++;
                }
            }

            AssetDatabase.Refresh();
            BRDKActivityLog.Add($"Created {created} scene(s).");

            EditorUtility.DisplayDialog(
                "Balut Royale",
                $"Project structure created!\n\nFolders created: {created}",
                "Awesome!");
        }
    }
}