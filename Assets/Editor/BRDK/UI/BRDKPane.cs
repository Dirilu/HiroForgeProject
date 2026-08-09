using UnityEditor;
using UnityEngine;

namespace BRDK.UI
{
    public static class BRDKPane
    {
        public static void Begin(float width = -1)
        {
            if (width > 0)
                GUILayout.BeginVertical("HelpBox", GUILayout.Width(width));
            else
                GUILayout.BeginVertical("HelpBox");

            GUILayout.Space(8);
        }

        public static void End()
        {
            GUILayout.Space(8);
            GUILayout.EndVertical();
        }
    }
}