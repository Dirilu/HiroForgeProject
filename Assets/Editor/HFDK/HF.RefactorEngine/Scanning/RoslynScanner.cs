using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace HF.Refactor.Scanning
{
    /// <summary>
    /// Parses C# files using Roslyn.
    /// </summary>
    public sealed class RoslynScanner
    {
        /// <summary>
        /// Parses a C# source file into a Roslyn syntax tree.
        /// </summary>
        public SyntaxTree ParseFile(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException(
                    "File path cannot be empty.",
                    nameof(filePath));

            if (!File.Exists(filePath))
                throw new FileNotFoundException(filePath);

            string source = File.ReadAllText(filePath);

            return CSharpSyntaxTree.ParseText(
                source,
                path: filePath);
        }

        /// <summary>
        /// Parses multiple C# files.
        /// </summary>
        public IReadOnlyList<SyntaxTree> ParseFiles(
            IEnumerable<string> files)
        {
            List<SyntaxTree> trees =
                new List<SyntaxTree>();

            foreach (string file in files)
            {
                trees.Add(ParseFile(file));
            }

            return trees;
        }

        /// <summary>
        /// Returns the syntax root for a syntax tree.
        /// </summary>
        public SyntaxNode GetRoot(
            SyntaxTree tree)
        {
            if (tree == null)
                throw new ArgumentNullException(nameof(tree));

            return tree.GetRoot();
        }
    }
}