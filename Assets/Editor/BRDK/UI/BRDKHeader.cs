using UnityEditor;
using UnityEngine;

namespace BRDK.UI
{
    public static class BRDKHeader
    {
        public static void Draw(string version)
        {
            Rect rect = GUILayoutUtility.GetRect(0, 90, GUILayout.ExpandWidth(true));

            EditorGUI.DrawRect(rect, new Color(0.18f, 0.18f, 0.20f));

            GUILayout.Space(-85);

            GUIStyle title = new GUIStyle(EditorStyles.boldLabel);
            title.fontSize = 24;
            title.alignment = TextAnchor.MiddleCenter;
            title.normal.textColor = BRDK.Core.BRDKColors.Gold;

            GUIStyle subtitle = new GUIStyle(EditorStyles.label);
            subtitle.alignment = TextAnchor.MiddleCenter;
            subtitle.normal.textColor = Color.white;

            GUILayout.Space(12);

            GUILayout.Label("👑 BALUT ROYALE", title);

            GUILayout.Label("Development Kit", subtitle);

            GUILayout.Label("Version " + version, EditorStyles.centeredGreyMiniLabel);

            GUILayout.Space(10);
        }
    }
}