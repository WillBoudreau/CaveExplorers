using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG_OOP_WillB
{
    enum ItemType
    {
        Coin,
        Health,
        Shield,
        Damage
    }
    internal class ItemManager
    {
        ItemType itemType = new ItemType();
        public char ItemAvatar {get; set;}
        public int x { get; set; }
        public int y { get; set; }
        List<char> Coins;
        List<char> Health;
        public ItemManager( char itemAvatar, int x, int y, Map map)
        {
            ItemAvatar = itemAvatar;
            this.x = x;
            this.y = y;
        }
        
        public static List<ItemManager> GenerateItems(int numCoins, int numHealth, int numShield, int numDamage,Map map)
        {
            List<ItemManager> itemManagers = new List<ItemManager>();
            Random rnd = new Random();
            for (int i = 0; i < numCoins; i++)
            {
                int x;
                int y;
                bool ValidSpawn = false;
                while (!ValidSpawn)
                {
                    x = rnd.Next(1, map.MapChar[0].Length);
                    y = rnd.Next(1, map.MapChar.Length);
                    if (map.IsTileValid(x, y) == '.')
                    {
                        Console.SetCursorPosition(x, y);
                        map.UpdateMapTile(x, y,'*');
                        itemManagers.Add(new ItemManager('*', x, y, map));
                        ValidSpawn = true;
                    }
                }
            }
            for (int i = 0; i < numHealth; i++)
            {
                int x;
                int y;
                bool ValidSpawn = false;
                while (!ValidSpawn)
                {
                    x = rnd.Next(1, map.MapChar[0].Length);
                    y = rnd.Next(1, map.MapChar.Length);
                    if (map.IsTileValid(x, y) == '.')
                    {
                        Console.SetCursorPosition(x, y);
                        map.UpdateMapTile(x, y, 'H');
                        itemManagers.Add(new ItemManager('H', x, y, map));
                        ValidSpawn = true;
                    }
                }
            }
            return itemManagers;
        }
        public void DisplayItems(Map map)
        { 
            Console.SetCursorPosition(x, y);
            switch(ItemAvatar)
            {
                case '*':
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case 'H':
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case 'S':
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case 'D':
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
            }
            Console.Write(ItemAvatar);
            Console.ResetColor();
        }
    }
}