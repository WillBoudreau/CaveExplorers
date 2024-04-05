using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG_OOP_WillB
{
    internal class DamageItem:Items
    {
        public DamageItem(char itemAvatar, int x, int y, Map map)
        {
            this.itemAvatar = itemAvatar;
            this.x = x;
            this.y = y;
        }
        public override void UseItem(Player player)
        {
            player.DamageUp(1);
        }
        public override void DisplayItem()
        {
            Console.SetCursorPosition(x, y);
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(itemAvatar);
        }
    }
}
