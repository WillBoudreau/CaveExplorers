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
            EnemyVals enemyVals = new EnemyVals();
            HealthSys healthSys = new HealthSys();
            Entity entity = new Entity();
            player.healthSys.GetHealth(5);
            enemy.healthSys.GetHealth(5);
            player.healthSys.GetAttack(1);
            enemy.healthSys.GetAttack(1);
            while (player.healthSys.playerhp > 0)
            {
                map.MapArray();
                Console.WriteLine("\nPlayer Health: " + player.healthSys.playerhp + "| Player Attack: " + player.healthSys.Attack);
                Console.WriteLine("Enemy Health:  " + enemy.healthSys.enemyhp + "| Enemy Attack: " + enemy.healthSys.Attack);
                player.DisplayPlayer();
                enemy.DisplayEnemy();
                player.PlayerPOSMove();
                enemy.EnemyPOSMove();
                if(player.healthSys.playerhp <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("Game Over...Press any key to quit");
                    Console.ReadKey();
                }
            }
        }
    }
}
