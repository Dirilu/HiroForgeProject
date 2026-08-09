using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

using BRDK2.Models;
using BRDK2.Widgets;
using BRDK2.Theme;

namespace BRDK2.Windows
{
    public class InspectionWindow : EditorWindow
    {
        private static ScanResult Result;

        private ScrollView _scrollView;
        private TextField _searchField;

        //--------------------------------------------------

        public static void Show(ScanResult result)
        {
            Result = result;

            InspectionWindow window =
                GetWindow<InspectionWindow>();

            window.titleContent =
                new GUIContent(result.Title);

            window.minSize = new Vector2(700, 600);

            window.Show();
        }

        //--------------------------------------------------

        public void CreateGUI()
        {
            rootVisualElement.Clear();

            if (Result == null)
                return;

            rootVisualElement.style.paddingLeft = 20;
            rootVisualElement.style.paddingRight = 20;
            rootVisualElement.style.paddingTop = 20;
            rootVisualElement.style.paddingBottom = 20;

            //--------------------------------------------------
            // TITLE
            //--------------------------------------------------

            Label title = new Label(Result.Title);

            title.style.fontSize = 24;
            title.style.unityFontStyleAndWeight =
                FontStyle.Bold;

            title.style.marginBottom = 4;

            rootVisualElement.Add(title);

            //--------------------------------------------------
            // DESCRIPTION
            //--------------------------------------------------

            Label description =
                new Label(Result.Description);

            description.style.fontSize = 12;
            description.style.color =
                BRDKTheme.SubText;

            description.style.marginBottom = 15;

            rootVisualElement.Add(description);

            //--------------------------------------------------
            // TOOLBAR
            //--------------------------------------------------

            VisualElement toolbar =
                CreateToolbar();

            rootVisualElement.Add(toolbar);

            //--------------------------------------------------
            // SEARCH
            //--------------------------------------------------

            _searchField = new TextField();

            _searchField.label = "Search";

            _searchField.style.marginBottom = 12;

            _searchField.RegisterValueChangedCallback(evt =>
            {
                RefreshList(evt.newValue);
            });

            rootVisualElement.Add(_searchField);

            //--------------------------------------------------
            // LIST
            //--------------------------------------------------

            _scrollView = new ScrollView();

            _scrollView.style.flexGrow = 1;

            rootVisualElement.Add(_scrollView);

            RefreshList("");

            //--------------------------------------------------
            // FOOTER
            //--------------------------------------------------

            Label footer = new Label(
                $"{Result.Count} issue(s) found");

            footer.style.marginTop = 15;
            footer.style.fontSize = 11;
            footer.style.color =
                BRDKTheme.SubText;

            footer.style.unityTextAlign =
                TextAnchor.MiddleCenter;

            rootVisualElement.Add(footer);
        }

        //--------------------------------------------------

        VisualElement CreateToolbar()
        {
            VisualElement toolbar =
                new VisualElement();

            toolbar.style.flexDirection =
                FlexDirection.Row;

            toolbar.style.marginBottom = 12;

            //--------------------------------------------------

            Button pingAll = new Button();

            pingAll.text = "Ping All";

            pingAll.clicked += () =>
            {
                if (Result.Objects.Count == 0)
                    return;

                Selection.objects =
                    Result.Objects.ToArray();

                EditorGUIUtility.PingObject(
                    Result.Objects[0]);
            };

            toolbar.Add(pingAll);

            //--------------------------------------------------

            Button refresh = new Button();

            refresh.text = "Refresh";

            refresh.clicked += () =>
            {
                RefreshList(
                    _searchField.value);
            };

            toolbar.Add(refresh);

            return toolbar;
        }

        //--------------------------------------------------

        void RefreshList(string filter)
        {
            _scrollView.Clear();

            filter = filter.ToLower();

            for (int i = 0; i < Result.Paths.Count; i++)
            {
                string path = Result.Paths[i];

                if (!string.IsNullOrEmpty(filter))
                {
                    if (!path.ToLower().Contains(filter))
                        continue;
                }

                _scrollView.Add(
                    InspectionItem.Create(
                        path,
                        Result.Objects[i]));
            }
        }
    }
}