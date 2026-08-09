using System;
using System.Collections.Generic;
using System.Linq;

namespace HF.Refactor.Models
{
    /// <summary>
    /// Stores completed refactor jobs and provides
    /// history management for undo, audit and reporting.
    /// </summary>
    public sealed class RefactorHistory
    {
        //----------------------------------------------------
        // Properties
        //----------------------------------------------------

        /// <summary>
        /// Completed refactor jobs.
        /// </summary>
        public List<RefactorJob> Jobs { get; }

        /// <summary>
        /// Maximum number of history entries.
        /// </summary>
        public int Capacity { get; set; }

        //----------------------------------------------------
        // Constructor
        //----------------------------------------------------

        public RefactorHistory()
        {
            Jobs = new List<RefactorJob>();
            Capacity = 100;
        }

        //----------------------------------------------------
        // Public Methods
        //----------------------------------------------------

        /// <summary>
        /// Adds a completed job to the history.
        /// </summary>
        public void Add(RefactorJob job)
        {
            if (job == null)
                throw new ArgumentNullException(nameof(job));

            Jobs.Add(job);

            Trim();
        }

        /// <summary>
        /// Removes every history entry.
        /// </summary>
        public void Clear()
        {
            Jobs.Clear();
        }

        /// <summary>
        /// Returns the most recently completed job.
        /// Returns null if no jobs exist.
        /// </summary>
        public RefactorJob GetLatest()
        {
            return Jobs
                .OrderByDescending(x => x.ExecutedUtc)
                .FirstOrDefault();
        }

        /// <summary>
        /// Finds a job by its identifier.
        /// Returns null if not found.
        /// </summary>
        public RefactorJob Find(Guid id)
        {
            return Jobs.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Removes a job from the history.
        /// </summary>
        public bool Remove(Guid id)
        {
            RefactorJob job = Find(id);

            if (job == null)
                return false;

            return Jobs.Remove(job);
        }

        //----------------------------------------------------
        // Statistics
        //----------------------------------------------------

        public int Count
        {
            get { return Jobs.Count; }
        }

        public bool IsEmpty
        {
            get { return Jobs.Count == 0; }
        }

        //----------------------------------------------------
        // Private
        //----------------------------------------------------

        private void Trim()
        {
            while (Jobs.Count > Capacity)
            {
                Jobs.RemoveAt(0);
            }
        }
    }
}