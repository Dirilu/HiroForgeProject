using System;
using UnityEngine;
using UnityEngine.UIElements;

using BRDK2.Theme;
using BRDK2.DesignSystem;
using BRDK2.UI;

namespace BRDK2.UI
{
    public static class SidebarUI
    {
        public static VisualElement Create(Action<string> navigate)
        {
            VisualElement sidebar = new VisualElement();

            sidebar.style.width = 250;
            sidebar.style.backgroundColor = BRDKTheme.Sidebar;

            //-------------------------------------------------
            // Logo
            //-------------------------------------------------

            VisualElement logo = new VisualElement();

            logo.style.height = 100;
            logo.style.paddingLeft = 20;
            logo.style.paddingTop = 24;
            logo.style.paddingBottom = 24;

            Label title = new Label("HFDK");

            title.style.fontSize = 32;
            title.style.unityFontStyleAndWeight = FontStyle.Bold;
            title.style.color = BRDKTheme.Gold;

            logo.Add(title);

            Label edition = new Label("HiroForge Studios");

            edition.style.fontSize = 12;
            edition.style.color = BRDKTheme.SubText;
            edition.style.marginTop = -4;

            logo.Add(edition);

            sidebar.Add(logo);

            sidebar.Add(CreateDivider());

            //-------------------------------------------------
            // Navigation
            //-------------------------------------------------

            sidebar.Add(
                BRDKNavigationItem.Create(
                    "Dashboard",
                    BRDKIcons.Home,
                    true,
                    () => navigate("Dashboard")));

            sidebar.Add(
                BRDKNavigationItem.Create(
                    "Project",
                    BRDKIcons.Folder,
                    false,
                    () => navigate("Project")));

            sidebar.Add(
                BRDKNavigationItem.Create(
                    "Gameplay",
                    BRDKIcons.Gamepad,
                    false,
                    () => navigate("Gameplay")));

            sidebar.Add(
                BRDKNavigationItem.Create(
                    "Content",
                    BRDKIcons.Box,
                    false,
                    () => navigate("Content")));

            sidebar.Add(
                BRDKNavigationItem.Create(
                    "Build",
                    BRDKIcons.Rocket,
                    false,
                    () => navigate("Build")));

            sidebar.Add(
                BRDKNavigationItem.Create(
                    "Settings",
                    BRDKIcons.Settings,
                    false,
                    () => navigate("Settings")));

            sidebar.Add(
                BRDKNavigationItem.Create(
                    "Refactor",
                    BRDKIcons.Code,
                    false,
                    () => navigate("Refactor")));

            //-------------------------------------------------

            VisualElement spacer = new VisualElement();

            spacer.style.flexGrow = 1;

            sidebar.Add(spacer);

            sidebar.Add(CreateDivider());

            //-------------------------------------------------
            // Footer
            //-------------------------------------------------

            VisualElement project = new VisualElement();

            project.style.paddingLeft = 18;
            project.style.paddingBottom = 18;

            Label current =
                new Label("Current Project");

            current.style.color =
                BRDKTheme.SubText;

            project.Add(current);

            Label projectName =
                new Label(Application.productName);

            projectName.style.marginTop = 6;
            projectName.style.fontSize = 16;
            projectName.style.unityFontStyleAndWeight =
                FontStyle.Bold;

            project.Add(projectName);

            Label unity =
                new Label("Unity " + Application.unityVersion);

            unity.style.color =
                BRDKTheme.SubText;

            project.Add(unity);

            sidebar.Add(project);

            return sidebar;
        }

        //-------------------------------------------------

        static VisualElement CreateDivider()
        {
            VisualElement line = new VisualElement();

            line.style.height = 1;
            line.style.marginTop = 12;
            line.style.marginBottom = 12;

            line.style.backgroundColor =
                new Color(.25f, .25f, .26f);

            return line;
        }
    }
}