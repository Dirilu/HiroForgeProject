using System;

namespace HF.Refactor.Models
{
    /// <summary>
    /// Represents a single refactor operation.
    /// Every change performed by the engine is represented
    /// as one operation.
    /// </summary>
    public sealed class RefactorOperation
    {
        //------------------------------------------------------
        // Identity
        //------------------------------------------------------

        /// <summary>
        /// Unique identifier.
        /// </summary>
        public Guid Id { get; }

        //------------------------------------------------------
        // General
        //------------------------------------------------------

        /// <summary>
        /// Type of operation.
        /// </summary>
        public RefactorOperationType Type { get; set; }

        /// <summary>
        /// Enables or disables execution.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// Execution order.
        /// </summary>
        public int ExecutionOrder { get; set; }

        //------------------------------------------------------
        // File Information
        //------------------------------------------------------

        /// <summary>
        /// Full file path.
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// Relative project path.
        /// </summary>
        public string RelativePath { get; set; }

        /// <summary>
        /// Line number.
        /// </summary>
        public int Line { get; set; }

        /// <summary>
        /// Column number.
        /// </summary>
        public int Column { get; set; }

        //------------------------------------------------------
        // Values
        //------------------------------------------------------

        /// <summary>
        /// Original value.
        /// </summary>
        public string Before { get; set; }

        /// <summary>
        /// Replacement value.
        /// </summary>
        public string After { get; set; }

        //------------------------------------------------------
        // Status
        //------------------------------------------------------

        /// <summary>
        /// Has this operation been executed?
        /// </summary>
        public bool Executed { get; set; }

        /// <summary>
        /// Execution timestamp.
        /// </summary>
        public DateTime? ExecutedUtc { get; set; }

        /// <summary>
        /// Optional error message.
        /// </summary>
        public string Error { get; set; }

        //------------------------------------------------------
        // Constructor
        //------------------------------------------------------

        public RefactorOperation()
        {
            Id = Guid.NewGuid();

            Enabled = true;

            FilePath = string.Empty;

            RelativePath = string.Empty;

            Before = string.Empty;

            After = string.Empty;

            Error = string.Empty;
        }

        //------------------------------------------------------
        // State
        //------------------------------------------------------

        /// <summary>
        /// Marks the operation as completed.
        /// </summary>
        public void Complete()
        {
            Executed = true;

            ExecutedUtc = DateTime.UtcNow;
        }

        /// <summary>
        /// Marks the operation as failed.
        /// </summary>
        public void Fail(string error)
        {
            Executed = false;

            Error = error;
        }

        public override string ToString()
        {
            return $"{Type}: {Before} -> {After}";
        }
    }

    /// <summary>
    /// Supported refactor operations.
    /// </summary>
    public enum RefactorOperationType
    {
        Unknown = 0,

        Namespace,

        Class,

        Struct,

        Interface,

        Enum,

        Method,

        Property,

        Field,

        Event,

        Parameter,

        LocalVariable,

        File,

        Folder,

        Asset,

        AssemblyDefinition,

        Uxml,

        Uss,

        Json,

        String
    }
}
