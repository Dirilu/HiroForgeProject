using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace BRDK2.Services
{
    /// <summary>
    /// Lightweight project analyzer used by the HFDK dashboard.
    /// </summary>
    public static class HFDKAnalyzer
    {
        public class ScriptInfo
        {
            public string path;
            public string name;
            public Object asset;
        }

        static readonly List<ScriptInfo> _unusedScripts = new List<ScriptInfo>();

        public static IReadOnlyList<ScriptInfo> unusedScripts => _unusedScripts;

        public static void Analyze()
        {
            _unusedScripts.Clear();

            string[] scriptGuids = AssetDatabase.FindAssets(
                "t:MonoScript",
                new[] { "Assets/Game", "Assets/Scripts" });

            HashSet<string> referencedScriptPaths = CollectReferencedScriptPaths();

            foreach (string guid in scriptGuids)
            {
                string path = AssetDatabase.GUIDToAssetPath(guid);

                if (string.IsNullOrEmpty(path) || !path.EndsWith(".cs"))
                    continue;

                if (path.Contains("/Editor/"))
                    continue;

                MonoScript script = AssetDatabase.LoadAssetAtPath<MonoScript>(path);

                if (script == null)
                    continue;

                System.Type type = script.GetClass();

                // Skip non-MonoBehaviour scripts and anything already referenced.
                if (type == null || !typeof(MonoBehaviour).IsAssignableFrom(type))
                    continue;

                if (referencedScriptPaths.Contains(path))
                    continue;

                _unusedScripts.Add(new ScriptInfo
                {
                    path = path,
                    name = Path.GetFileNameWithoutExtension(path),
                    asset = script
                });
            }
        }

        static HashSet<string> CollectReferencedScriptPaths()
        {
            HashSet<string> referenced = new HashSet<string>();

            string[] prefabGuids = AssetDatabase.FindAssets("t:Prefab");

            foreach (string guid in prefabGuids)
            {
                string prefabPath = AssetDatabase.GUIDToAssetPath(guid);
                GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);

                if (prefab == null)
                    continue;

                MonoBehaviour[] behaviours =
                    prefab.GetComponentsInChildren<MonoBehaviour>(true);

                foreach (MonoBehaviour behaviour in behaviours)
                {
                    if (behaviour == null)
                        continue;

                    MonoScript script = MonoScript.FromMonoBehaviour(behaviour);

                    if (script == null)
                        continue;

                    string scriptPath = AssetDatabase.GetAssetPath(script);

                    if (!string.IsNullOrEmpty(scriptPath))
                        referenced.Add(scriptPath);
                }
            }

            return referenced;
        }
    }
}
