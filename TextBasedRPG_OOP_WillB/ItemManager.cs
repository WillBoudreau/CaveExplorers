﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public char ItemAvatar {get; set;}
        public bool IsPickedUp { get; set; }
        public ItemType itemType { get; set; }
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
        public void Update(Map map)
        {
            DisplayItems(map);
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
                        itemManagers.Add(new ItemManager('*', x, y, map) {itemType = ItemType.Coin});
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
                        itemManagers.Add(new ItemManager('H', x, y, map) { itemType = ItemType.Health});
                        ValidSpawn = true;
                    }
                }
            }
            for(int i= 0; i < numShield; i++)
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
                        itemManagers.Add(new ItemManager('S', x, y, map) { itemType = ItemType.Shield });
                        ValidSpawn = true;
                    }
                }
            }
            for(int i = 0; i < numDamage; i++)
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
                        itemManagers.Add(new ItemManager('D', x, y, map) { itemType = ItemType.Damage });
                        ValidSpawn = true;
                    }
                }
            }
            return itemManagers;
        }
        public void DisplayItems(Map map)
        { 
            Console.SetCursorPosition(x, y);
            if(!IsPickedUp)
            {
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

            }
            else if(IsPickedUp)
            {
                ItemAvatar = '.';
            }
            Console.Write(ItemAvatar);
            Console.ResetColor();
        }
    }
}