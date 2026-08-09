using System.Collections.Generic;
using UnityEngine;

namespace BRDK2.DesignSystem
{
    public static class BRDKIconDatabase
    {
        private static readonly Dictionary<string, Texture2D> cache = new();

        public static Texture2D Get(string iconName)
        {
            if (string.IsNullOrEmpty(iconName))
                return null;

            if (cache.TryGetValue(iconName, out var texture))
                return texture;

            texture = Resources.Load<Texture2D>("Icons/" + iconName);

            if (texture == null)
            {
                Debug.LogError($"[BRDK] Could not load Resources/Icons/{iconName}.png");
            }

            cache[iconName] = texture;

            return texture;
        }

        public static void ClearCache()
        {
            cache.Clear();
        }
    }
}