using System;
using System.Collections.Generic;
using System.Linq;

namespace HF.Refactor.Scanning
{
    /// <summary>
    /// Stores all registered project scanners.
    /// </summary>
    public sealed class ScannerRegistry
    {
        private readonly List<IProjectScanner> _scanners;

        public ScannerRegistry()
        {
            _scanners = new List<IProjectScanner>();
        }

        /// <summary>
        /// All registered scanners.
        /// </summary>
        public IReadOnlyList<IProjectScanner> Scanners
        {
            get { return _scanners; }
        }

        /// <summary>
        /// Registers a scanner.
        /// </summary>
        public void Register(IProjectScanner scanner)
        {
            if (scanner == null)
                throw new ArgumentNullException(nameof(scanner));

            if (_scanners.Any(s => s.Name == scanner.Name))
                return;

            _scanners.Add(scanner);
        }

        /// <summary>
        /// Removes a scanner.
        /// </summary>
        public bool Unregister(string name)
        {
            IProjectScanner scanner = _scanners
                .FirstOrDefault(s => s.Name == name);

            if (scanner == null)
                return false;

            return _scanners.Remove(scanner);
        }

        /// <summary>
        /// Finds a scanner by name.
        /// </summary>
        public IProjectScanner Find(string name)
        {
            return _scanners.FirstOrDefault(s => s.Name == name);
        }

        /// <summary>
        /// Returns all scanners that support a file extension.
        /// </summary>
        public IEnumerable<IProjectScanner> FindByExtension(string extension)
        {
            return _scanners.Where(scanner =>
                scanner.SupportedExtensions.Contains(extension));
        }

        /// <summary>
        /// Removes every scanner.
        /// </summary>
        public void Clear()
        {
            _scanners.Clear();
        }

        /// <summary>
        /// Number of registered scanners.
        /// </summary>
        public int Count
        {
            get { return _scanners.Count; }
        }
    }
}