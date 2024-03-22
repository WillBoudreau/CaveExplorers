using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Media;
using System.IO;
using System.Data;

namespace TextBasedRPG_OOP_WillB
{

    internal class GameManager
    {

        Map map;
        Player player;
        Chaser chaser;
        Grunt grunt;
        Runner runner;
        MusicManager music;
        EnemyManager enemy;
        List<EnemyManager> enemies;
        List<ItemManager> items;
        HUD hud;
        List<ItemManager> itemManager;
        public GameManager()
        {
            music = new MusicManager();
            map = new Map();
            player = new Player();
            hud = new HUD(player, enemies);
            Player.hud = hud;
        }
        void GenerateLlevel(int level)
        {
            enemies = new List<EnemyManager>();
            itemManager = new List<ItemManager>();
            switch (level)
            {
                case 1:
                    music.PlayMusicLevel(level);
                    Console.CursorVisible = false;
                    map.MapArray();
                    map.ShowMap();
                    enemies = EnemyManager.GenerateEnemies(25, 1, 0, 0, map);
                    itemManager = ItemManager.GenerateItems(25, 1, 1, 1, map);
                    break;
                case 2:
                    music.PlayMusicLevel(level);
                    Console.CursorVisible = false;
                    map.MapArray();
                    map.ShowMap();
                    enemies = EnemyManager.GenerateEnemies(5, 2, 2, 1, map);
                    itemManager = ItemManager.GenerateItems(25, 2, 2, 1, map);
                    break;
            }

        }
        void GameInitialize()
        {
            player.Init();
            Intro();
            GenerateLlevel(1);
            player.Draw();
        }
        //Intro to game
        void Intro()
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
            //player.Init(player, enemies, map, hud, music, enemies);
            GameInitialize();
            while (player.healthSys.normalHealth > 0)
            {
                foreach (ItemManager item in itemManager)
                {
                    item.DisplayItems(map);
                }
                player.Update(enemies, itemManager, chaser,runner,grunt);
                foreach (EnemyManager enemy in enemies)
                {
                    enemy.Update(player, enemies);
                    enemy.Draw();
                }
                Console.ResetColor();
                Console.WriteLine("\n");
                hud.DisplayHUD(enemies);
                hud.LastSeenEnemy();
            }
            if(player.healthSys.normalHealth <= 0)
            {
                GameOver();
            }
        }
        //Game Over to game
        public void GameOver()
        {
            Console.Clear();
            Console.WriteLine("Game Over");
            Console.WriteLine("You where defeated by: ");
            Console.ReadKey();
        }

        public void Win()
        {
            Console.Clear();
            player.StopTimer();
            Console.WriteLine("You have defeated the boss! You win!");
            Console.WriteLine("Press any key to quit");
            Console.ReadKey();
        }
    }
}