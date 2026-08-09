using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

using BRDK2.Models;
using BRDK2.Services.Scanners;

namespace BRDK2.Optimizers
{
    public static class EmptyFolderOptimizer
    {
        public static OptimizationTask Scan()
        {
            var result =
                EmptyFoldersScanner.Scan();

            return new OptimizationTask(
                "Empty Folders",
                "Folders that can safely be deleted.",
                "Cleanup",
                result.Count == 0
                    ? OptimizationSeverity.Info
                    : OptimizationSeverity.Warning,
                result.Count,
                result.Objects.ToArray());
        }

        public static void Fix()
        {
            var result =
                EmptyFoldersScanner.Scan();

            foreach (string path in result.Paths)
            {
                AssetDatabase.DeleteAsset(path);
            }

            AssetDatabase.Refresh();

            Debug.Log(
                "[BRDK] Empty folders removed.");
        }
    }
}