using UnityEditor;

namespace BRDK.UI
{
    public static class BRDKFoldout
    {
        public static bool Draw(string title, bool expanded)
        {
            return EditorGUILayout.BeginFoldoutHeaderGroup(
                expanded,
                title);
        }

        public static void End()
        {
            EditorGUILayout.EndFoldoutHeaderGroup();
        }
    }
}