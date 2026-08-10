using System;
using System.Collections.Generic;
using System.IO;

using BRDK2.Models;

namespace BRDK2.Services
{
    /// <summary>
    /// Simple find/replace preview scanner used by RefactorPage.
    /// </summary>
    public static class RefactorScanner
    {
        public static List<RefactorItem> Scan(
            string rootPath,
            string find,
            string replace)
        {
            List<RefactorItem> items = new List<RefactorItem>();

            if (string.IsNullOrEmpty(rootPath) ||
                string.IsNullOrEmpty(find) ||
                !Directory.Exists(rootPath))
            {
                return items;
            }

            string[] files = Directory.GetFiles(
                rootPath,
                "*.cs",
                SearchOption.AllDirectories);

            foreach (string file in files)
            {
                if (ShouldIgnore(file))
                    continue;

                string[] lines;

                try
                {
                    lines = File.ReadAllLines(file);
                }
                catch
                {
                    continue;
                }

                for (int i = 0; i < lines.Length; i++)
                {
                    string line = lines[i];

                    if (line.IndexOf(find, StringComparison.Ordinal) < 0)
                        continue;

                    items.Add(new RefactorItem
                    {
                        FilePath = file,
                        LineNumber = i + 1,
                        OriginalText = line.Trim(),
                        PreviewText = line.Replace(find, replace).Trim(),
                        ReplaceText = replace,
                        Selected = true
                    });
                }
            }

            return items;
        }

        static bool ShouldIgnore(string filePath)
        {
            string normalized = filePath.Replace('\\', '/');

            return normalized.Contains("/Library/") ||
                   normalized.Contains("/Temp/") ||
                   normalized.Contains("/Obj/") ||
                   normalized.Contains("/.git/");
        }
    }
}
