using System.Collections.Generic;
using BRDK2.Models;
using BRDK2.Services.Scanners;

namespace BRDK2.Services
{
    public static class ProjectScannerService
    {
        public static List<ScanResult> Scan()
        {
            List<ScanResult> results = new List<ScanResult>();

            // Core Project Validation
            results.Add(MissingScriptsScanner.Scan());
            results.Add(MissingReferencesScanner.Scan());
            results.Add(EmptyFoldersScanner.Scan());
            results.Add(LargeTexturesScanner.Scan());
            results.Add(CompileErrorsScanner.Scan());

            // Future Scanners
            // results.Add(DuplicateAssetsScanner.Scan());
            // results.Add(BuildSettingsScanner.Scan());
            // results.Add(AddressablesScanner.Scan());
            // results.Add(LightingScanner.Scan());
            // results.Add(PhysicsScanner.Scan());
            // results.Add(AnimationScanner.Scan());
            // results.Add(ShaderScanner.Scan());
            // results.Add(PrefabScanner.Scan());

            return results;
        }
    }
}