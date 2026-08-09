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
            job.Operations = job.Operations
                .OrderBy(GetPriority)
                .ThenBy(x => x.FilePath)
                .ThenBy(x => x.Line)
                .ToList();
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
            return operation.Type switch
            {
                RefactorOperationType.Namespace => 10,

                RefactorOperationType.Class => 20,

                RefactorOperationType.Struct => 30,

                RefactorOperationType.Interface => 40,

                RefactorOperationType.Enum => 50,

                RefactorOperationType.File => 60,

                RefactorOperationType.Folder => 70,

                RefactorOperationType.Asset => 80,

                RefactorOperationType.String => 90,

                _ => 999
            };
        }
    }
}