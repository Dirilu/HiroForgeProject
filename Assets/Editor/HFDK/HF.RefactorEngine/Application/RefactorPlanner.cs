using System;
using System.Collections.Generic;
using System.Linq;

using HF.Refactor.Models;

namespace HF.Refactor.Engine
{
    /// <summary>
    /// Builds the execution plan for a refactor job.
    /// Responsible for ordering operations into a safe sequence.
    /// </summary>
    public sealed class RefactorPlanner
    {
        private readonly Logger _logger;

        public RefactorPlanner(Logger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Creates the execution plan for the supplied job.
        /// </summary>
        public void Build(RefactorJob job)
        {
            if (job == null)
                throw new ArgumentNullException(nameof(job));

            if (job.Operations == null)
                throw new InvalidOperationException(
                    "Job contains no operations.");

            _logger.Info("Building execution plan...");

            Sort(job);

            AssignExecutionOrder(job);

            _logger.Info(
                $"Execution plan created ({job.Operations.Count} operations).");
        }

        //----------------------------------------------------
        // Private Methods
        //----------------------------------------------------

        private static void Sort(RefactorJob job)
        {
            List<RefactorOperation> sorted = job.Operations
                .OrderBy(GetPriority)
                .ThenBy(x => x.FilePath)
                .ThenBy(x => x.Line)
                .ToList();

            job.Operations.Clear();
            job.Operations.AddRange(sorted);
        }

        private static void AssignExecutionOrder(
            RefactorJob job)
        {
            int order = 0;

            foreach (RefactorOperation operation in job.Operations)
            {
                operation.ExecutionOrder = ++order;
            }
        }

        private static int GetPriority(
            RefactorOperation operation)
        {
            switch (operation.Type)
            {
                case RefactorOperationType.Namespace:
                    return 10;

                case RefactorOperationType.Class:
                    return 20;

                case RefactorOperationType.Struct:
                    return 30;

                case RefactorOperationType.Interface:
                    return 40;

                case RefactorOperationType.Enum:
                    return 50;

                case RefactorOperationType.File:
                    return 60;

                case RefactorOperationType.Folder:
                    return 70;

                case RefactorOperationType.Asset:
                    return 80;

                case RefactorOperationType.String:
                    return 90;

                default:
                    return 999;
            }
        }
    }
}