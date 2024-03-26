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
        Settings settings;
        MusicManager music;
        List<EnemyManager> enemies;
        List<ItemManager> items;
        HUD hud;
        EnemyManager enemy;
        List<ItemManager> itemManager;
        ItemManager item;
        NPCManager npc;
        List<NPCManager> npcs;
        Generation generation;
        //Achievements achievements;
        public GameManager()
        {
            generation = new Generation();
            item = new ItemManager();
            music = new MusicManager();
            map = new Map();
            enemies = new List<EnemyManager>();
            items = new List<ItemManager>();
            itemManager = new List<ItemManager>();
            player = new Player(items, map);
            hud = new HUD(player, enemies, map);
            Player.hud = hud;
            enemy = new EnemyManager(settings,player,items,map);
            settings = new Settings();
            npc = new NPCManager(settings, player, map);
            npcs = new List<NPCManager>();
            //achievements = new Achievements(player, enemies, itemManager);
        }

             void GameInitialize()
            { 
                
                //generation.Init();
                generation.Init();
                player.Init();
                //map.Init();
                Intro();
            }
            void GameInitializeLVL2() 
            {
                //enemies = EnemyManager.GenerateEnemies(settings.numGrunt, settings.numChaser, settings.numRunner, settings.numBoss, map, player, items, settings);
                //items = ItemManager.GenerateItems(settings.numCoins, settings.numHealth, settings.numShield, settings.numDamage, map);
                //player.Init();
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
                GameInitialize();
                while (player.healthSys.IsAlive)
                {
                    UpdateGame();
                    DrawGame();
                }
                if (player.healthSys.IsAlive ==false)
                {
                    GameOver();
                }
            }
        private void UpdateGame()
        {
            generation.Update();
            player.Update(enemies, itemManager, chaser, runner, grunt);
            enemy.Update(player, enemies, items);
            //foreach (ItemManager item in items)
            //{
            //    item.Update(map);
            //}
            hud.Update(enemies);
        }
        private void DrawGame()
        {
            map.Draw();
            player.Draw();
            enemy.Draw(player,enemies,items);
            
        }
            //Game Over to game
            public void GameOver()
            {
                Console.Clear();
                Console.WriteLine("Game Over");
                Console.WriteLine("You where defeated by: ");
                Console.ReadKey();
            }
        }
    }