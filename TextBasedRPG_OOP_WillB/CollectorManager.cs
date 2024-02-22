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
        List<char>Shield = new List<char>();
        string UseItems;
        public void CollectCoins()
        {
            Coins.Add('*');
        }
        public void CollectHealth()
        {
            Health.Add('H');
        }
        public void CollectShield()
        {
            Shield.Add('S');
            
        }
        public void RemoveCoins()
        {
            Coins.Remove('*');
            Inventory();
        }
        public void RemoveHealth()
        {
            Health.Remove('H');
            Inventory();
        }
        public void RemoveShield()
        {
            Shield.Remove('S');
            Inventory();
        }
        public void Inventory()
        {
            Console.Clear();
            Console.WriteLine("Shields availible:");
            for( int i = 0; i < Shield.Count; i++)
            {
                Console.Write(Shield[i]);
                Console.WriteLine();
            }
            Console.WriteLine("Health availible:");
            for(int i = 0;i < Health.Count; i++)
            {
                Console.Write(Health[i]);
                Console.WriteLine();
            }
            Console.WriteLine("Coins availible");
            for (int i = 0; i < Coins.Count; i++)
            {
                Console.Write(Coins[i]);
                Console.WriteLine();
            }
            Console.WriteLine("Which pickup would you like to use? or Close to go back");
            UseItems = Console.ReadLine();
            if(Coins.Count > 0 && UseItems == "Coins" || UseItems == "coins")
            {
                RemoveCoins();
            }
            if(Health.Count > 0 && UseItems == "Health"||UseItems == "health")
            {
                RemoveHealth();
            }
            if(Shield.Count > 0 && UseItems =="Shield"|| UseItems =="Shield")
            {
                RemoveShield();
            }
            if(UseItems == "Close" || UseItems =="close")
            {
                Console.WriteLine("Press any key to close");
            }
            Console.Clear();
        }
    }
}
