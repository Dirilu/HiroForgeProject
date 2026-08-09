using System;
using System.Collections.Generic;
using System.Linq;

using HF.Refactor.Models;

namespace HF.Refactor.Preview
{
    /// <summary>
    /// Builds a visual diff from a refactor job.
    /// This class is UI-independent and simply converts
    /// refactor operations into diff entries.
    /// </summary>
    public sealed class DiffBuilder
    {
        /// <summary>
        /// Builds a diff from the supplied job.
        /// </summary>
        public DiffResult Build(RefactorJob job)
        {
            if (job == null)
                throw new ArgumentNullException(nameof(job));

            DiffResult result = new DiffResult();

            foreach (RefactorOperation operation in job.Operations
                         .Where(o => o.Enabled)
                         .OrderBy(o => o.ExecutionOrder))
            {
                result.Items.Add(new DiffItem
                {
                    FilePath = operation.FilePath,
                    Line = operation.Line,
                    Before = operation.Before,
                    After = operation.After,
                    Type = operation.Type
                });
            }

            return result;
        }
    }

    //--------------------------------------------------------
    // Diff Result
    //--------------------------------------------------------

    public sealed class DiffResult
    {
        public List<DiffItem> Items { get; }

        public DiffResult()
        {
            Items = new List<DiffItem>();
        }

        public int Count
        {
            get { return Items.Count; }
        }

        public bool IsEmpty
        {
            get { return Items.Count == 0; }
        }
    }

    //--------------------------------------------------------
    // Diff Item
    //--------------------------------------------------------

    public sealed class DiffItem
    {
        public string FilePath { get; set; }

        public int Line { get; set; }

        public string Before { get; set; }

        public string After { get; set; }

        public RefactorOperationType Type { get; set; }

        public DiffItem()
        {
            FilePath = string.Empty;
            Before = string.Empty;
            After = string.Empty;
        }

        public override string ToString()
        {
            return $"{FilePath} ({Line}) : {Before} -> {After}";
        }
    }
}