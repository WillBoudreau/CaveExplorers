using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG_OOP_WillB
{
    internal abstract class NPC:Entity
    {
        public char npcAvatar { get; set; }

        public string npcName { get; set; }

        public List<string>message { get; set; }

        public int x { get; set; }

        public int y { get; set; }

        public abstract void DisplayNPC();

        public abstract void Talk();
    }
}
