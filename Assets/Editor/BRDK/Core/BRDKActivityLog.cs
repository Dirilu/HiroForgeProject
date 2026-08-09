using System.Collections.Generic;
using UnityEngine;

namespace BRDK.Core
{
    public static class BRDKActivityLog
    {
        private static readonly List<string> _entries = new List<string>();

        public static IReadOnlyList<string> Entries => _entries;

        public static void Add(string message)
        {
            _entries.Insert(0, $"{System.DateTime.Now:HH:mm:ss}  {message}");

            // Keep only the latest 20 entries
            if (_entries.Count > 20)
                _entries.RemoveAt(_entries.Count - 1);

            Debug.Log("[BRDK] " + message);
        }

        public static void Clear()
        {
            _entries.Clear();
        }
    }
}