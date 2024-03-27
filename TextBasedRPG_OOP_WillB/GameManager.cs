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
        EnemyManager enemyMan;
        List<EnemyManager> enemies;
        EnemyManager enemyManager;
        List<ItemManager> items;
        HUD hud;
        Generation generation;
        List<ItemManager> itemManager;
        //Achievements achievements;
        public GameManager()
        {
            map = new Map();
            enemies = new List<EnemyManager>();
            items = new List<ItemManager>();
            itemManager = new List<ItemManager>();
            player = new Player(items,map);
            hud = new HUD(player, enemies, map);
            generation = new Generation();  
            enemyMan = new EnemyManager(settings,player,items,map,enemies);
            Player.hud = hud;
            settings = new Settings();
            //achievements = new Achievements(player, enemies, itemManager);
        }
        
        
            void GameInitialize()
            {
                map.Init();
                player.Init();
                generation.Init();
                Intro();
                //enemyMan.Init();
                player.Draw();
            }
            void Update()
            {
                generation.Update();
                player.Update(enemies,items,chaser,runner,grunt);
                hud.Update(enemies);
                enemyMan.Update(player, enemies, items);
            }
            void Draw()
            {
                generation.Draw();
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
                GameInitialize();
                while (player.healthSys.normalHealth > 0)
                {
                   Update();
                   Draw();
                }
                if (player.healthSys.normalHealth <= 0)
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
        }
    }