using System.Collections.Generic;

namespace BRDK2.Services
{
    public static class ActivityService
    {
        private static readonly List<string> _activities = new();

        public static IReadOnlyList<string> Activities => _activities;

        public static void Log(string message)
        {
            _activities.Insert(0, message);

            if (_activities.Count > 20)
                _activities.RemoveAt(_activities.Count - 1);
        }

        public static void Clear()
        {
            _activities.Clear();
        }
    }
}