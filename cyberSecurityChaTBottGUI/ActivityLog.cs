using System;
using System.Collections.Generic;

namespace cyberSecurityChaTBottGUI
{
    internal class ActivityLog
    {
        // A simple list to store log messages for this session
        private static List<string> entries = new List<string>();

        // Adds a new message with the current time
        public static void Log(string action)
        {
            string time = DateTime.Now.ToString("HH:mm:ss");
            string entry = "[" + time + "] " + action;
            entries.Add(entry);
        }

        // Shows the last 5 log entries
        public static string GetRecentLog()
        {
            if (entries.Count == 0)
                return "No activity recorded yet.";

            string result = "=== RECENT ACTIVITY ===\n";

            // Work out where to start (last 5 entries)
            int start = entries.Count - 5;
            if (start < 0)
                start = 0;

            for (int i = start; i < entries.Count; i++)
            {
                result += (i - start + 1) + ". " + entries[i] + "\n";
            }

            if (entries.Count > 5)
                result += "\nType 'full log' to see everything.";

            return result;
        }

        // Shows every log entry
        public static string GetFullLog()
        {
            if (entries.Count == 0)
                return "No activity recorded yet.";

            string result = "=== FULL ACTIVITY LOG ===\n";

            for (int i = 0; i < entries.Count; i++)
            {
                result += (i + 1) + ". " + entries[i] + "\n";
            }

            return result;
        }
    }
}