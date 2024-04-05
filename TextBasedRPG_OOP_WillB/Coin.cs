using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG_OOP_WillB
{
    internal class Coin:Items
    {
        public Coin(char itemAvatar, int x, int y, Map map)
        {
            this.itemAvatar = itemAvatar;
            this.x = x;
            this.y = y;
        }
        public override void UseItem(Player player)
        {
            player.score++;
        }
        public override void DisplayItem()
        {
            Console.SetCursorPosition(x, y);
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(itemAvatar);
        }

    }   
}
