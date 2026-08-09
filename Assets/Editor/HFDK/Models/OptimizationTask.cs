using UnityEngine;

namespace BRDK2.Models
{
    public enum OptimizationSeverity
    {
        Info,
        Warning,
        Error
    }

    public class OptimizationTask
    {
        public string Title;
        public string Description;
        public string Category;

        public OptimizationSeverity Severity;

        public int Count;

        public Object[] Objects;

        public OptimizationTask(
            string title,
            string description,
            string category,
            OptimizationSeverity severity,
            int count,
            Object[] objects)
        {
            Title = title;
            Description = description;
            Category = category;
            Severity = severity;
            Count = count;
            Objects = objects;
        }
    }
}