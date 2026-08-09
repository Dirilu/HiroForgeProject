using System;
using System.Collections.Generic;
using System.Linq;

using HF.Refactor.Models;

namespace HF.Refactor.Engine
{
    /// <summary>
    /// Executes a planned refactor transaction.
    /// This class performs no planning or validation.
    /// It simply executes operations in the order supplied.
    /// </summary>
    public sealed class RefactorExecutor
    {
        private readonly FileSystemService _fileSystem;
        private readonly Logger _logger;

        public RefactorExecutor(
            FileSystemService fileSystem,
            Logger logger)
        {
            _fileSystem = fileSystem ?? throw new ArgumentNullException(nameof(fileSystem));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Executes all operations contained within the job.
        /// </summary>
        public void Execute(RefactorJob job)
        {
            if (job == null)
                throw new ArgumentNullException(nameof(job));

            _logger.Info("Starting execution...");

            IEnumerable<RefactorOperation> operations =
                job.Operations
                    .Where(x => x.Enabled)
                    .OrderBy(x => x.ExecutionOrder);

            foreach (RefactorOperation operation in operations)
            {
                ExecuteOperation(operation);
            }

            _logger.Info("Execution completed.");
        }

        //--------------------------------------------------------
        // Private
        //--------------------------------------------------------

        private void ExecuteOperation(
            RefactorOperation operation)
        {
            switch (operation.Type)
            {
                case RefactorOperationType.Namespace:
                    RenameNamespace(operation);
                    break;

                case RefactorOperationType.Class:
                    RenameClass(operation);
                    break;

                case RefactorOperationType.Struct:
                    RenameStruct(operation);
                    break;

                case RefactorOperationType.Interface:
                    RenameInterface(operation);
                    break;

                case RefactorOperationType.Enum:
                    RenameEnum(operation);
                    break;

                case RefactorOperationType.File:
                    RenameFile(operation);
                    break;

                case RefactorOperationType.Folder:
                    RenameFolder(operation);
                    break;

                case RefactorOperationType.Asset:
                    RenameAsset(operation);
                    break;

                case RefactorOperationType.String:
                    ReplaceString(operation);
                    break;

                default:
                    throw new NotSupportedException(
                        $"Unsupported operation type: {operation.Type}");
            }
        }

        //--------------------------------------------------------
        // Operation Types
        //--------------------------------------------------------

        private void RenameNamespace(RefactorOperation operation)
        {
            _fileSystem.ReplaceText(
                operation.FilePath,
                operation.Before,
                operation.After);
        }

        private void RenameClass(RefactorOperation operation)
        {
            _fileSystem.ReplaceText(
                operation.FilePath,
                operation.Before,
                operation.After);
        }

        private void RenameStruct(RefactorOperation operation)
        {
            _fileSystem.ReplaceText(
                operation.FilePath,
                operation.Before,
                operation.After);
        }

        private void RenameInterface(RefactorOperation operation)
        {
            _fileSystem.ReplaceText(
                operation.FilePath,
                operation.Before,
                operation.After);
        }

        private void RenameEnum(RefactorOperation operation)
        {
            _fileSystem.ReplaceText(
                operation.FilePath,
                operation.Before,
                operation.After);
        }

        private void RenameFile(RefactorOperation operation)
        {
            _fileSystem.RenameFile(
                operation.FilePath,
                operation.After);
        }

        private void RenameFolder(RefactorOperation operation)
        {
            _fileSystem.RenameDirectory(
                operation.FilePath,
                operation.After);
        }

        private void RenameAsset(RefactorOperation operation)
        {
            _fileSystem.RenameFile(
                operation.FilePath,
                operation.After);
        }

        private void ReplaceString(RefactorOperation operation)
        {
            _fileSystem.ReplaceText(
                operation.FilePath,
                operation.Before,
                operation.After);
        }
    }
}