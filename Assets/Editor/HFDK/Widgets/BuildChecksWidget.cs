using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

using BRDK2.DesignSystem;
using BRDK2.Services;
using BRDK2.Theme;

namespace BRDK2.Widgets
{
    public static class BuildChecksWidget
    {
        public static VisualElement Create()
        {
            VisualElement card =
                BRDKCard.Create(
                    "Build Checks",
                    BRDKIcons.Build);

            VisualElement content =
                BRDKCard.Content(card);

            List<BuildCheck> checks =
                BuildValidationService.Validate();

            foreach (BuildCheck check in checks)
            {
                content.Add(CreateRow(check));
            }

            return card;
        }

        static VisualElement CreateRow(BuildCheck check)
        {
            VisualElement row = new VisualElement();

            row.style.flexDirection =
                FlexDirection.Row;

            row.style.justifyContent =
                Justify.SpaceBetween;

            row.style.alignItems =
                Align.Center;

            row.style.marginBottom = 8;

            //-----------------------------------

            VisualElement left =
                new VisualElement();

            left.style.flexDirection =
                FlexDirection.Row;

            left.style.alignItems =
                Align.Center;

            string icon =
                check.Passed
                ? BRDKIcons.Check
                : BRDKIcons.Warning;

            left.Add(
                BRDKIcon.Create(icon,18));

            Label name =
                new Label(check.Name);

            name.style.marginLeft = 8;

            name.style.color =
                BRDKTheme.Text;

            left.Add(name);

            //-----------------------------------

            Label value =
                new Label(check.Message);

            value.style.color =
                check.Passed
                ? new Color(.3f,.85f,.4f)
                : new Color(.95f,.55f,.2f);

            value.style.unityFontStyleAndWeight =
                FontStyle.Bold;

            //-----------------------------------

            row.Add(left);
            row.Add(value);

            return row;
        }
    }
}