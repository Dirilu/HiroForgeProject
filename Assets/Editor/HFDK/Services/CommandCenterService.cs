using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

using BRDK2.Models;
using BRDK2.DesignSystem;

namespace BRDK2.Services
{
    public static class CommandCenterService
    {
        public static List<CommandAction> GetActions()
        {
            List<CommandAction> actions =
                new List<CommandAction>();

            //--------------------------------------------------

            actions.Add(
                new CommandAction(
                    "Scan Project",
                    "Run the project scanner.",
                    BRDKIcons.Search,
                    () =>
                    {
                        Debug.Log(
                            "[BRDK] Scan Project");
                    }));

            //--------------------------------------------------

            actions.Add(
                new CommandAction(
                    "Optimize Project",
                    "Run all optimizers.",
                    BRDKIcons.Tools,
                    () =>
                    {
                        Debug.Log(
                            "[BRDK] Optimize");
                    }));

            //--------------------------------------------------

            actions.Add(
                new CommandAction(
                    "Build Game",
                    "Open Build Settings.",
                    BRDKIcons.Build,
                    () =>
                    {
                        EditorWindow.GetWindow(
                            typeof(BuildPlayerWindow));
                    }));

            //--------------------------------------------------

            actions.Add(
                new CommandAction(
                    "Player Settings",
                    "Open Player Settings.",
                    BRDKIcons.Settings,
                    () =>
                    {
                        SettingsService.OpenProjectSettings(
                            "Project/Player");
                    }));

            return actions;
        }
    }
}