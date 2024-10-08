﻿using System;
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
        EnemyManager enemyMan;
        ItemManager itemManager;
        HUD hud;
        MusicManager soundManager;
        //Achievements achievements;
        public GameManager()
        {
            itemManager = new ItemManager();
            enemyMan = new EnemyManager();
            soundManager = new MusicManager();
            map = new Map();
            player = new Player(map);
            hud = new HUD(player, enemyMan.enemies, map);
            Player.hud = hud;
            //achievements = new Achievements(player, enemies, itemManager);
        }
        
        
            void GameInitialize()
            {
                map.Init();
                soundManager.Init();
                enemyMan.Init(map);
                player.Init();
                itemManager.Init(map);
                Intro();
            }
            void Update()
            {
                player.Update(enemyMan.enemies,itemManager.item,map);
                enemyMan.Update(player,map);
                hud.Update(enemyMan.enemies);
            }
            void Draw()
            {
                player.Draw();
                enemyMan.Draw();
                itemManager.Draw(map);
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