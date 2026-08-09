using System;
using System.Collections.Generic;
using System.IO;

namespace HF.Refactor.Scanning
{
    /// <summary>
    /// Scans Unity Prefab (.prefab) files.
    /// </summary>
    public sealed class PrefabScanner : BaseScanner
    {
        public override string Name
        {
            get { return "Prefab Scanner"; }
        }

        public override IReadOnlyList<string> SupportedExtensions
        {
            get
            {
                return new[]
                {
                    ".prefab"
                };
            }
        }

        /// <summary>
        /// Scans the project for Prefab files.
        /// </summary>
        public override ProjectScanResult Scan(string projectRoot)
        {
            ProjectScanResult result = new ProjectScanResult();

            foreach (string file in EnumerateFiles(projectRoot, "*.prefab"))
            {
                // Future:
                // Parse YAML
                // Detect MonoBehaviour references
                // Detect missing scripts
                // Detect GUID references
                // Detect nested prefabs
                // Detect Addressables
                // Build dependency graph
            }

            return result;
        }

        public override bool CanScan(string filePath)
        {
            return filePath.EndsWith(
                ".prefab",
                StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Reads the contents of a prefab file.
        /// </summary>
        public string ReadFile(string filePath)
        {
            if (!File.Exists(filePath))
                return string.Empty;

            return File.ReadAllText(filePath);
        }

        /// <summary>
        /// Returns true if the file appears to be a Unity prefab.
        /// </summary>
        public bool IsPrefab(string filePath)
        {
            return File.Exists(filePath) &&
                   filePath.EndsWith(".prefab", StringComparison.OrdinalIgnoreCase);
        }
    }
}