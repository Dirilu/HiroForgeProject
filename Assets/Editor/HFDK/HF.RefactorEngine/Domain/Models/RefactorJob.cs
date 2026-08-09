using System;
using System.Collections.Generic;

namespace HF.Refactor.Models
{
    /// <summary>
    /// Represents a complete refactor transaction.
    /// Every stage of the pipeline operates on the same job.
    /// </summary>
    public sealed class RefactorJob
    {
        /// <summary>
        /// Unique identifier for this job.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Friendly name shown in the history.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Project root directory.
        /// </summary>
        public string ProjectRoot { get; set; }

        /// <summary>
        /// Search text.
        /// </summary>
        public string Find { get; set; }

        /// <summary>
        /// Replacement text.
        /// </summary>
        public string Replace { get; set; }

        /// <summary>
        /// Settings used for this execution.
        /// </summary>
        public RefactorSettings Settings { get; }

        /// <summary>
        /// Planned operations.
        /// </summary>
        public List<RefactorOperation> Operations { get; }

        /// <summary>
        /// Preview generated before execution.
        /// </summary>
        public List<PreviewFile> Preview { get; }

        /// <summary>
        /// Result after execution.
        /// </summary>
        public RefactorResult Result { get; set; }

        /// <summary>
        /// Creation time.
        /// </summary>
        public DateTime CreatedUtc { get; }

        /// <summary>
        /// Execution time.
        /// </summary>
        public DateTime? ExecutedUtc { get; set; }

        /// <summary>
        /// Indicates whether the job has completed.
        /// </summary>
        public bool IsCompleted { get; set; }

        public RefactorJob()
        {
            Id = Guid.NewGuid();

            Name = string.Empty;

            ProjectRoot = string.Empty;

            Find = string.Empty;

            Replace = string.Empty;

            Settings = new RefactorSettings();

            Operations = new List<RefactorOperation>();

            Preview = new List<PreviewFile>();

            Result = new RefactorResult();

            CreatedUtc = DateTime.UtcNow;
        }

        /// <summary>
        /// Clears generated data so the job can be rebuilt.
        /// </summary>
        public void Reset()
        {
            Operations.Clear();

            Preview.Clear();

            Result = new RefactorResult();

            ExecutedUtc = null;

            IsCompleted = false;
        }

        /// <summary>
        /// Marks the job as successfully completed.
        /// </summary>
        public void Complete()
        {
            ExecutedUtc = DateTime.UtcNow;

            IsCompleted = true;
        }
    }
}