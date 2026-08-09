using System;
using System.Collections.Generic;

using HF.Refactor.Models;

namespace HF.Refactor.Engine
{
    /// <summary>
    /// Coordinates all project scanners and populates
    /// a RefactorJob with discovered operations.
    /// </summary>
    public sealed class RefactorScanner
    {
        private readonly IReadOnlyList<IProjectScanner> _scanners;
        private readonly Logger _logger;

        public RefactorScanner(
            IReadOnlyList<IProjectScanner> scanners,
            Logger logger)
        {
            _scanners = scanners ?? throw new ArgumentNullException(nameof(scanners));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Scans the project using every registered scanner.
        /// </summary>
        public void Scan(RefactorJob job)
        {
            if (job == null)
                throw new ArgumentNullException(nameof(job));

            job.Operations.Clear();

            _logger.Info("Scanning project...");

            foreach (IProjectScanner scanner in _scanners)
            {
                scanner.Scan(job);
            }

            _logger.Info(
                $"Scanner found {job.Operations.Count} operation(s).");
        }
    }

    /// <summary>
    /// Base interface implemented by every project scanner.
    /// </summary>
    public interface IProjectScanner
    {
        /// <summary>
        /// Scans the project and adds operations to the job.
        /// </summary>
        void Scan(RefactorJob job);
    }
}