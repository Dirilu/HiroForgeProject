using System;
using System.Collections.Generic;
using System.IO;

namespace HF.Refactor.Scanning
{
    /// <summary>
    /// Scans Unity Assembly Definition (.asmdef) files.
    /// </summary>
    public sealed class AsmDefScanner : BaseScanner
    {
        public override string Name
        {
            get { return "Assembly Definition Scanner"; }
        }

        public override IReadOnlyList<string> SupportedExtensions
        {
            get
            {
                return new[]
                {
                    ".asmdef"
                };
            }
        }

        /// <summary>
        /// Scans the project for Assembly Definition files.
        /// </summary>
        public override ProjectScanResult Scan(string projectRoot)
        {
            ProjectScanResult result = new ProjectScanResult();

            foreach (string file in EnumerateFiles(projectRoot, "*.asmdef"))
            {
                // Future:
                // Parse JSON
                // Read assembly name
                // Read references
                // Detect circular dependencies
                // Build dependency graph
            }

            return result;
        }

        public override bool CanScan(string filePath)
        {
            return filePath.EndsWith(
                ".asmdef",
                StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Reads the contents of an asmdef file.
        /// </summary>
        public string ReadFile(string filePath)
        {
            if (!File.Exists(filePath))
                return string.Empty;

            return File.ReadAllText(filePath);
        }
    }
}