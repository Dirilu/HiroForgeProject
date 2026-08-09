using UnityEditor;

namespace BRDK2.Services
{
    public static class ProjectHealthService
    {
        public static bool HasFolder(string path)
        {
            return AssetDatabase.IsValidFolder(path);
        }

        public static bool HasScenes()
        {
            return HasFolder("Assets/Scenes");
        }

        public static bool HasScripts()
        {
            return HasFolder("Assets/Scripts");
        }

        public static bool HasResources()
        {
            return HasFolder("Assets/Resources");
        }

        public static bool HasMaterials()
        {
            return HasFolder("Assets/Materials");
        }

        public static bool HasPrefabs()
        {
            return HasFolder("Assets/Prefabs");
        }

        public static bool HasSettings()
        {
            return HasFolder("Assets/Settings");
        }

        public static bool HasAddressables()
        {
            return HasFolder("Assets/AddressableAssetsData");
        }

        public static int HealthPercent()
        {
            int total = 7;
            int score = 0;

            if (HasScenes()) score++;
            if (HasScripts()) score++;
            if (HasResources()) score++;
            if (HasMaterials()) score++;
            if (HasPrefabs()) score++;
            if (HasSettings()) score++;
            if (HasAddressables()) score++;

            return (score * 100) / total;
        }
    }
}