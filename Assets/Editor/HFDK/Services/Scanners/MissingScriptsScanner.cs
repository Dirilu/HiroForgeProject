using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using BRDK2.Models;

namespace BRDK2.Services.Scanners
{
    public static class MissingScriptsScanner
    {
        public static ScanResult Scan()
        {
            ScanResult result = new ScanResult(
                "Missing Scripts",
                "Broken MonoBehaviours in prefabs",
                0,
                ScanSeverity.Good);

            string[] prefabGuids = AssetDatabase.FindAssets("t:Prefab");

            foreach (string guid in prefabGuids)
            {
                string path = AssetDatabase.GUIDToAssetPath(guid);

                GameObject prefab =
                    AssetDatabase.LoadAssetAtPath<GameObject>(path);

                if (prefab == null)
                    continue;

                Component[] components =
                    prefab.GetComponentsInChildren<Component>(true);

                bool hasMissing = false;

                foreach (Component component in components)
                {
                    if (component == null)
                    {
                        result.Count++;
                        hasMissing = true;
                    }
                }

                if (hasMissing)
                {
                    result.Objects.Add(prefab);
                }
            }

            if (result.Count > 0)
                result.Severity = ScanSeverity.Error;

            return result;
        }
    }
}