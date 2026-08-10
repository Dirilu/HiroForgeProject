using System;
using System.Collections.Generic;
using System.IO;

namespace HF.Refactor.Scanning
{
    /// <summary>
    /// Placeholder C# parser entry point.
    /// Full Roslyn integration requires Microsoft.CodeAnalysis packages.
    /// </summary>
    public sealed class RoslynScanner
    {
        /// <summary>
        /// Reads a C# source file. Syntax-tree parsing is not available
        /// until Roslyn packages are added to the project.
        /// </summary>
        public string ReadFile(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException(
                    "File path cannot be empty.",
                    nameof(filePath));

            if (!File.Exists(filePath))
                throw new FileNotFoundException(filePath);

            return File.ReadAllText(filePath);
        }

        /// <summary>
        /// Reads multiple C# files.
        /// </summary>
        public IReadOnlyList<string> ReadFiles(
            IEnumerable<string> files)
        {
            List<string> contents = new List<string>();

            foreach (string file in files)
            {
                contents.Add(ReadFile(file));
            }

            return contents;
        }
    }
}
