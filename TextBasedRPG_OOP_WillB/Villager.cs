using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TextBasedRPG_OOP_WillB
{
    internal class Villager : NPC
    {
        public Villager(char npcAvatar, int x, int y, string npcName, List<string> message)
        {
            this.npcAvatar = npcAvatar;
            this.x = x;
            this.y = y;
            this.npcName = npcName;
            this.message = message;
        }
        public override void Talk()
        {
            Console.Clear();
            message.Add("Hello there!");
            message.Add("Traveller! Please help!");
            message.Add("The Village has been overrun by the cave legion!");
            message.Add("Please help us!");

            foreach (string message in message)
            {
                Console.WriteLine(message);
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }
        }
        public override void DisplayNPC()
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.Write(npcAvatar);
            Console.ResetColor();
        }
    }
}
