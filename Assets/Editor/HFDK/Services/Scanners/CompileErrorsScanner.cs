using BRDK2.Models;

namespace BRDK2.Services.Scanners
{
    public static class CompileErrorsScanner
    {
        public static ScanResult Scan()
        {
            return new ScanResult(
                "Compile Errors",
                "Current project compilation errors",
                0,
                ScanSeverity.Good);
        }
    }
}