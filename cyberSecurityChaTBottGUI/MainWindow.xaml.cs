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
                "Part 3 features: Tasks, Quiz, Activity Log!\n" +
                "Try: 'add task - enable 2fa'  |  'quiz'  |  'show activity log'",
                Brushes.Yellow);
        }

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

        private void AppendMessage(string message, Brush color)
        {
            Paragraph p = new Paragraph(new Run(message));
            p.Foreground = color;
            ChatBox.Document.Blocks.Add(p);
            ChatBox.ScrollToEnd();
        }
    }
}