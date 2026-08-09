using System;
using System.Collections.Generic;
using System.IO;

namespace HF.Refactor.Scanning
{
    /// <summary>
    /// Scans Unity projects for JSON files.
    /// </summary>
    public sealed class JsonScanner : BaseScanner
    {
        public override string Name
        {
            get { return "JSON Scanner"; }
        }

        public override IReadOnlyList<string> SupportedExtensions
        {
            get
            {
                return new[]
                {
                    ".json"
                };
            }
        }

        /// <summary>
        /// Scans the project for JSON files.
        /// </summary>
        public override ProjectScanResult Scan(string projectRoot)
        {
            ProjectScanResult result = new ProjectScanResult();

            foreach (string file in EnumerateFiles(projectRoot, "*.json"))
            {
                // Future implementation:
                // Parse JSON
                // Detect renamed assets
                // Detect GUID references
                // Detect configuration references
                // Detect localization keys
            }

            return result;
        }

        /// <summary>
        /// Determines whether this scanner supports the file.
        /// </summary>
        public override bool CanScan(string filePath)
        {
            return filePath.EndsWith(
                ".json",
                StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Reads a JSON file.
        /// </summary>
        public string ReadFile(string filePath)
        {
            if (!File.Exists(filePath))
                return string.Empty;

            return File.ReadAllText(filePath);
        }
    }
}