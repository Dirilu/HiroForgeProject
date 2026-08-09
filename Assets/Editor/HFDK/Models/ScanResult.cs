using System.Collections.Generic;
using UnityEngine;

namespace BRDK2.Models
{
    public class ScanResult
    {
        public string Title;
        public string Description;
        public int Count;
        public ScanSeverity Severity;

        public List<Object> Objects = new();

        public List<string> Paths = new();

        public ScanResult(
            string title,
            string description,
            int count,
            ScanSeverity severity)
        {
            Title = title;
            Description = description;
            Count = count;
            Severity = severity;
        }
    }
}