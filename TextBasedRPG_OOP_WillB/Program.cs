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
            Displaymap map = new Displaymap();
            Player player = new Player();
            Enemy enemy = new Enemy();
            Enemy2 enemy2 = new Enemy2();
            player.healthSys.GetHealth(5);
            enemy.healthSys.GetHealth(5);
            enemy2.healthSys.GetHealth(1);
            player.healthSys.GetAttack(1);
            enemy.healthSys.GetAttack(1);
            enemy2.healthSys.GetAttack(2);
            while (player.healthSys.playerhp > 0)
            {
                map.MapArray();
                
                Console.WriteLine("\nPlayer Health: " + player.healthSys.playerhp + "| Player Attack: " + player.healthSys.Attack);
                Console.WriteLine("Grunt Health: " + enemy.healthSys.enemyhp + "| Enemy Attack: " + enemy.healthSys.Attack); 
                //Console.WriteLine("Sweaper Health: "+ enemy2.healthSys.enemy2hp +"| Sweaper Attack: "+enemy2.healthSys.Attack);
                
                player.DisplayPlayer();
                enemy.DisplayEnemy();
                //enemy2.DisplayEnemy2();
                
                player.PlayerPOSMove();
                enemy.EnemyPOSMove();
                //enemy2.Enemy2POSMove();
                
                player.AttackEnemy(enemy);
                enemy.AttackPlayer(player);
               // enemy2.AttackPlayer(player);
                if(player.healthSys.playerhp <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("Game Over...Press any key to quit");
                    Console.ReadKey();
                }
                if(enemy.healthSys.enemyhp <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("Congrats you win!...Press any key to quit");
                    Console.ReadKey();
                }
            }
        }
        
    }
}
