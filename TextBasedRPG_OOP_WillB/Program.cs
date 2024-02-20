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
            Enemy enemy1 = new Enemy(4, 4, EnemType.Grunt);
            //Enemy enemy2 = new Enemy(15,15, EnemType.Chaser);
            List<Enemy> enemies = new List<Enemy> { enemy1};
            HUD hud = new HUD(player,enemies);
            map.MapArray();
            while (player.healthSys.health > 0 || enemy1.healthSys.health > 0)
            {
                map.ShowMap();
                hud.DisplayHUD();
                Console.WriteLine("----------");
                player.DisplayPlayer();
                

                foreach(var enemy in enemies)
                {
                    enemy.DisplayEnemy();
                    enemy.EnemyMove(player);
                }
                player.PlayerPOSMove(enemies);
               
                Console.ResetColor();
            }
            Console.Clear();
            Console.WriteLine("Game Over");
            Console.ReadKey();
        }
        
    }
}
