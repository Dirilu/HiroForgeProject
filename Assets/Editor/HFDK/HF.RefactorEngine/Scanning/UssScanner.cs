using System;
using System.Collections.Generic;

namespace HF.Refactor.Scanning
{
    /// <summary>
    /// Scans Unity projects for USS (UI Style Sheet) files.
    /// </summary>
    public sealed class UssScanner : BaseScanner
    {
        public override string Name
        {
            get { return "USS Scanner"; }
        }

        public override IReadOnlyList<string> SupportedExtensions
        {
            get
            {
                return new[]
                {
                    ".uss"
                };
            }
        }

        /// <summary>
        /// Scans the project for USS files.
        /// </summary>
        public override ProjectScanResult Scan(string projectRoot)
        {
            ProjectScanResult result = new ProjectScanResult();

            foreach (string file in EnumerateFiles(projectRoot, "*.uss"))
            {
                // Future:
                // Parse USS selectors
                // Detect class references
                // Detect renamed UI classes
                // Build dependency graph
            }

            return result;
        }

        /// <summary>
        /// Determines whether this scanner can process the supplied file.
        /// </summary>
        public override bool CanScan(string filePath)
        {
            return filePath.EndsWith(
                ".uss",
                StringComparison.OrdinalIgnoreCase);
        }
    }
}