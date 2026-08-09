using UnityEditor;

namespace BRDK2.Services
{
    public static class StatisticsService
    {
        public static int SceneCount()
        {
            return AssetDatabase.FindAssets("t:Scene").Length;
        }

        public static int ScriptCount()
        {
            return AssetDatabase.FindAssets("t:MonoScript").Length;
        }

        public static int PrefabCount()
        {
            return AssetDatabase.FindAssets("t:Prefab").Length;
        }

        public static int MaterialCount()
        {
            return AssetDatabase.FindAssets("t:Material").Length;
        }

        public static int TextureCount()
        {
            return AssetDatabase.FindAssets("t:Texture2D").Length;
        }

        public static int AudioCount()
        {
            return AssetDatabase.FindAssets("t:AudioClip").Length;
        }

        public static int AnimationCount()
        {
            return AssetDatabase.FindAssets("t:AnimationClip").Length;
        }
    }
}