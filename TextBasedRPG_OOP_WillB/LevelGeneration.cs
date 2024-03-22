using System;
using System.Collections.Generic;
using System.Runtime;

namespace TextBasedRPG_OOP_WillB
{
    internal class LevelGeneration
    {
        Map map;
        Player player;
        List<ItemManager> items;
        MusicManager music;
        List<ItemManager> itemManager;
        List<EnemyManager> enemies;
        Settings settings;
        public LevelGeneration()
        {
            settings = new Settings();
            map = new Map();
            music = new MusicManager();
            itemManager = new List<ItemManager>();
            enemies = new List<EnemyManager>();
            player = new Player(items);
        }
        public void Init()
        {
            GenerateLlevel(1);
        }
        //public void Update()
        //{
        //    GenerateLlevel(1);
        //}
        void GenerateLlevel(int level)
        {
            enemies = new List<EnemyManager>();
            itemManager = new List<ItemManager>();
            if(player == null)
            {
                Console.Clear();
                Console.WriteLine("Player is null");
                Console.ReadKey();
            }
            if (enemies != null)
            {
                enemies.Clear();
            }
            if (itemManager != null)
            {
                itemManager.Clear();
            }
            switch (level)
            {
                case 1:
                    music.PlayMusicLevel(level);
                    Console.CursorVisible = false;
                    map.MapArray();
                    map.ShowMap();
                    settings.numGrunt = 25;
                    settings.numChaser = 5;
                    settings.numRunner = 5;
                    settings.numBoss = 1;
                    enemies = EnemyManager.GenerateEnemies(settings.numGrunt, settings.numChaser, settings.numRunner, settings.numBoss, map, player, items);
                    itemManager = ItemManager.GenerateItems(25, 10, 5, 3, map);
                    break;
                //case 2:
                //    music.PlayMusicLevel(level);
                //    Console.CursorVisible = false;
                //    map.MapArray();
                //    map.ShowMap();
                //    enemies = EnemyManager.GenerateEnemies(5, 2, 2, 1, map, player, items);
                //    itemManager = ItemManager.GenerateItems(25, 2, 2, 1, map);
                //    break;
            }

        }

    }
}
