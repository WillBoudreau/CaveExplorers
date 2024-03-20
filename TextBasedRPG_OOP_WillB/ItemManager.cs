using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG_OOP_WillB
{
    internal class ItemManager
    {
        public ItemManager()
        {
            List<char> Coins = new List<char>();
            List<char> Health = new List<char>();
            List<char> Shield = new List<char>();
            string UseItems;
        }
        public void GenerateItems(int numCoins, int numHealth, int numShield, int numDamage,Map map)
        {
            List<char>Coins = new List<char>();
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
                        Coins.Add('*');
                        ValidSpawn = true;
                    }
                }
            }
        }
    }
}
