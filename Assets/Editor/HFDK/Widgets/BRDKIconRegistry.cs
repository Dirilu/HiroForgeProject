using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace BRDK2.DesignSystem
{
    [InitializeOnLoad]
    public static class BRDKIconRegistry
    {
        static readonly Dictionary<string, Texture2D> icons =
            new Dictionary<string, Texture2D>();

        static BRDKIconRegistry()
        {
            Load();
        }

        public static Texture2D Get(string name)
        {
            icons.TryGetValue(name, out Texture2D icon);
            return icon;
        }

        static void Load()
        {
            icons.Clear();

            string[] guids =
                AssetDatabase.FindAssets("t:VectorImage", new[]
                {
                    "Assets/Editor/BRDK2/Resources/Icons"
                });

            foreach (string guid in guids)
            {
                string path = AssetDatabase.GUIDToAssetPath(guid);

                Texture2D preview =
                    AssetPreview.GetMiniThumbnail(
                        AssetDatabase.LoadMainAssetAtPath(path));

                string file =
                    System.IO.Path.GetFileNameWithoutExtension(path);

                icons[file] = preview;
            }

            Debug.Log($"BRDK Icons Loaded: {icons.Count}");
        }
    }
}