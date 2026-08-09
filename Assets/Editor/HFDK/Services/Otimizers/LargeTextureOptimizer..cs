using UnityEngine;

using BRDK2.Models;

namespace BRDK2.Optimizers
{
    public static class LargeTextureOptimizer
    {
        public static OptimizationTask Scan()
        {
            return new OptimizationTask(
                "Large Textures",
                "Textures larger than the recommended size.",
                "Graphics",
                OptimizationSeverity.Info,
                0,
                new Object[0]);
        }

        public static void Fix()
        {
            Debug.Log(
                "[BRDK] Texture optimizer coming soon.");
        }
    }
}