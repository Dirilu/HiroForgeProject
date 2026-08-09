using UnityEngine;
using UnityEngine.UIElements;
using BRDK2.UI;

namespace BRDK2.Pages
{
    public static class ProjectPage
    {
        public static VisualElement Create()
        {
            VisualElement root = new VisualElement();

            root.style.flexGrow = 1;

            Label title = new Label("📁 Project");

            title.style.fontSize = 28;
            title.style.unityFontStyleAndWeight = FontStyle.Bold;
            title.style.marginBottom = 20;

            root.Add(title);

            VisualElement row = new VisualElement();

            row.style.flexDirection = FlexDirection.Row;

            row.Add(CreateProjectCard());
            row.Add(CreateFoldersCard());

            root.Add(row);

            return root;
        }

        static VisualElement CreateProjectCard()
        {
            VisualElement card = CardUI.Create("Project");

            card.Add(new Label("Project Name"));
            card.Add(new Label(Application.productName));

            card.Add(new Label(""));
            card.Add(new Label("Unity Version"));
            card.Add(new Label(Application.unityVersion));

            return card;
        }

        static VisualElement CreateFoldersCard()
        {
            VisualElement card = CardUI.Create("Folders");

            card.Add(new Label("Assets"));
            card.Add(new Label("Scenes"));
            card.Add(new Label("Scripts"));
            card.Add(new Label("Prefabs"));
            card.Add(new Label("Materials"));

            return card;
        }
    }
}