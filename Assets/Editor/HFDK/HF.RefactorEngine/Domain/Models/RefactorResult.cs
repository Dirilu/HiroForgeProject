using System;
using System.Collections.Generic;
using System.Linq;

namespace HF.Refactor.Models
{
    /// <summary>
    /// Represents the outcome of a refactor operation.
    /// </summary>
    public sealed class RefactorResult
    {
        //-----------------------------------------------------
        // Status
        //-----------------------------------------------------

        /// <summary>
        /// True if the operation completed successfully.
        /// </summary>
        public bool Success { get; private set; }

        /// <summary>
        /// Summary message.
        /// </summary>
        public string Message { get; private set; }

        //-----------------------------------------------------
        // Statistics
        //-----------------------------------------------------

        /// <summary>
        /// Total operations discovered.
        /// </summary>
        public int TotalOperations { get; private set; }

        /// <summary>
        /// Operations executed successfully.
        /// </summary>
        public int CompletedOperations { get; private set; }

        /// <summary>
        /// Operations skipped.
        /// </summary>
        public int SkippedOperations { get; private set; }

        /// <summary>
        /// Operations that failed.
        /// </summary>
        public int FailedOperations { get; private set; }

        //-----------------------------------------------------
        // Errors & Warnings
        //-----------------------------------------------------

        public List<string> Errors { get; }

        public List<string> Warnings { get; }

        //-----------------------------------------------------
        // Timing
        //-----------------------------------------------------

        public DateTime StartedUtc { get; }

        public DateTime FinishedUtc { get; private set; }

        public TimeSpan Duration =>
            FinishedUtc - StartedUtc;

        //-----------------------------------------------------
        // Constructor
        //-----------------------------------------------------

        public RefactorResult()
        {
            Success = false;

            Message = string.Empty;

            Errors = new List<string>();

            Warnings = new List<string>();

            StartedUtc = DateTime.UtcNow;

            FinishedUtc = StartedUtc;
        }

        //-----------------------------------------------------
        // Factory Methods
        //-----------------------------------------------------

        public static RefactorResult Success()
        {
            return new RefactorResult
            {
                Success = true,
                Message = "Operation completed successfully.",
                FinishedUtc = DateTime.UtcNow
            };
        }

        public static RefactorResult Success(
            RefactorJob job)
        {
            if (job == null)
                throw new ArgumentNullException(nameof(job));

            return new RefactorResult
            {
                Success = true,
                Message = "Operation completed successfully.",
                TotalOperations = job.Operations.Count,
                CompletedOperations = job.Operations.Count(x => x.Executed),
                FailedOperations = job.Operations.Count(x => !x.Executed && !string.IsNullOrWhiteSpace(x.Error)),
                SkippedOperations = job.Operations.Count(x => !x.Enabled),
                FinishedUtc = DateTime.UtcNow
            };
        }

        public static RefactorResult Failure(
            string message)
        {
            var result = new RefactorResult
            {
                Success = false,
                Message = message,
                FinishedUtc = DateTime.UtcNow
            };

            result.Errors.Add(message);

            return result;
        }

        //-----------------------------------------------------
        // Helpers
        //-----------------------------------------------------

        public void AddWarning(
            string warning)
        {
            if (!string.IsNullOrWhiteSpace(warning))
            {
                Warnings.Add(warning);
            }
        }

        public void AddError(
            string error)
        {
            if (!string.IsNullOrWhiteSpace(error))
            {
                Errors.Add(error);

                Success = false;
            }
        }

        public override string ToString()
        {
            return $"{CompletedOperations}/{TotalOperations} operations completed.";
        }
    }
}
