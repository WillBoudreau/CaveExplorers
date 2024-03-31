using System;
using System.Collections.Generic;

namespace TextBasedRPG_OOP_WillB
{
    internal class EnemyManager
    {
        //Class calls
        public Player player;
        public Settings settings;
        public List<ItemManager> itemManager;
        public List<Enemy> enemies;
        public Map map;
        //Variables
        public bool BossDead = false;
        public bool IsAttacked;
        public string name;
        public EnemyManager()
        {
            enemies = new List<Enemy>();
            itemManager = new List<ItemManager>();
            settings = new Settings();
            map = new Map();
            player = new Player(map);
        }
        public void GenerateEnemies(Map map,int numGrunts)
        {
            //enemies = new List<Enemy>();    
            int x;
            int y;
            bool ValidLocation;
                for (int i = 0; i < numGrunts; i++)
                {
                    ValidLocation = false;
                    while(!ValidLocation)
                    {
                        x = new Random().Next(0, map.MapChar[0].Length);
                        y = new Random().Next(0, map.MapChar.Length);
                        if (map.IsTileValid(x, y) == '.')
                        {
                            enemies.Add(new Grunt(settings.GruntAvatar,x, y, settings.GruntAttack, settings.GruntShield, settings.GruntMaxhp, player));
                            ValidLocation = true;
                        }
                    }
                }
        }
        //Init
        public void Init()
        {
            GenerateEnemies(map,settings.numGrunt);
        }
        //Update
        public void Update(Player player)
        {
            foreach (Enemy enemy in enemies)
            {
                enemy.DisplayEnemy();
                enemy.Move(player);
            }
        }
        //Draw
        public void Draw(List<Enemy> enemies)
        {
            foreach (Enemy enemy in enemies)
            {
                enemy.DisplayEnemy();
            }
        }
    }
}