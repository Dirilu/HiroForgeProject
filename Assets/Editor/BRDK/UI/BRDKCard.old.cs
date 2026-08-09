using UnityEditor;
using UnityEngine;

namespace BRDK.UI
{
    public static class BRDKCard
    {
        public static void Begin()
        {
            EditorGUILayout.BeginVertical("HelpBox");
            GUILayout.Space(6);
        }

        public static void End()
        {
            GUILayout.Space(6);
            EditorGUILayout.EndVertical();
        }
    }
}