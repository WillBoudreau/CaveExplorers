using System;
using System.Collections.Generic;
using System.Runtime;

namespace TextBasedRPG_OOP_WillB
{
    internal class LevelGeneration
    {
        Map map;
        Player player;
        Chaser chaser;
        Grunt grunt;
        Runner runner;
        Settings settings;
        MusicManager music;
        EnemyManager enemyMan;
        List<EnemyManager> enemies;
        List<ItemManager> items;
        HUD hud;
        List<ItemManager> itemManager;
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
        public void GenerateLlevel(int level)
        {
            //enemies = new List<EnemyManager>();
            //itemManager = new List<ItemManager>();
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
                    enemies = EnemyManager.GenerateEnemies(25,10,5,3, map, player, items,settings);
                    itemManager = ItemManager.GenerateItems(25, 10, 5, 3, map);
                    break;
            }

        }

    }
}
