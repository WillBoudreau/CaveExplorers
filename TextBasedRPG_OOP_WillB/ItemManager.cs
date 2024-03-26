using System;
using System.Collections.Generic;
using System.Runtime;

namespace TextBasedRPG_OOP_WillB
{
    public enum ItemType
    {
        Coin,
        Health,
        Shield,
        Damage
    }
    internal class ItemManager
    {
        public char ItemAvatar { get; set; }
        public bool IsPickedUp { get; set; }
        public ItemType itemType { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        List<char> Coins;
        List<char> Health;
        List<char> Shield;
        List<char> Damage;
        Settings settings = new Settings();
        Map map = new Map();
        public ItemManager()
        {

        }
        public ItemManager(char itemAvatar, int x, int y, Map map)
        {
            ItemAvatar = itemAvatar;
            this.x = x;
            this.y = y;
        }
        public void Init()
        {
            GenerateItems(settings.numCoins, settings.numHealth, settings.numShield, settings.numDamage, map);
        }
        public virtual void Update(Map map)
        {
            DisplayItems(map);
        }
        public static List<ItemManager> GenerateItems(int numCoins, int numHealth, int numShield, int numDamage, Map map)
        {
            List<ItemManager> Damage = new List<ItemManager>();
            List<ItemManager> Shield = new List<ItemManager>();
            List<ItemManager> Health = new List<ItemManager>();
            List<ItemManager> Coins = new List<ItemManager>();
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
                        map.UpdateMapTile(x, y, '*');
                        itemManagers.Add(new Coin('*', x, y, map, ItemType.Coin) { itemType = ItemType.Coin });
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
                        itemManagers.Add(new HealthPickup('H', x, y, map) { itemType = ItemType.Health });
                        ValidSpawn = true;
                    }
                }
            }
            for (int i = 0; i < numShield; i++)
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
                        map.UpdateMapTile(x, y, 'S');
                        itemManagers.Add(new ShieldItem('S', x, y, map) { itemType = ItemType.Shield });
                        ValidSpawn = true;
                    }
                }
            }
            for (int i = 0; i < numDamage; i++)
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
                        map.UpdateMapTile(x, y, 'D');
                        itemManagers.Add(new DamageItem('D', x, y, map) { itemType = ItemType.Damage });
                        ValidSpawn = true;
                    }
                }
            }
            return itemManagers;
        }
        public bool IsitematPos(int x, int y)
        {
            if (this.x == x && this.y == y)
            {
                return true;
            }
            return false;
        }
        public virtual void DisplayItems(Map map)
        {
            Console.SetCursorPosition(x, y);
            if (!IsPickedUp)
            {
                switch (ItemAvatar)
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

            }
            else if (IsPickedUp)
            {
                ItemAvatar = '.';
            }
            Console.Write(ItemAvatar);
            Console.ResetColor();
        }
    }
}