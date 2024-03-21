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
        public ItemManager( char itemAvatar, int x, int y, Map map)
        {
            List<char> Coins = new List<char>();
            List<char> Health = new List<char>();
            List<char> Shield = new List<char>();
            List<char> Damage = new List<char>();
            ItemAvatar = itemAvatar;
            this.x = x;
            this.y = y;
        }
        
        public static List<ItemManager> GenerateItems(int numCoins, int numHealth, int numShield, int numDamage,Map map)
        {
            List<char>Coins = new List<char>();
            List<char>Health = new List<char>();
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
                        Console.Clear();
                        Console.Write(x + " " + y);
                        Console.ReadKey();
                        map.UpdateMapTile(x, y,'*');
                        itemManagers.Add(new ItemManager('*', x, y, map));
                        Coins.Add('*');
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
                        Health.Add('H');
                        ValidSpawn = true;
                    }
                }
            }
            return itemManagers;
        }
        public void DisplayItems()
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
