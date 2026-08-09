using UnityEngine;
using UnityEngine.UIElements;

namespace BRDK2.DesignSystem
{
    public static class BRDKIcon
    {
        public static VisualElement Create(string iconName, float size = 24f)
        {
            Texture2D texture = BRDKIconDatabase.Get(iconName);

            Image image = new Image();

            if (texture != null)
            {
                image.image = texture;
                image.scaleMode = ScaleMode.ScaleToFit;
            }

            image.style.width = size;
            image.style.height = size;

            image.style.minWidth = size;
            image.style.minHeight = size;

            image.style.maxWidth = size;
            image.style.maxHeight = size;

            image.style.flexShrink = 0;
            image.style.alignSelf = Align.Center;

            return image;
        }
    }
}