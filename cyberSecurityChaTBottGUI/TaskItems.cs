using System;

namespace cyberSecurityChaTBottGUI
{
    // Stores the details of one task
    internal class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Reminder { get; set; }
        public bool IsCompleted { get; set; }
    }
}