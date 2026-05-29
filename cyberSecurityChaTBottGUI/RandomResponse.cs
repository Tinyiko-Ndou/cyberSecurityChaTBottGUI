using System;
namespace cyberSecurityChaTBottGUI
{
    internal class RandomResponses
    {
        static Random random = new Random();
        public static string GetPasswordTip()
        {
            string[] responses =
            {

                 "Use strong passwords with symbols and numbers.",
                 "Avoid using your birthday as a password.",
                 "A password manager can help keep passwords secure.",
                  "Use different passwords for different accounts."
            };
            return responses[random.Next(responses.Length)];
        }
        public static string GetPhishingTip()
        {
            string[] responses =
            {
                "Never click suspicious email links.",
                  "Always verify the sender’s email address.",
                     "Phishing emails often create urgency to scare users.",
                       "Avoid downloading attachments from unknown senders."

            };
            return responses[random.Next(responses.Length)];
        }
        public static string GetSafeBrowsingTip()
        {
            string[] responses =
            {
             "Always check for HTTPS in website URLs.",
              "Avoid public Wi-Fi for sensitive activities.",
               "Keep your browser updated.",
               "Do not download files from unknown websites."
            };
            return responses[random.Next(responses.Length)];
        }
    }
}

