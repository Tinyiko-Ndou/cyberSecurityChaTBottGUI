using cyberSecurityChaTBottGUI;

namespace cyberSecurityChaTBottGUI
{
    internal class Bot
    {
        public static string GetResponse(string input, string name)
        {
            // Emotion Detection
            string emotion = Sentiment.DetectEmotion(input);

            if (emotion != null)
                return emotion;

            if (input.Contains("how are you"))
            {
                return "Im functioning perfectly, " + name + ". Ready to keep you safe online.";
            }
            else if (input.Contains("purpose"))
            {
                return "My purpose is to teach you about Cyber security and Online Safety.";
            }
            else if (input.Contains("what is cyber security"))
            {
                return "Cyber security is the practice of protecting systems, networks, and programs from digital attacks.";
            }
            else if (input.Contains("what can i ask"))
            {
                return "You can ask about Passwords, Phishing, Safe Browsing, and Cyber Security.";
            }
            else if (input.Contains("password"))
            {
                Memory.FavouriteTopic = "Passwords";
                return RandomResponses.GetPasswordTip();
            }
            else if (input.Contains("phishing"))
            {
                Memory.FavouriteTopic = "Phishing";
                return RandomResponses.GetPhishingTip();
            }
            else if (input.Contains("safe browsing") || input.Contains("browsing"))
            {
                Memory.FavouriteTopic = "Safe Browsing";
                return RandomResponses.GetSafeBrowsingTip();
            }
            else if (input.Contains("remember"))
            {
                if (Memory.FavouriteTopic != null)
                {
                    return "You previously asked about " + Memory.FavouriteTopic;
                }
                else
                {
                    return "I dont have anything in memory yet.";
                }
            }

            return "I didnt quite understand that.";
        }
    }
}