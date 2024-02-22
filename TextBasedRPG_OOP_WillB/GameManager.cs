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
        List<Enemy> enemies;
        HUD hud;
        public GameManager() 
        {
            map = new Map();
            player = new Player();
            enemies = Enemy.GenerateEnenmies();
            hud = new HUD(player, enemies);
            Player.hud = hud;
        }
        public void GameLoop()
        {
            Console.CursorVisible = false;
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
