using BRDK2.Windows;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

using BRDK2.DesignSystem;
using BRDK2.Models;
using BRDK2.Services;
using BRDK2.Theme;

namespace BRDK2.Widgets
{
    public static class ProjectScannerWidget
    {
        public static VisualElement Create()
        {
            VisualElement card = BRDKCard.Create(
                "Project Scanner",
                BRDKIcons.Search);

            Refresh(card);

            return card;
        }

        //----------------------------------------------------------
        // Refresh
        //----------------------------------------------------------

        static void Refresh(VisualElement card)
        {
            card.Clear();

            // Header
            card.Add(CreateHeader());

            List<ScanResult> results =
                ProjectScannerService.Scan();

            foreach (ScanResult result in results)
            {
                card.Add(CreateRow(result));
            }

            card.Add(CreateScanButton(card));

            Label footer = new Label(
                $"{results.Count} inspections available");

            footer.style.marginTop = 14;
            footer.style.fontSize = 11;
            footer.style.color = BRDKTheme.SubText;
            footer.style.unityTextAlign = TextAnchor.MiddleCenter;

            card.Add(footer);
        }

        //----------------------------------------------------------
        // Header
        //----------------------------------------------------------

        static VisualElement CreateHeader()
        {
            VisualElement header = new VisualElement();

            header.style.flexDirection = FlexDirection.Row;
            header.style.alignItems = Align.Center;
            header.style.marginBottom = 14;

            header.Add(BRDKIcon.Create(BRDKIcons.Search, 24));

            Label title = new Label("Project Scanner");

            title.style.marginLeft = 10;
            title.style.fontSize = 18;
            title.style.unityFontStyleAndWeight =
                FontStyle.Bold;
            title.style.color = BRDKTheme.Text;

            header.Add(title);

            return header;
        }

        //----------------------------------------------------------
        // Row
        //----------------------------------------------------------

        static VisualElement CreateRow(ScanResult result)
        {
            VisualElement row = new VisualElement();

            row.style.flexDirection = FlexDirection.Row;
            row.style.justifyContent = Justify.SpaceBetween;
            row.style.alignItems = Align.Center;

            row.style.marginTop = 4;
            row.style.marginBottom = 4;

            row.style.paddingTop = 8;
            row.style.paddingBottom = 8;
            row.style.paddingLeft = 8;
            row.style.paddingRight = 8;

            row.style.borderBottomWidth = 1;
            row.style.borderBottomColor =
                new Color(.22f,.22f,.24f);

            //------------------------------------------------------
            // Left
            //------------------------------------------------------

            VisualElement left = new VisualElement();

            left.style.flexDirection = FlexDirection.Row;
            left.style.alignItems = Align.Center;
            left.style.flexGrow = 1;

            string icon = BRDKIcons.Check;
            Color color = new Color(.35f,.85f,.45f);

            switch (result.Severity)
            {
                case ScanSeverity.Warning:

                    icon = BRDKIcons.Warning;
                    color = new Color(.95f,.75f,.15f);

                    break;

                case ScanSeverity.Error:

                    icon = BRDKIcons.Warning;
                    color = new Color(.95f,.35f,.35f);

                    break;
            }

            left.Add(BRDKIcon.Create(icon, 20));

            Label label = new Label(result.Title);

            label.style.marginLeft = 10;
            label.style.color = BRDKTheme.Text;
            label.style.flexGrow = 1;

            left.Add(label);

            row.Add(left);

            //------------------------------------------------------
            // Right
            //------------------------------------------------------

            Label count = new Label(result.Count.ToString());

            count.style.minWidth = 30;
            count.style.fontSize = 15;
            count.style.unityTextAlign =
                TextAnchor.MiddleRight;

            count.style.unityFontStyleAndWeight =
                FontStyle.Bold;

            count.style.color = color;

            row.Add(count);

            //------------------------------------------------------
            // Hover
            //------------------------------------------------------

            row.RegisterCallback<MouseEnterEvent>(_ =>
            {
                row.style.backgroundColor =
                    new Color(.20f,.20f,.22f);
            });

            row.RegisterCallback<MouseLeaveEvent>(_ =>
            {
                row.style.backgroundColor = Color.clear;
            });

            //------------------------------------------------------
            // Click
            //------------------------------------------------------

            row.RegisterCallback<ClickEvent>(_ =>
            {
                if (result.Objects != null &&
                    result.Objects.Count > 0)
                {
                    InspectionWindow.Show(result);

                    Debug.Log(
                        $"[BRDK] Selected {result.Objects.Count} object(s)");
                }
            });

            return row;
        }

        //----------------------------------------------------------
        // Scan Button
        //----------------------------------------------------------

        static Button CreateScanButton(VisualElement card)
        {
            Button button = new Button();

            button.text = "Scan Project";

            button.style.height = 36;
            button.style.marginTop = 16;

            button.clicked += () =>
            {
                Refresh(card);
            };

            return button;
        }
    }
}