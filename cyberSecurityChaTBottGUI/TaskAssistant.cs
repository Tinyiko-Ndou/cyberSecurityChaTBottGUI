namespace cyberSecurityChaTBottGUI
{
    internal class TaskAssistant
    {
        // Checks if the input is a task command and handles it
        public static string Handle(string input)
        {
            // ADD a task
            if (input.Contains("add task") || input.Contains("create task") || input.Contains("new task"))
            {
                return AddTask(input);
            }

            // VIEW all tasks
            if (input.Contains("show tasks") || input.Contains("my tasks") || input.Contains("list tasks"))
            {
                return DatabaseHelper.GetAllTasks();
            }

            // COMPLETE a task
            if (input.Contains("complete task") || input.Contains("done task") || input.Contains("mark task"))
            {
                return CompleteTask(input);
            }

            // Not a task command
            return null;
        }

        // Pulls the task title and optional reminder out of the input
        private static string AddTask(string input)
        {
           
            string content = input;
            content = content.Replace("add task", "");
            content = content.Replace("create task", "");
            content = content.Replace("new task", "");
            content = content.Trim().TrimStart('-', ':', ' ');

            if (content == "")
                return "Please tell me the task name. Example: 'add task - review privacy settings'";

            // Check if a reminder was included (e.g. "remind me in 3 days")
            string reminder = "";
            string title = content;

            if (content.Contains("remind me in"))
            {
                int splitPoint = content.IndexOf("remind me in");
                title = content.Substring(0, splitPoint).Trim().TrimEnd('.', ',');
                reminder = content.Substring(splitPoint).Trim();
            }

            if (title == "")
                return "Please include a task title before the reminder.";

            return DatabaseHelper.AddTask(title, reminder);
        }

        // Finds the task number in the input and marks it complete
        private static string CompleteTask(string input)
        {
            // Split the sentence into words and look for a number
            string[] words = input.Split(' ');

            foreach (string word in words)
            {
                // Remove the # symbol if present, then try to parse as a number
                string cleaned = word.Replace("#", "");
                int id;

                if (int.TryParse(cleaned, out id))
                {
                    return DatabaseHelper.CompleteTask(id);
                }
            }

            return "Please include the task number. Example: 'complete task #2'";
        }
    }
}