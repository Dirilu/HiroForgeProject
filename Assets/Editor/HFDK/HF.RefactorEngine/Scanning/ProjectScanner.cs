using System;
using System.Collections.Generic;

namespace HF.Refactor.Scanning
{
    /// <summary>
    /// Coordinates all scanners within the project.
    /// </summary>
    public sealed class ProjectScanner
    {
        private readonly CSharpScanner _csharpScanner;

        public ProjectScanner()
        {
            _csharpScanner = new CSharpScanner();
        }

        /// <summary>
        /// Scans the project using every registered scanner.
        /// </summary>
        public ProjectScanResult Scan(string projectRoot)
        {
            if (string.IsNullOrWhiteSpace(projectRoot))
                throw new ArgumentException(
                    "Project path cannot be empty.",
                    nameof(projectRoot));

            ProjectScanResult result = new ProjectScanResult();

            //--------------------------------------------------
            // C#
            //--------------------------------------------------

            IReadOnlyList<CSharpFile> csharpFiles =
                _csharpScanner.Scan(projectRoot);

            result.CSharpFiles.AddRange(csharpFiles);

            //--------------------------------------------------
            // Future scanners
            //--------------------------------------------------

            // result.UxmlFiles.AddRange(...);
            // result.UssFiles.AddRange(...);
            // result.JsonFiles.AddRange(...);
            // result.SceneFiles.AddRange(...);
            // result.PrefabFiles.AddRange(...);

            return result;
        }
    }

    //----------------------------------------------------------
    // Scan Result
    //----------------------------------------------------------

    public sealed class ProjectScanResult
    {
        public List<CSharpFile> CSharpFiles { get; }

        public int TotalFiles
        {
            get
            {
                return CSharpFiles.Count;
            }
        }

        public bool IsEmpty
        {
            get
            {
                return TotalFiles == 0;
            }
        }

        public ProjectScanResult()
        {
            CSharpFiles = new List<CSharpFile>();
        }
    }
}