namespace cyberSecurityChaTBottGUI
{
    internal class Bot
    {
        public static string GetResponse(string input, string name)
        {
            // Step 1 — if a quiz is running, send the answer straight to MiniGame
            if (MiniGame.IsActive)
            {
                ActivityLog.Log("Quiz answer given");
                return MiniGame.Answer(input);
            }

            // Step 2 — check for emotions
            string emotion = Sentiment.DetectEmotion(input);
            if (emotion != null)
                return emotion;

            // Step 3 — activity log commands
            if (input.Contains("full log"))
                return ActivityLog.GetFullLog();

            if (input.Contains("activity log") || input.Contains("show log") || input.Contains("what have you done"))
                return ActivityLog.GetRecentLog();

            // Step 4 — task commands (handled in TaskAssistant)
            string taskReply = TaskAssistant.Handle(input);
            if (taskReply != null)
                return taskReply;

            // Step 5 — start the quiz
            if (input.Contains("quiz") || input.Contains("test me") || input.Contains("play") || input.Contains("game"))
                return MiniGame.Start();

            // Step 6 — cybersecurity topics
            if (input.Contains("password"))
            {
                Memory.FavouriteTopic = "Passwords";
                ActivityLog.Log("Topic: Passwords");
                return RandomResponses.GetPasswordTip();
            }

            if (input.Contains("phishing"))
            {
                Memory.FavouriteTopic = "Phishing";
                ActivityLog.Log("Topic: Phishing");
                return RandomResponses.GetPhishingTip();
            }

            if (input.Contains("browsing") || input.Contains("wifi") || input.Contains("wi-fi"))
            {
                Memory.FavouriteTopic = "Safe Browsing";
                ActivityLog.Log("Topic: Safe Browsing");
                return RandomResponses.GetSafeBrowsingTip();
            }

            if (input.Contains("2fa") || input.Contains("two factor") || input.Contains("two-factor"))
                return "Enable 2FA on all important accounts. It adds a second login step so attackers can't get in with just your password.";

            if (input.Contains("malware") || input.Contains("virus") || input.Contains("ransomware"))
                return "Keep your antivirus updated and avoid downloading files from unknown sources. Regular backups protect you from ransomware.";

            if (input.Contains("privacy"))
                return "Review your privacy settings regularly and limit the personal data you share online.";

            // Step 7 — general conversation
            if (input.Contains("how are you"))
                return "I am functioning perfectly, " + name + ". Ready to keep you safe online!";

            if (input.Contains("purpose") || input.Contains("what do you do"))
                return "I can help with cybersecurity tips, manage your tasks, run a quiz, and track activity.";

            if (input.Contains("help") || input.Contains("what can i ask"))
                return "You can ask about:\n" +
                       "Passwords, Phishing, Safe Browsing, 2FA, Malware, Privacy\n" +
                       "'add task - [name]'  |  'show tasks'  |  'complete task #2'\n" +
                       "'start quiz'  |  'show activity log'";

            if (input.Contains("remember"))
            {
                if (Memory.FavouriteTopic != null)
                    return "You last asked about " + Memory.FavouriteTopic + ".";
                else
                    return "I have nothing in memory yet.";
            }

            // Step 8 — fallback
            ActivityLog.Log("Unrecognised input");
            return "I did not understand that. Type 'help' to see what I can do.";
        }
    }
}