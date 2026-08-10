using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HF.Refactor.Engine
{
    /// <summary>
    /// Centralized abstraction for all file system operations.
    /// Every file access performed by the refactor engine
    /// goes through this service.
    /// </summary>
    public sealed class FileSystemService
    {
        //----------------------------------------------------
        // Directories
        //----------------------------------------------------

        public bool DirectoryExists(string path)
        {
            return Directory.Exists(path);
        }

        public void CreateDirectory(string path)
        {
            Directory.CreateDirectory(path);
        }

        public IEnumerable<string> GetDirectories(string path)
        {
            if (!Directory.Exists(path))
                return Enumerable.Empty<string>();

            return Directory.GetDirectories(path);
        }

        //----------------------------------------------------
        // Files
        //----------------------------------------------------

        public bool FileExists(string path)
        {
            return File.Exists(path);
        }

        public IEnumerable<string> GetFiles(
            string path,
            string searchPattern,
            SearchOption searchOption)
        {
            if (!Directory.Exists(path))
                return Enumerable.Empty<string>();

            return Directory.GetFiles(
                path,
                searchPattern,
                searchOption);
        }

        public string ReadAllText(string path)
        {
            return File.ReadAllText(path);
        }

        public void WriteAllText(
            string path,
            string contents)
        {
            File.WriteAllText(path, contents);
        }

        public void CopyFile(
            string source,
            string destination)
        {
            string folder =
                Path.GetDirectoryName(destination);

            if (!string.IsNullOrWhiteSpace(folder))
            {
                Directory.CreateDirectory(folder);
            }

            File.Copy(
                source,
                destination,
                true);
        }

        public void DeleteFile(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        //----------------------------------------------------
        // Rename
        //----------------------------------------------------

        public void RenameFile(
            string filePath,
            string newName)
        {
            if (!File.Exists(filePath))
                return;

            string directory =
                Path.GetDirectoryName(filePath);

            if (string.IsNullOrEmpty(directory))
                return;

            string extension =
                Path.GetExtension(filePath);

            string destination =
                Path.Combine(
                    directory,
                    newName + extension);

            File.Move(
                filePath,
                destination);
        }

        public void RenameDirectory(
            string directoryPath,
            string newName)
        {
            if (!Directory.Exists(directoryPath))
                return;

            DirectoryInfo parentInfo =
                Directory.GetParent(directoryPath);

            if (parentInfo == null)
                return;

            string destination =
                Path.Combine(
                    parentInfo.FullName,
                    newName);

            Directory.Move(
                directoryPath,
                destination);
        }

        //----------------------------------------------------
        // Text
        //----------------------------------------------------

        public void ReplaceText(
            string filePath,
            string before,
            string after)
        {
            if (!File.Exists(filePath))
                return;

            string text =
                File.ReadAllText(filePath);

            if (!string.IsNullOrEmpty(before))
            {
                text = text.Replace(before, after);
            }

            File.WriteAllText(
                filePath,
                text);
        }
    }
}