using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG_OOP_WillB
{
    internal class GameManager
    {
        Map map;
        Player player;
        Enemy enemy;
        Enemy enemy1;
        Enemy enemy2;
        Enemy enemy3;
        Enemy enemy4;
        List<Enemy> enemies;
        HUD hud;
        public GameManager() 
        {
            map = new Map();
            player = new Player();
            enemy1 = new Enemy(5, 5, EnemType.Grunt);
            enemy2 = new Enemy(15, 15, EnemType.Chaser);
            enemy3 = new Enemy(14, 14, EnemType.Runner);
            enemy4 = new Enemy(20, 20, EnemType.Boss);
            enemies = new List<Enemy> { enemy1, enemy2, enemy3, enemy4};
            hud = new HUD(player, enemies);
            Player.hud = hud;
        }
        public void GameLoop()
        {
            map.MapArray();
            map.ShowMap();
            while (player.healthSys.health > 0)
            {
                Console.ResetColor();
                Console.WriteLine("\n");
                hud.DisplayHUD();
                Console.WriteLine("----------");
                player.DisplayPlayer();


                foreach (var enemy in enemies)
                {
                    enemy.DisplayEnemy();
                    enemy.EnemyMove(player);
                }
                player.PlayerPOSMove(enemies);
                Console.ResetColor();
            }
            GameOver();
        }
        public void GameOver()
        {
            Console.Clear();
            Console.WriteLine("Game Over");
            Console.ReadKey();

        }
    }
}
