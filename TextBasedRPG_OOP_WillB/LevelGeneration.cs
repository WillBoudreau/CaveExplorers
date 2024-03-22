using System;
using System.Collections.Generic;

namespace TextBasedRPG_OOP_WillB
{
    internal class LevelGeneration
    {
        Map map;
        MusicManager music;
        List<ItemManager> itemManager;
        List<EnemyManager> enemies;
        public LevelGeneration()
        {
            map = new Map();
            music = new MusicManager();
            itemManager = new List<ItemManager>();
            enemies = new List<EnemyManager>();
        }
       

    }
}
