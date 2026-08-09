using BRDK2.Models;

namespace BRDK2.Services.Scanners
{
    public static class LargeTexturesScanner
    {
        public static ScanResult Scan()
        {
            return new ScanResult(
                "Large Textures",
                "Textures larger than 4096",
                0,
                ScanSeverity.Good);
        }
    }
}