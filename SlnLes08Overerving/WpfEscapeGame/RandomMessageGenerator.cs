using System;
using System.Collections.Generic;
using System.Text;

namespace WpfEscapeGame
{
    class RandomMessageGenerator
    {
        private static Random r = new Random();
        public enum MessageType { Message0, Message1, Message2 }
        public static string[] msg0 = { "No, don't think about this...", "You can't do this...", "Why would you even think about this..." };
        public static string[] msg1 = { "No, No, No...", "Stop, try to think about something else...", "Why don't you even try to think..." };
        public static string[] msg2 = { "Think about another solution...", "You can do it, just just no nevermind...", "Okey just forget it you will not escape this room..." };
        public static string GetRandomMessage(MessageType t)
        {
            string content = "";
            Array randomMes = Enum.GetValues(typeof(MessageType));
            t = (MessageType)randomMes.GetValue(r.Next(randomMes.Length));

            switch (t)
            {
                case MessageType.Message0:
                    content = msg0[r.Next(0, msg0.Length)];
                    break;
                case MessageType.Message1:
                    content = msg1[r.Next(0, msg1.Length)];
                    break;
                case MessageType.Message2:
                    content = msg2[r.Next(0, msg1.Length)];
                    break;
            }
            return content;
        }
    }
}
