using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using HF.Refactor.Models;

namespace HF.Refactor.Engine
{
    /// <summary>
    /// Restores the last completed refactor transaction.
    /// </summary>
    public sealed class RefactorUndoService
    {
        private readonly FileSystemService _fileSystem;
        private readonly Logger _logger;

        public RefactorUndoService(
            FileSystemService fileSystem,
            Logger logger)
        {
            _fileSystem = fileSystem ?? throw new ArgumentNullException(nameof(fileSystem));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Restores the most recent backup transaction.
        /// </summary>
        public void RestoreLast()
        {
            string backupFolder = GetLatestBackupFolder();

            if (string.IsNullOrWhiteSpace(backupFolder))
                throw new InvalidOperationException(
                    "No backup was found.");

            RestoreBackup(backupFolder);

            _logger.Info(
                $"Undo completed from '{backupFolder}'.");
        }

        //--------------------------------------------------------
        // Private
        //--------------------------------------------------------

        private string GetLatestBackupFolder()
        {
            string root = Path.Combine(
                Directory.GetCurrentDirectory(),
                ".hfrefactor",
                "Backups");

            if (!_fileSystem.DirectoryExists(root))
                return null;

            IEnumerable<string> folders =
                _fileSystem.GetDirectories(root)
                           .OrderByDescending(x => x);

            return folders.FirstOrDefault();
        }

        private void RestoreBackup(
            string backupFolder)
        {
            IEnumerable<string> files =
                _fileSystem.GetFiles(
                    backupFolder,
                    "*.*",
                    SearchOption.AllDirectories);

            foreach (string backupFile in files)
            {
                string relative =
                    GetRelativePath(
                        backupFolder,
                        backupFile);

                string destination =
                    Path.Combine(
                        Directory.GetCurrentDirectory(),
                        relative);

                _fileSystem.CopyFile(
                    backupFile,
                    destination);

                _logger.Info(
                    $"Restored {relative}");
            }
        }

        private static string GetRelativePath(
            string relativeTo,
            string path)
        {
            string from = Path.GetFullPath(relativeTo)
                .TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);

            string to = Path.GetFullPath(path);

            if (!to.StartsWith(from, StringComparison.OrdinalIgnoreCase))
                return to;

            if (to.Length == from.Length)
                return string.Empty;

            return to.Substring(from.Length)
                .TrimStart(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
        }
    }
}