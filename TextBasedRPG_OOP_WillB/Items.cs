using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG_OOP_WillB
{
    internal abstract class Items
    {
        public char itemAvatar { get; set; }
        public string name { get; set; }
        public int x { get; set; }
        public int y { get; set; }

        public abstract void DisplayItem();
        public abstract void UseItem(Player player);
    }
}
