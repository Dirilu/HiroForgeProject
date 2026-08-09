using UnityEditor;
using BRDK.Modules.Project;
using BRDK.Modules.Scenes;
using BRDK.Modules.Scripts;

namespace BRDK2.Services
{
    public static class ProjectActions
    {
        public static void CreateCompleteProject()
        {
            AssetDatabase.StartAssetEditing();

            try
            {
                // Create project folders
                BRDKProjectGenerator.CreateProjectStructure();

                // Create default scenes
                BRDKSceneGenerator.CreateScenes();

                // Generate scripts
                BRDKScriptGenerator.CreateScripts();
            }
            finally
            {
                AssetDatabase.StopAssetEditing();
            }

            // Refresh Unity
            AssetDatabase.Refresh();

            // Log the action
            ActivityService.Log("Complete project generated.");

            // Notify the user
            EditorUtility.DisplayDialog(
                "BRDK",
                "Project generation completed successfully!",
                "Awesome");
        }
    }
}