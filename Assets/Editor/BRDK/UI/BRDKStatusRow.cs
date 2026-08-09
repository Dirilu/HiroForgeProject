using UnityEditor;
using UnityEngine;

namespace BRDK.UI
{
    public static class BRDKStatusRow
    {
        public static void Draw(string title, bool completed)
        {
            EditorGUILayout.BeginHorizontal();

            GUILayout.Label(
                completed ? "🟢" : "🔴",
                GUILayout.Width(25));

            GUILayout.Label(
                title,
                EditorStyles.label);

            GUILayout.FlexibleSpace();

            GUILayout.Label(
                completed ? "READY" : "MISSING",
                EditorStyles.miniBoldLabel);

            EditorGUILayout.EndHorizontal();
        }
    }
}