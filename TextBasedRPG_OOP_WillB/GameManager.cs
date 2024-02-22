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
        Enemy Grunt;
        Enemy Chaser;
        Enemy Runner;
        Enemy Boss;
        List<Enemy> enemies;
        HUD hud;
        public GameManager() 
        {
            map = new Map();
            player = new Player();
            enemies = new List<Enemy>();
            for(int i = 0; i < 5; i++) 
            {
                Grunt= new Enemy(5, 5, EnemType.Grunt); 
                enemies.Add(Grunt);
            }
            for(int i = 0; i < 2; i++)
            {
                Chaser = new Enemy(15, 15, EnemType.Chaser);
                enemies.Add(Chaser);
            }
            for(int i = 0;i < 3; i++)
            {
                Runner = new Enemy(14, 14, EnemType.Runner);
                enemies.Add(Runner);
            }
            Boss = new Enemy(20, 20, EnemType.Boss);
            hud = new HUD(player, enemies);
            Player.hud = hud;
        }
        public void GameLoop()
        {
            Console.Clear();
            map.MapArray();
            map.ShowMap();
            while (player.healthSys.health > 0)
            {
                Console.ResetColor();
                Console.WriteLine("\n");
                hud.DisplayHUD();
                player.DisplayPlayer();


                foreach (var enemy in enemies)
                {
                    enemy.DisplayEnemy();
                    enemy.EnemyMove(player,enemies);
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
