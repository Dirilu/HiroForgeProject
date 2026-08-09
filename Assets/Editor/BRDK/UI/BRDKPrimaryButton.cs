using UnityEditor;
using UnityEngine;

namespace BRDK.UI
{
    public static class BRDKPrimaryButton
    {
        public static bool Draw(string text)
        {
            Color oldColor = GUI.backgroundColor;

            GUI.backgroundColor = new Color(
                1.0f,
                0.75f,
                0.15f);

            bool pressed = GUILayout.Button(
                text,
                GUILayout.Height(45));

            GUI.backgroundColor = oldColor;

            return pressed;
        }
    }
}