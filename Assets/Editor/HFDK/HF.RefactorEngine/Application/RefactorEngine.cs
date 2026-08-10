using System;

using HF.Refactor.Models;

namespace HF.Refactor.Engine
{
    /// <summary>
    /// Main entry point for every refactor operation.
    /// This class coordinates the complete refactor pipeline.
    /// </summary>
    public sealed class RefactorEngine
    {
        private readonly RefactorScanner _scanner;
        private readonly RefactorValidator _validator;
        private readonly RefactorPlanner _planner;
        private readonly PreviewBuilder _previewBuilder;
        private readonly RefactorBackupService _backupService;
        private readonly RefactorExecutor _executor;
        private readonly RefactorUndoService _undoService;
        private readonly Logger _logger;

        /// <summary>
        /// Creates a new Refactor Engine using the supplied services.
        /// </summary>
        public RefactorEngine(
            RefactorScanner scanner,
            RefactorValidator validator,
            RefactorPlanner planner,
            PreviewBuilder previewBuilder,
            RefactorBackupService backupService,
            RefactorExecutor executor,
            RefactorUndoService undoService,
            Logger logger)
        {
            _scanner = scanner ?? throw new ArgumentNullException(nameof(scanner));
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
            _planner = planner ?? throw new ArgumentNullException(nameof(planner));
            _previewBuilder = previewBuilder ?? throw new ArgumentNullException(nameof(previewBuilder));
            _backupService = backupService ?? throw new ArgumentNullException(nameof(backupService));
            _executor = executor ?? throw new ArgumentNullException(nameof(executor));
            _undoService = undoService ?? throw new ArgumentNullException(nameof(undoService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Creates a complete preview without modifying the project.
        /// </summary>
        public RefactorResult Preview(RefactorJob job)
        {
            if (job == null)
                throw new ArgumentNullException(nameof(job));

            _logger.Info("Starting preview...");

            _scanner.Scan(job);

            _validator.Validate(job);

            _planner.Build(job);

            _previewBuilder.Build(job);

            _logger.Info("Preview completed.");

            return RefactorResult.CreateSuccess(job);
        }

        /// <summary>
        /// Executes the refactor operation.
        /// </summary>
        public RefactorResult Execute(RefactorJob job)
        {
            if (job == null)
                throw new ArgumentNullException(nameof(job));

            _logger.Info("Executing refactor...");

            _validator.Validate(job);

            _backupService.Create(job);

            _planner.Build(job);

            _executor.Execute(job);

            _logger.Info("Refactor completed.");

            return RefactorResult.CreateSuccess(job);
        }

        /// <summary>
        /// Restores the last refactor transaction.
        /// </summary>
        public RefactorResult Undo()
        {
            _logger.Info("Undo requested.");

            _undoService.RestoreLast();

            return RefactorResult.CreateSuccess();
        }

        /// <summary>
        /// Validates a job without scanning or executing.
        /// </summary>
        public RefactorResult Validate(RefactorJob job)
        {
            if (job == null)
                throw new ArgumentNullException(nameof(job));

            _validator.Validate(job);

            return RefactorResult.CreateSuccess(job);
        }
    }
}