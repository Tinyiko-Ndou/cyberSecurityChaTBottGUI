using System;

namespace cyberSecurityChaTBottGUI
{
    internal class MiniGame
    {
        
        public static bool IsActive = false;

        // Tracks which question we are on and the score
        private static int currentQuestion = 0;
        private static int score = 0;

        // All questions, correct answers, and explanations
        private static string[] questions =
        {
            "Q1: What should you do with a suspicious email?\nA) Reply" +
                "  B) Delete " +
                "  C) Report as phishing " +
                "  D) Ignore",
            "Q2: True or False — Using the same password everywhere is safe.",
            "Q3: Which is the strongest password?\nA) password123" +
                "  B) MyDog2010 " +
                "  C) P@ssw0rd! " +
                "  D) Xk#9mQ!vL2$",
            "Q4: True or False — HTTPS means a website is completely safe.",
            "Q5: What is phishing?\nA) Malware" +
                " B) Fake emails to steal info  " +
                " C) A firewall  " +
                " D) A browser setting",
            "Q6: True or False — Public Wi-Fi is safe for online banking.",
            "Q7: What does 2FA stand for?\nA) Two-Factor Authentication " +
                " B) Two-Firewall Access" +
                " C) Trusted File Authorisation " +
                " D) Transfer File Approval",
            "Q8: True or False — Antivirus software alone fully protects you online.",
            "Q9: Which is social engineering?\nA) Installing antivirus " +
                " B) A hacker pretending to be IT support " +
                " C) Updating your browser " +
                " D) Using a password manager",
            "Q10: True or False — Ransomware locks your files and demands payment."
        };

        private static string[] correctAnswers =
        {
            "c", "false", "d", "false", "b", "false", "a", "false", "b", "true"
        };

        private static string[] explanations =
        {
            "Reporting phishing helps your provider block the scam.",
            "One breach exposes all your accounts — use different passwords!",
            "Long random passwords with mixed characters are hardest to crack.",
            "HTTPS only encrypts the connection — malicious sites can still use it.",
            "Phishing uses fake emails or websites to steal your information.",
            "Public Wi-Fi can be intercepted. Use a VPN for sensitive tasks.",
            "2FA adds a second step so attackers can't log in with just your password.",
            "You also need safe habits, strong passwords, and regular updates.",
            "Social engineering tricks people, not software.",
            "Regular backups are your best defence against ransomware."
        };

        // Starts a new quiz from question 1
        public static string Start()
        {
            IsActive = true;
            currentQuestion = 0;
            score = 0;

            ActivityLog.Log("Quiz started");

            return "=== CYBERSECURITY QUIZ ===\n" +
                   "10 questions. Reply with the letter (a/b/c/d) or true/false.\n\n" +
                   questions[0];
        }

        // Checks the player's answer and moves to the next question
        public static string Answer(string input)
        {
            string playerAnswer = input.Trim().ToLower();
            string correctAnswer = correctAnswers[currentQuestion];

            string feedback;

            if (playerAnswer == correctAnswer)
            {
                score++;
                feedback = "Correct! " + explanations[currentQuestion];
            }
            else
            {
                feedback = "Wrong. " + explanations[currentQuestion] +
                           "\nCorrect answer: " + correctAnswer.ToUpper();
            }

            currentQuestion++;

            // Quiz is finished
            if (currentQuestion >= questions.Length)
            {
                IsActive = false;
                ActivityLog.Log("Quiz finished. Score: " + score + "/10");

                string grade;
                if (score == 10) grade = "Perfect! You are a cybersecurity pro!";
                else if (score >= 7) grade = "Great job! Strong cybersecurity knowledge.";
                else if (score >= 5) grade = "Not bad! Keep learning to stay safe online.";
                else grade = "Keep practising — every lesson keeps you safer!";

                return feedback + "\n\n=== QUIZ COMPLETE ===\n" +
                       "Score: " + score + "/10\n" + grade;
            }

            // Show next question
            return feedback + "\n\n" + questions[currentQuestion];
        }
    }
}