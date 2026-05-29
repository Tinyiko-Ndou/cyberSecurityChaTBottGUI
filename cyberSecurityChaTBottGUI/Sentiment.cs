namespace cyberSecurityChaTBottGUI
{
    internal class Sentiment
    {
        public static string DetectEmotion(string input)
        {
            if (input.Contains("worried") || input.Contains("scared"))
            {
                return "Its okay to feel worried. Cyber threats can happen to anyone.";
            }
            else if (input.Contains("curious"))
            {
                return "Curiosity is great. Learning cyber security helps protect you online.";
            }
            else if (input.Contains("frustrated"))
            {
                return "I understand that this can feel frustrating. Lets solve it step by step.";
            }

            return null;
        }
    }
}