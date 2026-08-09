using System;
using System.Collections.Generic;

using HF.Refactor.Engine;
using HF.Refactor.Models;

namespace HF.Refactor.Analysis
{
    /// <summary>
    /// Builds a dependency graph for the project.
    /// Responsible for discovering relationships
    /// between scripts, assets, prefabs, scenes,
    /// UXML, USS and assembly definitions.
    /// </summary>
    public sealed class DependencyAnalyzer
    {
        private readonly Logger _logger;

        public DependencyAnalyzer(
            Logger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        //----------------------------------------------------
        // Public
        //----------------------------------------------------

        /// <summary>
        /// Builds a dependency graph from a refactor job.
        /// </summary>
        public DependencyGraph Analyze(
            RefactorJob job)
        {
            if (job == null)
                throw new ArgumentNullException(nameof(job));

            _logger.Info("Analyzing project dependencies...");

            DependencyGraph graph = new DependencyGraph();

            foreach (RefactorOperation operation in job.Operations)
            {
                graph.AddNode(
                    operation.FilePath,
                    operation.Type);

                AnalyzeOperation(
                    graph,
                    operation);
            }

            _logger.Info(
                $"Dependency graph contains {graph.NodeCount} node(s).");

            return graph;
        }

        //----------------------------------------------------
        // Private
        //----------------------------------------------------

        private void AnalyzeOperation(
            DependencyGraph graph,
            RefactorOperation operation)
        {
            if (string.IsNullOrWhiteSpace(operation.FilePath))
                return;

            // Future implementation:
            // - Parse C# using Roslyn
            // - Analyze prefab references
            // - Analyze scene references
            // - Analyze UXML / USS
            // - Analyze Assembly Definitions
        }
    }

    //--------------------------------------------------------
    // Dependency Graph
    //--------------------------------------------------------

    public sealed class DependencyGraph
    {
        private readonly Dictionary<string, DependencyNode> _nodes =
            new Dictionary<string, DependencyNode>(StringComparer.OrdinalIgnoreCase);

        public IReadOnlyCollection<DependencyNode> Nodes
        {
            get { return _nodes.Values; }
        }

        public int NodeCount
        {
            get { return _nodes.Count; }
        }

        public DependencyNode AddNode(
            string path,
            RefactorOperationType type)
        {
            if (_nodes.TryGetValue(path, out DependencyNode existing))
                return existing;

            DependencyNode node =
                new DependencyNode(path, type);

            _nodes.Add(path, node);

            return node;
        }

        public bool Contains(
            string path)
        {
            return _nodes.ContainsKey(path);
        }

        public DependencyNode Find(
            string path)
        {
            _nodes.TryGetValue(path, out DependencyNode node);

            return node;
        }
    }

    //--------------------------------------------------------
    // Dependency Node
    //--------------------------------------------------------

    public sealed class DependencyNode
    {
        private readonly List<DependencyNode> _dependencies =
            new List<DependencyNode>();

        public string Path { get; }

        public RefactorOperationType Type { get; }

        public IReadOnlyList<DependencyNode> Dependencies
        {
            get { return _dependencies; }
        }

        public DependencyNode(
            string path,
            RefactorOperationType type)
        {
            Path = path;

            Type = type;
        }

        public void AddDependency(
            DependencyNode node)
        {
            if (node == null)
                throw new ArgumentNullException(nameof(node));

            if (_dependencies.Contains(node))
                return;

            _dependencies.Add(node);
        }
    }
}