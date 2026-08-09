using UnityEditor;

namespace BRDK.Validators
{
    public static class BRDKProjectValidator
    {
        private static readonly string[] RequiredFolders =
        {
            "Assets/Animations",
            "Assets/Art",
            "Assets/Audio",
            "Assets/Fonts",
            "Assets/Materials",
            "Assets/Models",
            "Assets/Prefabs",
            "Assets/Resources",
            "Assets/Scenes",
            "Assets/ScriptableObjects",
            "Assets/Scripts",
            "Assets/Settings",
            "Assets/StreamingAssets",
            "Assets/Text"
        };

        public static bool ProjectStructureIsValid()
        {
            foreach (string folder in RequiredFolders)
            {
                if (!AssetDatabase.IsValidFolder(folder))
                    return false;
            }

            return true;
        }
    }
}