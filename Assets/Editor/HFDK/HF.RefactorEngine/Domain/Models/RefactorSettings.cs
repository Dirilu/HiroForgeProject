using System.Collections.Generic;

namespace HF.Refactor.Models
{
    /// <summary>
    /// Defines all configurable options used by the refactor engine.
    /// A single instance of this class travels with every RefactorJob.
    /// </summary>
    public sealed class RefactorSettings
    {
        //----------------------------------------------------
        // Preview
        //----------------------------------------------------

        /// <summary>
        /// Build a preview before execution.
        /// </summary>
        public bool GeneratePreview { get; set; } = true;

        /// <summary>
        /// Validate the project before execution.
        /// </summary>
        public bool ValidateBeforeExecute { get; set; } = true;

        //----------------------------------------------------
        // Backup
        //----------------------------------------------------

        /// <summary>
        /// Automatically create backups.
        /// </summary>
        public bool CreateBackup { get; set; } = true;

        /// <summary>
        /// Keep backup history.
        /// </summary>
        public bool KeepBackupHistory { get; set; } = true;

        //----------------------------------------------------
        // Execution
        //----------------------------------------------------

        /// <summary>
        /// Stop execution after the first error.
        /// </summary>
        public bool StopOnFirstError { get; set; } = true;

        /// <summary>
        /// Continue processing remaining operations after an error.
        /// </summary>
        public bool ContinueOnError { get; set; }

        /// <summary>
        /// Refresh Unity AssetDatabase after execution.
        /// </summary>
        public bool RefreshAssetDatabase { get; set; } = true;

        //----------------------------------------------------
        // Unity
        //----------------------------------------------------

        /// <summary>
        /// Scan C# files.
        /// </summary>
        public bool ScanCSharp { get; set; } = true;

        /// <summary>
        /// Scan UXML files.
        /// </summary>
        public bool ScanUxml { get; set; } = true;

        /// <summary>
        /// Scan USS files.
        /// </summary>
        public bool ScanUss { get; set; } = true;

        /// <summary>
        /// Scan Assembly Definition files.
        /// </summary>
        public bool ScanAssemblyDefinitions { get; set; } = true;

        /// <summary>
        /// Scan JSON files.
        /// </summary>
        public bool ScanJson { get; set; } = true;

        //----------------------------------------------------
        // Rename
        //----------------------------------------------------

        public bool RenameNamespaces { get; set; } = true;

        public bool RenameClasses { get; set; } = true;

        public bool RenameStructs { get; set; } = true;

        public bool RenameInterfaces { get; set; } = true;

        public bool RenameEnums { get; set; } = true;

        public bool RenameFiles { get; set; } = true;

        public bool RenameFolders { get; set; } = true;

        public bool RenameAssets { get; set; } = true;

        //----------------------------------------------------
        // Ignore
        //----------------------------------------------------

        /// <summary>
        /// Folder names that should never be scanned.
        /// </summary>
        public HashSet<string> IgnoredFolders { get; }

        /// <summary>
        /// File extensions that should be scanned.
        /// </summary>
        public HashSet<string> SupportedExtensions { get; }

        //----------------------------------------------------
        // Constructor
        //----------------------------------------------------

        public RefactorSettings()
        {
            IgnoredFolders = new HashSet<string>
            {
                "Library",
                "Temp",
                "Logs",
                "Obj",
                ".git",
                ".vs"
            };

            SupportedExtensions = new HashSet<string>
            {
                ".cs",
                ".uxml",
                ".uss",
                ".asmdef",
                ".json"
            };
        }

        //----------------------------------------------------
        // Helpers
        //----------------------------------------------------

        public bool IsIgnoredFolder(string folderName)
        {
            return IgnoredFolders.Contains(folderName);
        }

        public bool IsSupportedExtension(string extension)
        {
            return SupportedExtensions.Contains(extension);
        }
    }
}