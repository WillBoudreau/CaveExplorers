using System;
using System.Collections.Generic;
using System.Runtime;

namespace TextBasedRPG_OOP_WillB
{
    internal class ItemManager
    {
        public List<Items> item { get; set; }
        Settings settings = new Settings();
        public ItemManager()
        {
            item = new List<Items>();
        }
        public void Init(Map map)
        {
            GenerateItems(item,settings.numCoins,settings.numHealth, settings.numShield, settings.numDamage,map);
        }
        public void Draw(Map map)
        {
            foreach (Items items in item)
            {
                items.DisplayItem();
            }
        }
        public void GenerateItems(List<Items>item,int numCoins, int numHealth, int numShield, int numDamage, Map map)
        {
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
                        item.Add(new Coin(settings.CoinAvatar, x, y, map));
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
                        item.Add(new HealthPickup(settings.HealthAvatar, x, y, map));
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
                        item.Add(new ShieldItem(settings.ShieldAvatar, x, y, map));
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
                        item.Add(new DamageItem(settings.DamageAvatar, x, y, map));
                        ValidSpawn = true;
                    }
                }
            }
        }
        
    }
}