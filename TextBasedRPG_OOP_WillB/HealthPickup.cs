using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG_OOP_WillB
{
    internal class HealthPickup : ItemManager
    {
        List<ItemManager> Health;

        public HealthPickup(char itemAvatar, int x, int y, Map map) : base(itemAvatar, x, y, map)
        {
            itemType = ItemType.Health;
            ItemAvatar = 'H';
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
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(ItemAvatar);
        }

    }
}

