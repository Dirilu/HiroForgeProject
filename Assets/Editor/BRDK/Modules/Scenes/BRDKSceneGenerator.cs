using BRDK.Core;
using System.IO;
using UnityEditor;
using UnityEditor.SceneManagement;

namespace BRDK.Modules.Scenes
{
    public static class BRDKSceneGenerator
    {
        private static readonly string[] SceneNames =
        {
            "Boot",
            "Loading",
            "MainMenu",
            "SoloGame",
            "OnlineGame",
            "Shop",
            "Collection",
            "Chronicle",
            "Tutorial",
            "Leaderboards",
            "Settings"
        };

        [MenuItem("Tools/Balut Royale/Create Scenes")]
        public static void CreateScenes()
        {
            const string sceneFolder = "Assets/Scenes";

            if (!AssetDatabase.IsValidFolder(sceneFolder))
            {
                AssetDatabase.CreateFolder("Assets", "Scenes");
            }

            int created = 0;

            foreach (string sceneName in SceneNames)
            {
                string scenePath = $"{sceneFolder}/{sceneName}.unity";

                if (File.Exists(scenePath))
                    continue;

                var scene = EditorSceneManager.NewScene(
                    NewSceneSetup.DefaultGameObjects,
                    NewSceneMode.Single);

                EditorSceneManager.SaveScene(scene, scenePath);

                created++;
            }

            AssetDatabase.Refresh();
            BRDKActivityLog.Add($"Created {created} scene(s).");
            EditorUtility.DisplayDialog(
                "BRDK",
                $"Created {created} scene(s).",
                "OK");
        }
    }
}