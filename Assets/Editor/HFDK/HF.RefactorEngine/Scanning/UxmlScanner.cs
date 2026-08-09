using System;
using System.Collections.Generic;
using System.IO;

namespace HF.Refactor.Scanning
{
    /// <summary>
    /// Scans a Unity project for UXML files.
    /// </summary>
    public sealed class UxmlScanner : IProjectScanner
    {
        public string Name
        {
            get { return "UXML Scanner"; }
        }

        public IReadOnlyList<string> SupportedExtensions
        {
            get
            {
                return new[]
                {
                    ".uxml"
                };
            }
        }

        public ProjectScanResult Scan(string projectRoot)
        {
            if (string.IsNullOrWhiteSpace(projectRoot))
                throw new ArgumentException(
                    "Project path cannot be empty.",
                    nameof(projectRoot));

            ProjectScanResult result =
                new ProjectScanResult();

            ScanDirectory(projectRoot, result);

            return result;
        }

        public bool CanScan(string filePath)
        {
            return filePath.EndsWith(
                ".uxml",
                StringComparison.OrdinalIgnoreCase);
        }

        //--------------------------------------------------------
        // Private
        //--------------------------------------------------------

        private void ScanDirectory(
            string directory,
            ProjectScanResult result)
        {
            foreach (string file in Directory.GetFiles(directory, "*.uxml"))
            {
                // Placeholder for future UXML analysis.
            }

            foreach (string child in Directory.GetDirectories(directory))
            {
                string folder = Path.GetFileName(child);

                if (ShouldIgnore(folder))
                    continue;

                ScanDirectory(child, result);
            }
        }

        private bool ShouldIgnore(string folder)
        {
            switch (folder)
            {
                case "Library":
                case "Temp":
                case "Logs":
                case "Obj":
                case ".git":
                case ".vs":
                    return true;

                default:
                    return false;
            }
        }
    }
}