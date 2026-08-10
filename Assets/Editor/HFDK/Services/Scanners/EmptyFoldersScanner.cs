using System.IO;
using BRDK2.Models;

namespace BRDK2.Services.Scanners
{
    public static class EmptyFoldersScanner
    {
        public static ScanResult Scan()
        {
            ScanResult result = new ScanResult(
                "Empty Folders",
                "Folders that contain no assets",
                0,
                ScanSeverity.Good);

            ScanFolder("Assets", result);

            if (result.Count > 0)
                result.Severity = ScanSeverity.Warning;

            return result;
        }

        static void ScanFolder(string path, ScanResult result)
        {
            if (!Directory.Exists(path))
                return;

            string[] directories = Directory.GetDirectories(path);

            foreach (string directory in directories)
            {
                ScanFolder(directory, result);

                string[] files = Directory.GetFiles(directory);

                bool hasAsset = false;

                foreach (string file in files)
                {
                    if (!file.EndsWith(".meta"))
                    {
                        hasAsset = true;
                        break;
                    }
                }

                string[] subFolders =
                    Directory.GetDirectories(directory);

                if (!hasAsset && subFolders.Length == 0)
                {
                    result.Count++;

                    UnityEngine.Debug.Log(
                        "[BRDK] Empty Folder: " + directory);

                    UnityEngine.Object folder =
                        UnityEditor.AssetDatabase.LoadAssetAtPath<UnityEngine.Object>(
                            directory);

                    if (folder != null)
                    {
                        result.Objects.Add(folder);
                        result.Paths.Add(directory);
                    }
                }
            }
        }
    }
}