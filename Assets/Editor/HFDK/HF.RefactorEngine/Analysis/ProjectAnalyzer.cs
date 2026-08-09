using System;
using System.Linq;

using HF.Refactor.Engine;
using HF.Refactor.Models;

namespace HF.Refactor.Analysis
{
    /// <summary>
    /// Performs a complete analysis of a project and builds
    /// a unified model used throughout HF.RefactorEngine.
    /// </summary>
    public sealed class ProjectAnalyzer
    {
        private readonly DependencyAnalyzer _dependencyAnalyzer;
        private readonly SymbolGraph _symbolGraph;
        private readonly Logger _logger;

        public ProjectAnalyzer(
            DependencyAnalyzer dependencyAnalyzer,
            SymbolGraph symbolGraph,
            Logger logger)
        {
            _dependencyAnalyzer = dependencyAnalyzer
                ?? throw new ArgumentNullException(nameof(dependencyAnalyzer));

            _symbolGraph = symbolGraph
                ?? throw new ArgumentNullException(nameof(symbolGraph));

            _logger = logger
                ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Performs a full project analysis.
        /// </summary>
        public ProjectAnalysis Analyze(RefactorJob job)
        {
            if (job == null)
                throw new ArgumentNullException(nameof(job));

            _logger.Info("Starting project analysis...");

            DependencyGraph dependencyGraph =
                _dependencyAnalyzer.Analyze(job);

            ProjectAnalysis analysis = new ProjectAnalysis
            {
                DependencyGraph = dependencyGraph,
                SymbolGraph = _symbolGraph,
                TotalFiles = job.Operations
                    .Select(o => o.FilePath)
                    .Where(path => !string.IsNullOrWhiteSpace(path))
                    .Distinct(StringComparer.OrdinalIgnoreCase)
                    .Count(),
                TotalOperations = job.Operations.Count,
                GeneratedUtc = DateTime.UtcNow
            };

            _logger.Info("Project analysis completed.");

            return analysis;
        }
    }

    /// <summary>
    /// Represents the result of a complete project analysis.
    /// </summary>
    public sealed class ProjectAnalysis
    {
        public DependencyGraph DependencyGraph { get; set; }

        public SymbolGraph SymbolGraph { get; set; }

        public int TotalFiles { get; set; }

        public int TotalOperations { get; set; }

        public DateTime GeneratedUtc { get; set; }

        public bool IsEmpty
        {
            get
            {
                return TotalFiles == 0;
            }
        }

        public override string ToString()
        {
            return $"Files: {TotalFiles}, Operations: {TotalOperations}";
        }
    }
}