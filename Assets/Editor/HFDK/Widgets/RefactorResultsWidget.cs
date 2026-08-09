using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

using BRDK2.Models;
using BRDK2.DesignSystem;

namespace BRDK2.Widgets
{
    public static class RefactorResultsWidget
    {
        public static VisualElement Create(List<RefactorItem> items)
        {
            ScrollView scroll = new ScrollView();

            scroll.style.flexGrow = 1;

            foreach (RefactorItem item in items)
            {
                scroll.Add(CreateItem(item));
            }

            return scroll;
        }

        static VisualElement CreateItem(RefactorItem item)
        {
            VisualElement card =
                BRDKCard.Create(item.FilePath, BRDKIcons.FileCode);

            VisualElement content =
                BRDKCard.Content(card);

            //-------------------------------------

            Toggle toggle = new Toggle();

            toggle.value = item.Selected;

            toggle.RegisterValueChangedCallback(x =>
            {
                item.Selected = x.newValue;
            });

            content.Add(toggle);

            //-------------------------------------

            Label line =
                new Label($"Line {item.LineNumber}");

            line.style.unityFontStyleAndWeight =
                FontStyle.Bold;

            content.Add(line);

            //-------------------------------------

            Label before =
                new Label(item.OriginalText);

            before.style.whiteSpace =
                WhiteSpace.Normal;

            before.style.marginTop = 8;

            content.Add(before);

            //-------------------------------------

            Label arrow =
                new Label("↓");

            arrow.style.fontSize = 18;

            arrow.style.marginTop = 6;
            arrow.style.marginBottom = 6;

            content.Add(arrow);

            //-------------------------------------

            Label after =
                new Label(item.PreviewText);

            after.style.whiteSpace =
                WhiteSpace.Normal;

            after.style.color =
                new Color(.25f,.90f,.45f);

            content.Add(after);

            return card;
        }
    }
}