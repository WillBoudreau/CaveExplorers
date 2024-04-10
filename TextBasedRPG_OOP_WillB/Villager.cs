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
            Console.WriteLine("Hello, I am a villager");
        }
        public override void DisplayNPC()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(npcAvatar);
        }
    }
}
