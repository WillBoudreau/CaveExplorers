using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG_OOP_WillB
{
    internal class DamageItem:ItemManager
    {
        public DamageItem(char itemAvatar, int x, int y, Map map) : base(itemAvatar, x, y, map)
        {
            itemType = ItemType.Damage;
            ItemAvatar = 'D';
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
