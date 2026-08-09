using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HF.Refactor.Scanning
{
    /// <summary>
    /// Scans a Unity project for C# source files.
    /// </summary>
    public sealed class CSharpScanner
    {
        /// <summary>
        /// Recursively scans the supplied directory for *.cs files.
        /// </summary>
        public IReadOnlyList<CSharpFile> Scan(string projectRoot)
        {
            if (string.IsNullOrWhiteSpace(projectRoot))
                throw new ArgumentException(
                    "Project path cannot be empty.",
                    nameof(projectRoot));

            if (!Directory.Exists(projectRoot))
                throw new DirectoryNotFoundException(projectRoot);

            List<CSharpFile> files = new List<CSharpFile>();

            ScanDirectory(projectRoot, files);

            return files;
        }

        //--------------------------------------------------------
        // Private
        //--------------------------------------------------------

        private void ScanDirectory(
            string directory,
            List<CSharpFile> files)
        {
            foreach (string file in Directory.GetFiles(directory, "*.cs"))
            {
                files.Add(new CSharpFile
                {
                    FullPath = file,
                    FileName = Path.GetFileName(file),
                    Directory = Path.GetDirectoryName(file) ?? string.Empty
                });
            }

            foreach (string child in Directory.GetDirectories(directory))
            {
                string folder = Path.GetFileName(child);

                if (ShouldIgnore(folder))
                    continue;

                ScanDirectory(child, files);
            }
        }

        private bool ShouldIgnore(string folder)
        {
            switch (folder)
            {
                case "Library":
                case "Temp":
                case "Logs":
                case "Obj":
                case ".git":
                case ".vs":
                    return true;

                default:
                    return false;
            }
        }
    }

    //--------------------------------------------------------
    // CSharp File
    //--------------------------------------------------------

    public sealed class CSharpFile
    {
        public string FullPath { get; set; }

        public string FileName { get; set; }

        public string Directory { get; set; }

        public long Length
        {
            get
            {
                if (!File.Exists(FullPath))
                    return 0;

                return new FileInfo(FullPath).Length;
            }
        }

        public CSharpFile()
        {
            FullPath = string.Empty;
            FileName = string.Empty;
            Directory = string.Empty;
        }

        public override string ToString()
        {
            return FileName;
        }
    }
}