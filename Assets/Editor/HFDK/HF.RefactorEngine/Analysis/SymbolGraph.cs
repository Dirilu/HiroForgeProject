using System;
using System.Collections.Generic;
using System.Linq;

namespace HF.Refactor.Analysis
{
    /// <summary>
    /// Represents every symbol discovered in the project
    /// and the relationships between them.
    /// </summary>
    public sealed class SymbolGraph
    {
        private readonly Dictionary<Guid, SymbolNode> _nodes;

        public IReadOnlyCollection<SymbolNode> Nodes
        {
            get { return _nodes.Values; }
        }

        public int Count
        {
            get { return _nodes.Count; }
        }

        public SymbolGraph()
        {
            _nodes = new Dictionary<Guid, SymbolNode>();
        }

        //--------------------------------------------------------
        // Nodes
        //--------------------------------------------------------

        public SymbolNode Add(SymbolNode node)
        {
            if (node == null)
                throw new ArgumentNullException(nameof(node));

            if (_nodes.ContainsKey(node.Id))
                return _nodes[node.Id];

            _nodes.Add(node.Id, node);

            return node;
        }

        public bool Remove(Guid id)
        {
            return _nodes.Remove(id);
        }

        public SymbolNode Find(Guid id)
        {
            _nodes.TryGetValue(id, out var node);

            return node;
        }

        public IEnumerable<SymbolNode> FindByName(string name)
        {
            return _nodes.Values.Where(x =>
                x.Name.Equals(name, StringComparison.Ordinal));
        }

        public IEnumerable<SymbolNode> FindByType(SymbolType type)
        {
            return _nodes.Values.Where(x => x.Type == type);
        }

        //--------------------------------------------------------
        // Relationships
        //--------------------------------------------------------

        public void Connect(
            SymbolNode source,
            SymbolNode target)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (target == null)
                throw new ArgumentNullException(nameof(target));

            source.AddReference(target);
        }

        public IEnumerable<SymbolNode> GetReferences(
            SymbolNode node)
        {
            if (node == null)
                throw new ArgumentNullException(nameof(node));

            return node.References;
        }

        public IEnumerable<SymbolNode> GetReferencedBy(
            SymbolNode node)
        {
            if (node == null)
                throw new ArgumentNullException(nameof(node));

            return _nodes.Values.Where(x => x.References.Contains(node));
        }
    }

    //------------------------------------------------------------
    // Symbol Node
    //------------------------------------------------------------

    public sealed class SymbolNode
    {
        private readonly List<SymbolNode> _references;

        public Guid Id { get; }

        public string Name { get; set; }

        public string Namespace { get; set; }

        public string FilePath { get; set; }

        public SymbolType Type { get; set; }

        public IReadOnlyList<SymbolNode> References
        {
            get { return _references; }
        }

        public SymbolNode()
        {
            Id = Guid.NewGuid();

            Name = string.Empty;

            Namespace = string.Empty;

            FilePath = string.Empty;

            _references = new List<SymbolNode>();
        }

        public void AddReference(SymbolNode node)
        {
            if (node == null)
                throw new ArgumentNullException(nameof(node));

            if (_references.Contains(node))
                return;

            _references.Add(node);
        }
    }

    //------------------------------------------------------------
    // Symbol Types
    //------------------------------------------------------------

    public enum SymbolType
    {
        Unknown,

        Namespace,

        Class,

        Struct,

        Interface,

        Enum,

        Method,

        Property,

        Field,

        Event,

        Delegate,

        Parameter,

        LocalVariable,

        ScriptableObject,

        MonoBehaviour,

        Prefab,

        Scene,

        Material,

        Texture,

        Sprite,

        AudioClip,

        Animation,

        Shader,

        Uxml,

        Uss,

        Json,

        AssemblyDefinition
    }
}