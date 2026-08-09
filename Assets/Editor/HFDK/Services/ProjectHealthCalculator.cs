using System.Collections.Generic;
using UnityEngine;
using BRDK2.Models;

namespace BRDK2.Services
{
    public static class ProjectHealthCalculator
    {
        public static int Calculate(List<ScanResult> results)
        {
            int score = 100;

            foreach (ScanResult result in results)
            {
                switch (result.Title)
                {
                    case "Missing Scripts":
                        score -= result.Count * 10;
                        break;

                    case "Compile Errors":
                        score -= result.Count * 20;
                        break;

                    case "Missing References":
                        score -= result.Count * 5;
                        break;

                    case "Large Textures":
                        score -= result.Count;
                        break;

                    case "Empty Folders":
                        score -= result.Count / 5;
                        break;
                }
            }

            return Mathf.Clamp(score, 0, 100);
        }

        public static Color GetColor(int score)
        {
            if (score >= 90)
                return new Color(.30f, .85f, .40f);

            if (score >= 70)
                return new Color(.95f, .75f, .15f);

            return new Color(.95f, .30f, .30f);
        }

        public static string GetStatus(int score)
        {
            if (score >= 90)
                return "Excellent";

            if (score >= 70)
                return "Good";

            if (score >= 50)
                return "Needs Attention";

            return "Critical";
        }
    }
}