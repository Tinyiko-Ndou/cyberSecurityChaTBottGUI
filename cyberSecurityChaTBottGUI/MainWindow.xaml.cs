using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace cyberSecurityChaTBottGUI
{
    public partial class MainWindow : Window
    {
        private string userName = "";

        public MainWindow()
        {
            InitializeComponent();

            // Set up the database table on startup
            DatabaseHelper.InitialiseDatabase();

            AppendMessage("WELCOME TO THE CYBER SECURITY AWARENESS BOT !!!", Brushes.Cyan);

            // Ask the user for their name
            userName = Microsoft.VisualBasic.Interaction.InputBox(
                "Enter your name:", "Welcome", "");

            Memory.UserName = userName;

            AppendMessage("Welcome, " + userName + "!", Brushes.Yellow);

            // Record that the session started
            ActivityLog.Log("Session started for: " + userName);

            PlayGreeting.Play();
            AppendMessage(asciiArt.Show(), Brushes.Cyan);

            AppendMessage(
                "Use the buttons above or type your question below!\n" +
                "Top row: Quiz, Tasks, Activity Log | Bottom row: Quick tips",
                Brushes.Yellow);
        }

        // ── Send button ──────────────────────────────────────────────
        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            string input = UserInput.Text.ToLower();

            if (input == "")
            {
                AppendMessage("Please type something.", Brushes.Red);
                return;
            }

            AppendMessage("You: " + input, Brushes.White);

            if (input == "exit")
            {
                Application.Current.Shutdown();
                return;
            }

            string response = Bot.GetResponse(input, userName);
            AppendMessage("Bot: " + response, Brushes.Lime);

            UserInput.Clear();
        }

        // ── Top bar buttons ──────────────────────────────────────────

        // Starts the quiz
        private void QuizButton_Click(object sender, RoutedEventArgs e)
        {
            AppendMessage("You: start quiz", Brushes.White);
            string response = Bot.GetResponse("quiz", userName);
            AppendMessage("Bot: " + response, Brushes.Lime);
        }

        // Shows all tasks
        private void TasksButton_Click(object sender, RoutedEventArgs e)
        {
            AppendMessage("You: show tasks", Brushes.White);
            string response = Bot.GetResponse("show tasks", userName);
            AppendMessage("Bot: " + response, Brushes.Lime);
        }

        
        private void AddTaskButton_Click(object sender, RoutedEventArgs e)
        {
            string taskName = Microsoft.VisualBasic.Interaction.InputBox(
                "Enter your task name:\n(You can add a reminder by typing e.g. 'remind me in 3 days' at the end)",
                "Add Task",
                "");

            if (taskName == "")
            {
                AppendMessage("Bot: No task entered.", Brushes.Red);
                return;
            }

            AppendMessage("You: add task - " + taskName, Brushes.White);
            string response = Bot.GetResponse("add task - " + taskName, userName);
            AppendMessage("Bot: " + response, Brushes.Lime);
        }

        // Shows the activity log
        private void LogButton_Click(object sender, RoutedEventArgs e)
        {
            AppendMessage("You: show activity log", Brushes.White);
            string response = Bot.GetResponse("activity log", userName);
            AppendMessage("Bot: " + response, Brushes.Lime);
        }

        // Shows help
        private void HelpButton_Click(object sender, RoutedEventArgs e)
        {
            AppendMessage("You: help", Brushes.White);
            string response = Bot.GetResponse("help", userName);
            AppendMessage("Bot: " + response, Brushes.Lime);
        }

        // ── Quick topic buttons ───────────────────────────────────────

        private void PasswordButton_Click(object sender, RoutedEventArgs e)
        {
            AppendMessage("You: password", Brushes.White);
            string response = Bot.GetResponse("password", userName);
            AppendMessage("Bot: " + response, Brushes.Lime);
        }

        private void PhishingButton_Click(object sender, RoutedEventArgs e)
        {
            AppendMessage("You: phishing", Brushes.White);
            string response = Bot.GetResponse("phishing", userName);
            AppendMessage("Bot: " + response, Brushes.Lime);
        }

        private void BrowsingButton_Click(object sender, RoutedEventArgs e)
        {
            AppendMessage("You: safe browsing", Brushes.White);
            string response = Bot.GetResponse("browsing", userName);
            AppendMessage("Bot: " + response, Brushes.Lime);
        }

        private void TwoFAButton_Click(object sender, RoutedEventArgs e)
        {
            AppendMessage("You: 2fa", Brushes.White);
            string response = Bot.GetResponse("2fa", userName);
            AppendMessage("Bot: " + response, Brushes.Lime);
        }

        private void MalwareButton_Click(object sender, RoutedEventArgs e)
        {
            AppendMessage("You: malware", Brushes.White);
            string response = Bot.GetResponse("malware", userName);
            AppendMessage("Bot: " + response, Brushes.Lime);
        }

        // ── Helper to add coloured messages to the chat ───────────────
        private void AppendMessage(string message, Brush color)
        {
            Paragraph p = new Paragraph(new Run(message));
            p.Foreground = color;
            ChatBox.Document.Blocks.Add(p);
            ChatBox.ScrollToEnd();
        }
    }
}