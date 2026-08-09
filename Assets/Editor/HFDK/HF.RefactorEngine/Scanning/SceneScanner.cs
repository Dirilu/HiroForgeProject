using System;
using System.Collections.Generic;
using System.IO;

namespace HF.Refactor.Scanning
{
    /// <summary>
    /// Scans Unity Scene (.unity) files.
    /// </summary>
    public sealed class SceneScanner : BaseScanner
    {
        public override string Name
        {
            get { return "Scene Scanner"; }
        }

        public override IReadOnlyList<string> SupportedExtensions
        {
            get
            {
                return new[]
                {
                    ".unity"
                };
            }
        }

        /// <summary>
        /// Scans the project for Unity scene files.
        /// </summary>
        public override ProjectScanResult Scan(string projectRoot)
        {
            ProjectScanResult result = new ProjectScanResult();

            foreach (string file in EnumerateFiles(projectRoot, "*.unity"))
            {
                // Future implementation:
                // - Parse Unity YAML
                // - Detect GameObjects
                // - Detect Components
                // - Detect Prefab references
                // - Detect Missing Scripts
                // - Detect Scene dependencies
                // - Detect Addressables
                // - Build dependency graph
            }

            return result;
        }

        public override bool CanScan(string filePath)
        {
            return filePath.EndsWith(
                ".unity",
                StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Reads a Unity scene file.
        /// </summary>
        public string ReadFile(string filePath)
        {
            if (!File.Exists(filePath))
                return string.Empty;

            return File.ReadAllText(filePath);
        }

        /// <summary>
        /// Returns true if the supplied file is a Unity scene.
        /// </summary>
        public bool IsScene(string filePath)
        {
            return File.Exists(filePath) &&
                   filePath.EndsWith(".unity", StringComparison.OrdinalIgnoreCase);
        }
    }
}