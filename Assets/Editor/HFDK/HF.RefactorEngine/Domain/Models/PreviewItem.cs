namespace HF.Refactor.Models
{
    /// <summary>
    /// Represents a single change in the preview.
    /// </summary>
    public sealed class PreviewItem
    {
        /// <summary>
        /// Type of refactor operation.
        /// </summary>
        public RefactorOperationType Type { get; set; }

        /// <summary>
        /// File line where the change occurs.
        /// </summary>
        public int Line { get; set; }

        /// <summary>
        /// File column where the change occurs.
        /// </summary>
        public int Column { get; set; }

        /// <summary>
        /// Original text.
        /// </summary>
        public string Before { get; set; }

        /// <summary>
        /// Replacement text.
        /// </summary>
        public string After { get; set; }

        /// <summary>
        /// Indicates whether this change is enabled.
        /// </summary>
        public bool Enabled { get; set; }

        public PreviewItem()
        {
            Before = string.Empty;
            After = string.Empty;
            Enabled = true;
        }

        /// <summary>
        /// Enables this preview item.
        /// </summary>
        public void Enable()
        {
            Enabled = true;
        }

        /// <summary>
        /// Disables this preview item.
        /// </summary>
        public void Disable()
        {
            Enabled = false;
        }

        public override string ToString()
        {
            return $"{Type}: {Before} -> {After}";
        }
    }
}