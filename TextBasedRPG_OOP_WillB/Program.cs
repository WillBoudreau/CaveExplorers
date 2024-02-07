using System;
using System.IO;
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

            while (true)
            {
                map.MapArray();
                

                
                player.DisplayPlayer();
                enemy.DisplayEnemy();

                
                player.PlayerPOSMove();
                enemy.EnemyPOSMove();

                
                player.AttackEnemy(enemy);
                enemy.AttackPlayer(player);
                //if(player.healthSys.playerhp <= 0)
                //{
                //    Console.Clear();
                //    Console.WriteLine("Game Over...Press any key to quit");
                //    Console.ReadKey();
                //}
                //if(enemy.healthSys.enemyhp <= 0)
                //{
                //    Console.Clear();
                //    Console.WriteLine("Congrats you win!...Press any key to quit");
                //    Console.ReadKey();
                //}
            }
        }
        
    }
}
