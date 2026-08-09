using System.Collections.Generic;
using UnityEditor;

namespace BRDK2.Services
{
    public class BuildCheck
    {
        public string Name;
        public bool Passed;
        public string Message;

        public BuildCheck(
            string name,
            bool passed,
            string message)
        {
            Name = name;
            Passed = passed;
            Message = message;
        }
    }

    public static class BuildValidationService
    {
        public static List<BuildCheck> Validate()
        {
            List<BuildCheck> checks =
                new List<BuildCheck>();

            //------------------------------------------------

            checks.Add(
                new BuildCheck(
                    "Company Name",
                    !string.IsNullOrEmpty(PlayerSettings.companyName),
                    PlayerSettings.companyName));

            //------------------------------------------------

            checks.Add(
                new BuildCheck(
                    "Product Name",
                    !string.IsNullOrEmpty(PlayerSettings.productName),
                    PlayerSettings.productName));

            //------------------------------------------------

            checks.Add(
                new BuildCheck(
                    "Version",
                    !string.IsNullOrEmpty(PlayerSettings.bundleVersion),
                    PlayerSettings.bundleVersion));

            //------------------------------------------------

            checks.Add(
                new BuildCheck(
                    "Build Scenes",
                    EditorBuildSettings.scenes.Length > 0,
                    EditorBuildSettings.scenes.Length +
                    " scene(s)"));

            //------------------------------------------------

            checks.Add(
                new BuildCheck(
                    "Build Target",
                    true,
                    EditorUserBuildSettings.activeBuildTarget
                        .ToString()));

            return checks;
        }
    }
}