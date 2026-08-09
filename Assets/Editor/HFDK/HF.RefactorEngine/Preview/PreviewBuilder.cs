using System;
using System.Collections.Generic;
using System.Linq;

using HF.Refactor.Models;

namespace HF.Refactor.Engine
{
    /// <summary>
    /// Builds a preview from a refactor job.
    /// The preview is UI-agnostic and can be rendered
    /// by Unity, CLI, Web, or AI clients.
    /// </summary>
    public sealed class PreviewBuilder
    {
        private readonly Logger _logger;

        public PreviewBuilder(
            Logger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Builds the preview collection.
        /// </summary>
        public void Build(
            RefactorJob job)
        {
            if (job == null)
                throw new ArgumentNullException(nameof(job));

            job.Preview.Clear();

            IEnumerable<IGrouping<string, RefactorOperation>> groups =
                job.Operations
                   .Where(x => x.Enabled)
                   .GroupBy(x => x.FilePath);

            foreach (IGrouping<string, RefactorOperation> group in groups)
            {
                PreviewFile previewFile = new PreviewFile
                {
                    FilePath = group.Key
                };

                foreach (RefactorOperation operation in group)
                {
                    previewFile.Items.Add(
                        new PreviewItem
                        {
                            Type = operation.Type,
                            Before = operation.Before,
                            After = operation.After,
                            Line = operation.Line
                        });
                }

                job.Preview.Add(previewFile);
            }

            _logger.Info(
                $"Preview built ({job.Preview.Count} files).");
        }
    }
}