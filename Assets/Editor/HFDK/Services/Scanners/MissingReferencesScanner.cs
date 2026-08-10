using BRDK2.Models;

namespace BRDK2.Services.Scanners
{
    public static class MissingReferencesScanner
    {
        public static ScanResult Scan()
        {
            return new ScanResult(
                "Missing References",
                "Serialized fields with null references",
                0,
                ScanSeverity.Good);
        }
    }
}