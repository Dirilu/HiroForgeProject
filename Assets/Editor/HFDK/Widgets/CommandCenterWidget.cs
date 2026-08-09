using UnityEngine.UIElements;

using BRDK2.DesignSystem;
using BRDK2.Services;

namespace BRDK2.Widgets
{
    public static class CommandCenterWidget
    {
        public static VisualElement Create()
        {
            VisualElement card =
                BRDKCard.Create(
                    "Command Center",
                    BRDKIcons.Tools);

            VisualElement content =
                BRDKCard.Content(card);

            VisualElement grid =
                new VisualElement();

            grid.style.flexDirection =
                FlexDirection.Row;

            grid.style.flexWrap =
                Wrap.Wrap;

            foreach(var action in
                CommandCenterService.GetActions())
            {
                grid.Add(
                    ActionTile.Create(
                        action.Icon,
                        action.Title,
                        action.Description,
                        action.Execute));
            }

            content.Add(grid);

            return card;
        }
    }
}
