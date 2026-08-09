using System.Collections.Generic;

using BRDK2.Models;
using BRDK2.Optimizers;

namespace BRDK2.Services
{
    public static class OptimizationService
    {
        public static List<OptimizationTask> Scan()
        {
            List<OptimizationTask> tasks =
                new List<OptimizationTask>();

            tasks.Add(
                EmptyFolderOptimizer.Scan());

            tasks.Add(
                LargeTextureOptimizer.Scan());

            return tasks;
        }
    }
}