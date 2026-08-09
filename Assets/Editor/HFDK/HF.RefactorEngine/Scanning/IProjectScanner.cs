using System.Collections.Generic;

namespace HF.Refactor.Scanning
{
    /// <summary>
    /// Base interface implemented by every project scanner.
    /// </summary>
    public interface IProjectScanner
    {
        /// <summary>
        /// Friendly name of the scanner.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// File extensions this scanner supports.
        /// Example:
        /// .cs
        /// .uxml
        /// .uss
        /// </summary>
        IReadOnlyList<string> SupportedExtensions { get; }

        /// <summary>
        /// Scans the supplied project.
        /// </summary>
        ProjectScanResult Scan(string projectRoot);

        /// <summary>
        /// Returns true if this scanner can scan the supplied file.
        /// </summary>
        bool CanScan(string filePath);
    }
}