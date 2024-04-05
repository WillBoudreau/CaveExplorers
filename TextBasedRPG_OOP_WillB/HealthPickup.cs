using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG_OOP_WillB
{
    internal class HealthPickup : Items
    {
        public HealthPickup(char itemAvatar, int x, int y, Map map)
        {
            this.itemAvatar = itemAvatar;
            this.x = x;
            this.y = y;
        }
        public override void UseItem(Player player)
        {
            player.healthSys.Heal(1);
        }
        public override void DisplayItem()
        {
            Console.SetCursorPosition(x, y);
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(itemAvatar);
        }

    }
}

