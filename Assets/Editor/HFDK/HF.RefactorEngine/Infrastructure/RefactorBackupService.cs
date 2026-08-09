using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using HF.Refactor.Models;

namespace HF.Refactor.Engine
{
    /// <summary>
    /// Creates a complete backup of every file that will be
    /// modified during a refactor operation.
    /// </summary>
    public sealed class RefactorBackupService
    {
        private readonly FileSystemService _fileSystem;
        private readonly Logger _logger;

        public RefactorBackupService(
            FileSystemService fileSystem,
            Logger logger)
        {
            _fileSystem = fileSystem ?? throw new ArgumentNullException(nameof(fileSystem));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Creates a timestamped backup for the supplied job.
        /// </summary>
        public void Create(RefactorJob job)
        {
            if (job == null)
                throw new ArgumentNullException(nameof(job));

            string backupFolder = CreateBackupFolder(job);

            IEnumerable<string> files =
                job.Operations
                   .Where(x => x.Enabled)
                   .Select(x => x.FilePath)
                   .Distinct();

            foreach (string file in files)
            {
                BackupFile(file, backupFolder);
            }

            _logger.Info(
                $"Backup completed ({files.Count()} file(s)).");
        }

        //--------------------------------------------------------
        // Private
        //--------------------------------------------------------

        private string CreateBackupFolder(
            RefactorJob job)
        {
            string folder = Path.Combine(
                job.ProjectRoot,
                ".hfrefactor",
                "Backups",
                DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));

            _fileSystem.CreateDirectory(folder);

            return folder;
        }

        private void BackupFile(
            string sourceFile,
            string backupFolder)
        {
            if (!_fileSystem.FileExists(sourceFile))
                return;

            string destination = Path.Combine(
                backupFolder,
                Path.GetFileName(sourceFile));

            _fileSystem.CopyFile(
                sourceFile,
                destination);

            _logger.Info(
                $"Backed up {Path.GetFileName(sourceFile)}");
        }
    }
}