using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace BRDK2.DesignSystem
{
    public static class BRDKLogo
    {
        private const string LogoPath =
            "Assets/Editor/BRDK2/Branding/Logo/brdk_logo.png";

        public static VisualElement Create(float size = 52)
        {
            Texture2D texture =
                AssetDatabase.LoadAssetAtPath<Texture2D>(LogoPath);

            Image image = new Image();

            image.image = texture;
            image.scaleMode = ScaleMode.ScaleToFit;

            image.style.width = size;
            image.style.height = size;

            return image;
        }
    }
}