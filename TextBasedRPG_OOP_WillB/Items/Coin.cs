using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG_OOP_WillB
{
    internal class Coin:ItemManager
    {
        List<ItemManager> Coins;

        public Coin(char itemAvatar, int x, int y, Map map,ItemType itemtype) : base(itemAvatar, x, y, map)
        {
            itemType = ItemType.Coin;
            ItemAvatar = '*';
            this.x = x;
            this.y = y;
        }
        public override void Update(Map map)
        {
            DisplayItems(map);
        }
        public override void DisplayItems(Map map)
        {
            Console.SetCursorPosition(x, y);
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(ItemAvatar);
        }

    }   
}
