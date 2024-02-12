using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace TextBasedRPG_OOP_WillB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Map map = new Map();
            Player player = new Player();
            Enemy enemy = new Enemy();
            Console.WriteLine(player.healthSys.health);
            Console.ReadKey();
            while (player.healthSys.health > 0 || enemy.healthSys.health > 0)
            {
                map.MapArray();
                

                
                player.DisplayPlayer();
                enemy.DisplayEnemy();

                
                player.PlayerPOSMove();
                enemy.EnemyPOSMove();

                Console.Clear();
                Console.WriteLine("Player hp: " + player.healthSys.health);
                Console.WriteLine("Enemy hp: "+ enemy.healthSys.health);
                Console.ReadKey();
            }
            Console.Clear();
            Console.WriteLine("Game Over");
            Console.ReadKey();
        }
        
    }
}
