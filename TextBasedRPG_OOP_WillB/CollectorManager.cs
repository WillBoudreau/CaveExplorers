using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG_OOP_WillB
{
    internal class CollectorManager
    {
        List<char> Coins = new List<char>();
        List<char>Health = new List<char>();
        public void CollectCoins()
        {
            Coins.Add('*');
            Console.Clear();
            Console.WriteLine("Coin Collected");
            Console.ReadKey();
        }
        public void CollectHealth()
        {
            Health.Add('H');
            Console.Clear();
            Console.WriteLine("Health Collected ");
        }
    }
}
