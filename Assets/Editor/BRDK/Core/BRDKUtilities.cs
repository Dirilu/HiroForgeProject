using UnityEditor;
using UnityEngine;

namespace BRDK.Core
{
    public static class BRDKUtilities
    {
        public static void ShowSuccess(string title, string message)
        {
            EditorUtility.DisplayDialog(title, message, "OK");
        }

        public static void ShowError(string title, string message)
        {
            EditorUtility.DisplayDialog(title, message, "Close");
        }

        public static void Separator(int height = 8)
        {
            GUILayout.Space(height);
        }
    }
}