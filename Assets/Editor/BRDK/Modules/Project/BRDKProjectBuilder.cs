using UnityEditor;

using BRDK.Modules.Project;
using BRDK.Modules.Scenes;
using BRDK.Modules.Scripts;
using BRDK.Validators;

namespace BRDK.Modules.Project
{
    public static class BRDKProjectBuilder
    {
        [MenuItem("Tools/Balut Royale/Create Complete Project")]
        public static void CreateCompleteProject()
        {
            BRDKProjectGenerator.CreateProjectStructure();

            BRDKSceneGenerator.CreateScenes();

            BRDKScriptGenerator.CreateScripts();

            bool valid = BRDKProjectValidator.ProjectStructureIsValid();

            EditorUtility.DisplayDialog(
                "Balut Royale",
                valid
                    ? "🎉 Balut Royale project created successfully!"
                    : "⚠ Project created, but validation failed.",
                "Awesome");
        }
    }
}