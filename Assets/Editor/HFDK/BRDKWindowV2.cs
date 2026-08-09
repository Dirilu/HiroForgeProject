using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

using BRDK2.UI;
using BRDK2.Pages;
using BRDK2.DesignSystem;

namespace BRDK2
{
    public class BRDKWindowV2 : EditorWindow
    {
        private VisualElement _contentArea;

        [MenuItem("Tools/BRDK 2.0")]
        public static void Open()
        {
            BRDKWindowV2 window = GetWindow<BRDKWindowV2>();

            window.titleContent = new GUIContent("BRDK 2.0");
            window.minSize = new Vector2(1400, 850);
        }

        //--------------------------------------------------

        public void CreateGUI()
        {
            rootVisualElement.Clear();

            LoadStyleSheet();

            rootVisualElement.style.flexDirection = FlexDirection.Column;
            rootVisualElement.style.flexGrow = 1;

            //------------------------------------------
            // Header
            //------------------------------------------

            rootVisualElement.Add(BRDKHeader.Create());

            //------------------------------------------
            // Body
            //------------------------------------------

            VisualElement body = new VisualElement();

            body.style.flexGrow = 1;
            body.style.flexDirection = FlexDirection.Row;

            rootVisualElement.Add(body);

            //------------------------------------------
            // Sidebar
            //------------------------------------------

            body.Add(SidebarUI.Create(ChangePage));

            //------------------------------------------
            // Content
            //------------------------------------------

            _contentArea = new VisualElement();

            _contentArea.style.flexGrow = 1;

            _contentArea.style.backgroundColor =
                new Color(.16f, .16f, .17f);

            _contentArea.style.paddingLeft = 25;
            _contentArea.style.paddingRight = 25;
            _contentArea.style.paddingTop = 25;
            _contentArea.style.paddingBottom = 25;

            body.Add(_contentArea);

            //------------------------------------------
            // Footer
            //------------------------------------------

            rootVisualElement.Add(FooterUI.Create());

            //------------------------------------------
            // Default Page
            //------------------------------------------

            ShowDashboard();
        }

        //--------------------------------------------------

        void LoadStyleSheet()
        {
            StyleSheet styleSheet =
                AssetDatabase.LoadAssetAtPath<StyleSheet>(
                    "Assets/Editor/BRDK2/Styles/BRDK.uss");

            if (styleSheet != null)
                rootVisualElement.styleSheets.Add(styleSheet);
        }

        //--------------------------------------------------
        // Navigation
        //--------------------------------------------------

        void ChangePage(string page)
        {
            switch (page)
            {
                case "Dashboard":
                    ShowDashboard();
                    break;

                case "Project":
                    ShowProject();
                    break;

                case "Gameplay":
                    ShowGameplay();
                    break;

                case "Content":
                    ShowContent();
                    break;

                case "Build":
                    ShowBuild();
                    break;

                case "Optimizer":
                    ShowOptimizer();
                    break;

                case "Settings":
                    ShowSettings();
                    break;

                case "Refactor":
                    ShowRefactor();
                    break; 
            
                default:
                    ShowDashboard();
                    break;

                
        } 
        } 

        //--------------------------------------------------
        // Pages
        //--------------------------------------------------

        void ShowDashboard()
        {
            OpenPage(DashboardPage.Create());
        }

        void ShowProject()
        {
            OpenPage(ProjectPage.Create());
        }

        void ShowGameplay()
        {
            OpenPage(CreatePlaceholder("Gameplay"));
        }

        void ShowContent()
        {
            OpenPage(CreatePlaceholder("Content"));
        }

        void ShowBuild()
        {
            OpenPage(BuildPage.Create());
        }

        void ShowOptimizer()
        {
            OpenPage(OptimizerPage.Create());
        }

        
    void ShowRefactor()
{
    _contentArea.Clear();
    _contentArea.Add(RefactorPage.Create());
}

        void ShowSettings()
        {
            OpenPage(CreatePlaceholder("Settings"));
        }

        //--------------------------------------------------
        // Helpers
        //--------------------------------------------------

        void OpenPage(VisualElement page)
        {
            _contentArea.Clear();
            _contentArea.Add(page);
        }

        VisualElement CreatePlaceholder(string title)
        {
            VisualElement root = new VisualElement();

            root.style.flexGrow = 1;

            Label label = new Label(title);

            label.style.fontSize = 28;
            label.style.unityFontStyleAndWeight =
                FontStyle.Bold;

            label.style.color = Color.white;

            root.Add(label);

            return root;
        }
    }
}