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

            AppendMessage("WELCOME TO THE CYBER SECURITY AWARENESS BOT !!!", Brushes.Cyan);

            userName = Microsoft.VisualBasic.Interaction.InputBox(
                "Enter your name:",
                "Welcome",
                "");

            Memory.UserName = userName;

            AppendMessage("Welcome, " + userName + "!", Brushes.Yellow);

            PlayGreeting.Play();
            AppendMessage(asciiArt.Show(), Brushes.Cyan);
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            string input = UserInput.Text.ToLower();

            if (string.IsNullOrWhiteSpace(input))
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
            Paragraph paragraph = new Paragraph(new Run(message));
            paragraph.Foreground = color;

            ChatBox.Document.Blocks.Add(paragraph);
            ChatBox.ScrollToEnd();
        }
    }
}