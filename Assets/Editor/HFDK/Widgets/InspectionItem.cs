using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

using BRDK2.DesignSystem;
using BRDK2.Theme;

namespace BRDK2.Widgets
{
    public static class InspectionItem
    {
        public static VisualElement Create(
            string path,
            Object obj)
        {
            //--------------------------------------------------
            // CARD
            //--------------------------------------------------

            VisualElement card = new VisualElement();

            card.style.flexDirection = FlexDirection.Row;
            card.style.alignItems = Align.Center;
            card.style.justifyContent = Justify.SpaceBetween;

            card.style.paddingLeft = 14;
            card.style.paddingRight = 14;
            card.style.paddingTop = 12;
            card.style.paddingBottom = 12;

            card.style.marginBottom = 8;

            card.style.backgroundColor = BRDKTheme.Card;

            card.style.borderTopLeftRadius = 10;
            card.style.borderTopRightRadius = 10;
            card.style.borderBottomLeftRadius = 10;
            card.style.borderBottomRightRadius = 10;

            card.style.borderTopWidth = 1;
            card.style.borderBottomWidth = 1;
            card.style.borderLeftWidth = 1;
            card.style.borderRightWidth = 1;

            Color border = new Color(.26f,.26f,.28f);

            card.style.borderTopColor = border;
            card.style.borderBottomColor = border;
            card.style.borderLeftColor = border;
            card.style.borderRightColor = border;

            //--------------------------------------------------
            // LEFT
            //--------------------------------------------------

            VisualElement left = new VisualElement();

            left.style.flexDirection = FlexDirection.Row;
            left.style.alignItems = Align.Center;
            left.style.flexGrow = 1;

            //--------------------------------------------------
            // ICON
            //--------------------------------------------------

            VisualElement icon =
                BRDKIcon.Create(BRDKIcons.Folder,22);

            icon.style.marginRight = 12;

            left.Add(icon);

            //--------------------------------------------------
            // TEXT
            //--------------------------------------------------

            VisualElement text =
                new VisualElement();

            text.style.flexGrow = 1;

            Label title =
                new Label(path);

            title.style.fontSize = 13;
            title.style.unityFontStyleAndWeight =
                FontStyle.Bold;

            title.style.color =
                BRDKTheme.Text;

            text.Add(title);

            string typeName =
                obj != null
                ? obj.GetType().Name
                : "Unknown";

            Label subtitle =
                new Label(typeName);

            subtitle.style.fontSize = 11;

            subtitle.style.color =
                BRDKTheme.SubText;

            subtitle.style.marginTop = 2;

            text.Add(subtitle);

            left.Add(text);

            card.Add(left);

            //--------------------------------------------------
            // BUTTONS
            //--------------------------------------------------

            VisualElement buttons =
                new VisualElement();

            buttons.style.flexDirection =
                FlexDirection.Row;

            //--------------------------------------------------

            Button ping = new Button();

            ping.text = "Ping";

            ping.clicked += () =>
            {
                if (obj == null)
                    return;

                EditorGUIUtility.PingObject(obj);
                Selection.activeObject = obj;
            };

            buttons.Add(ping);

            //--------------------------------------------------

            Button open = new Button();

            open.text = "Open";

            open.style.marginLeft = 6;

            open.clicked += () =>
            {
                if (obj == null)
                    return;

                AssetDatabase.OpenAsset(obj);
            };

            buttons.Add(open);

            //--------------------------------------------------

            card.Add(buttons);

            //--------------------------------------------------
            // HOVER
            //--------------------------------------------------

            card.RegisterCallback<MouseEnterEvent>(_ =>
            {
                card.style.backgroundColor =
                    new Color(.23f,.23f,.25f);
            });

            card.RegisterCallback<MouseLeaveEvent>(_ =>
            {
                card.style.backgroundColor =
                    BRDKTheme.Card;
            });

            //--------------------------------------------------
            // DOUBLE CLICK
            //--------------------------------------------------

            card.RegisterCallback<ClickEvent>(evt =>
            {
                if (evt.clickCount == 2 && obj != null)
                {
                    AssetDatabase.OpenAsset(obj);
                }
            });

            //--------------------------------------------------
            // CONTEXT MENU
            //--------------------------------------------------

            card.AddManipulator(
                new ContextualMenuManipulator(menu =>
                {
                    menu.menu.AppendAction(
                        "Ping",
                        _ =>
                        {
                            if (obj != null)
                            {
                                EditorGUIUtility.PingObject(obj);
                                Selection.activeObject = obj;
                            }
                        });

                    menu.menu.AppendAction(
                        "Open",
                        _ =>
                        {
                            if (obj != null)
                            {
                                AssetDatabase.OpenAsset(obj);
                            }
                        });

                    menu.menu.AppendSeparator();

                    menu.menu.AppendAction(
                        "Copy Path",
                        _ =>
                        {
                            EditorGUIUtility.systemCopyBuffer = path;
                        });
                }));

            return card;
        }
    }
}