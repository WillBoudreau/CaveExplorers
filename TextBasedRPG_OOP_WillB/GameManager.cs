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
        bool BossDead = false;
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
        void Start()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Cave Explorers!");
            Console.WriteLine("---------------------------");
            Console.WriteLine("You goal adventurer is to defeat the Boss at the end of the level");
            Console.WriteLine("Make sure you collect pickups to boost your stats along the way");
            Console.WriteLine("---------------------------");
            Console.WriteLine("On you adventure you will find many enemies and they will attack you");
            Console.WriteLine("You can attack them by moving into them, but they can do the same and some may even try to escape!");
            Console.WriteLine("---------------------------");
            Console.WriteLine("Press any key to begin");
            Console.ReadKey(true);
            Console.Clear();
        }
        public void GameLoop()
        {
            Start();
            Console.CursorVisible = false;
            map.MapArray();
            map.ShowMap();
            while (player.healthSys.normalHealth > 0 && !BossDead)
            {
                Console.ResetColor();
                Console.WriteLine("\n");
                hud.DisplayHUD();
                hud.LastSeenEnemy();
                foreach (var enemy in enemies)
                {
                    enemy.DisplayEnemy();
                    enemy.EnemyMove(player,enemies);
                    if(enemy.enemType == EnemType.Boss && enemy.healthSys.IsAlive == false)
                    {
                        BossDead = true;
                        break;
                    }
                }
                player.DisplayPlayer();
                player.PlayerPOSMove(enemies);
            }
                if (BossDead == true)
                {
                    Win();
                }
                else
                {
                    GameOver();
                }
        }
        public void GameOver()
        {
            Console.Clear();
            Console.WriteLine("Game Over");
            Console.ReadKey();
        }
        public void Win()
        {
            Console.Clear();
            Console.WriteLine("You have defeated the boss! You win!");
            Console.WriteLine("Press any key to quit");
            Console.ReadKey();
        }
    }
}