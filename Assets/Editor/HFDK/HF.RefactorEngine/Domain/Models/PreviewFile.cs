using System.Collections.Generic;

namespace HF.Refactor.Models
{
    /// <summary>
    /// Represents the preview of all changes that will
    /// occur inside a single file.
    /// </summary>
    public sealed class PreviewFile
    {
        /// <summary>
        /// Project-relative file path.
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// Preview items for this file.
        /// </summary>
        public List<PreviewItem> Items { get; }

        public PreviewFile()
        {
            FilePath = string.Empty;
            Items = new List<PreviewItem>();
        }

        /// <summary>
        /// Adds a preview item.
        /// </summary>
        public void Add(PreviewItem item)
        {
            if (item == null)
                return;

            Items.Add(item);
        }

        /// <summary>
        /// Removes a preview item.
        /// </summary>
        public bool Remove(PreviewItem item)
        {
            if (item == null)
                return false;

            return Items.Remove(item);
        }

        /// <summary>
        /// Removes every preview item.
        /// </summary>
        public void Clear()
        {
            Items.Clear();
        }

        /// <summary>
        /// Number of preview items.
        /// </summary>
        public int Count
        {
            get { return Items.Count; }
        }

        /// <summary>
        /// Returns true if no preview items exist.
        /// </summary>
        public bool IsEmpty
        {
            get { return Items.Count == 0; }
        }

        public override string ToString()
        {
            return $"{FilePath} ({Items.Count} changes)";
        }
    }
}