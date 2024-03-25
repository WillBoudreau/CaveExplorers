using System;
using System.Collections.Generic;
using System.Runtime;

namespace TextBasedRPG_OOP_WillB
{
    internal class LevelGeneration
    {
        Map map;
        Player player;
        Settings settings;
        MusicManager music;
        List<EnemyManager> enemies;
        List<ItemManager> items;
        List<ItemManager> itemManager;
        public LevelGeneration(Map map, Player player, List<EnemyManager> enemies, List<ItemManager>items, MusicManager music, Settings settings)
        {
            this.map = map;
            this.player = player;
            this.enemies = enemies;
            this.items = items;
            this.music = music;
            this.settings = settings;

        }
        public void Init()
        {
            GenerateLlevel(1);
        }
        public void GenerateLlevel(int level)
        {
            ClearLists();
            if (player == null)
            {
                Console.Clear();
                Console.WriteLine("Player is null");
                Console.ReadKey();
            }
            //enemies = new List<EnemyManager>();
            //itemManager = new List<ItemManager>();
            switch (level)
            {
                case 1:
                    music.PlayMusicLevel(level);
                    Console.CursorVisible = false;
                    map.Update();
                    break;
            }

        }
        void ClearLists()
        {
            if (enemies != null)
            {
                enemies.Clear();
            }
            if (itemManager != null)
            {
                itemManager.Clear();
            }
        }

    }
}
