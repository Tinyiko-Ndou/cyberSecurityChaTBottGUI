using System;
using System.Collections.Generic;
using System.Text;
using System.Media;

namespace cyberSecurityChaTBottGUI
{
    internal class PlayGreeting
    {
        public static void Play()
        {
            try
            {
                SoundPlayer player = new SoundPlayer("welcome.wav");

                player.PlaySync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error playing sound: " + ex.Message);
            }
        }
    }
}
