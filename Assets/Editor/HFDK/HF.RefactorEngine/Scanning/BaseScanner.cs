using System;
using System.Collections.Generic;
using System.IO;

namespace HF.Refactor.Scanning
{
    /// <summary>
    /// Base class for all project scanners.
    /// Handles directory traversal and ignored folders.
    /// </summary>
    public abstract class BaseScanner : IProjectScanner
    {
        public abstract string Name { get; }

        public abstract IReadOnlyList<string> SupportedExtensions { get; }

        public abstract ProjectScanResult Scan(string projectRoot);

        public abstract bool CanScan(string filePath);

        //--------------------------------------------------------
        // Helper Methods
        //--------------------------------------------------------

        protected IEnumerable<string> EnumerateFiles(
            string projectRoot,
            string searchPattern)
        {
            if (string.IsNullOrWhiteSpace(projectRoot))
                throw new ArgumentException(
                    "Project path cannot be empty.",
                    nameof(projectRoot));

            if (!Directory.Exists(projectRoot))
                yield break;

            foreach (string file in EnumerateDirectory(
                projectRoot,
                searchPattern))
            {
                yield return file;
            }
        }

        private IEnumerable<string> EnumerateDirectory(
            string directory,
            string searchPattern)
        {
            foreach (string file in Directory.GetFiles(directory, searchPattern))
            {
                yield return file;
            }

            foreach (string child in Directory.GetDirectories(directory))
            {
                string folder = Path.GetFileName(child);

                if (ShouldIgnore(folder))
                    continue;

                foreach (string file in EnumerateDirectory(
                    child,
                    searchPattern))
                {
                    yield return file;
                }
            }
        }

        protected virtual bool ShouldIgnore(string folder)
        {
            switch (folder)
            {
                case "Library":
                case "Logs":
                case "Temp":
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