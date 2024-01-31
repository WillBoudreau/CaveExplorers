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
            Player player = new Player(map);
            PlayerVals playerVals = new PlayerVals();
            Enemy enemy = new Enemy(map);
            player.healthSys.GetHealth(5);
            while (true)
            {
                map.MapArray();
                //Console.BackgroundColor = 
                //Console.WriteLine("\nHello World");
                player.DisplayPlayer();
                enemy.DisplayEnemy();
                player.PlayerPOSMove();
                enemy.EnemyPOSMove();
                if (playerVals.Playerturn == true)
                {
                    if (player.x == enemy.x && player.y == enemy.y)
                    {
                        player.healthSys.TakeDamage(1);
                    }
                }
                Console.WriteLine(player.healthSys.playerhp);
                //Console.ReadKey();
                //Console.WriteLine(player.healthSys.playerhp);
                //player.healthSys.TakeDamage(1);
                //Console.WriteLine(player.healthSys.playerhp);
                //Console.ReadKey();
            }
        }

    }
}
