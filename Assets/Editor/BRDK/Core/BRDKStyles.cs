using UnityEditor;
using UnityEngine;

namespace BRDK.Core
{
    public static class BRDKStyles
    {
        private static GUIStyle _title;
        private static GUIStyle _section;
        private static GUIStyle _card;
        private static GUIStyle _bigButton;

        public static GUIStyle Title
        {
            get
            {
                if (_title == null)
                {
                    _title = new GUIStyle(EditorStyles.boldLabel);

                    _title.fontSize = 24;
                    _title.fontStyle = FontStyle.Bold;
                    _title.alignment = TextAnchor.MiddleCenter;
                    _title.normal.textColor = BRDKColors.Gold;
                }

                return _title;
            }
        }

        public static GUIStyle Section
        {
            get
            {
                if (_section == null)
                {
                    _section = new GUIStyle(EditorStyles.boldLabel);

                    _section.fontSize = 15;
                    _section.fontStyle = FontStyle.Bold;
                    _section.normal.textColor = Color.white;
                }

                return _section;
            }
        }

        public static GUIStyle Card
        {
            get
            {
                if (_card == null)
                {
                    _card = new GUIStyle("HelpBox");

                    _card.padding =
                        new RectOffset(15,15,15,15);

                    _card.margin =
                        new RectOffset(8,8,8,8);
                }

                return _card;
            }
        }

        public static GUIStyle BigButton
        {
            get
            {
                if (_bigButton == null)
                {
                    _bigButton = new GUIStyle(GUI.skin.button);

                    _bigButton.fontSize = 16;
                    _bigButton.fontStyle = FontStyle.Bold;
                    _bigButton.fixedHeight = 45;
                }

                return _bigButton;
            }
        }
    }
}