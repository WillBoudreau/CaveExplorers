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
        //Variables
        public bool BossDead = false;
        public bool IsAttacked;
        public string name;
        public EnemyManager()
        {
            enemies = new List<Enemy>();
            itemManager = new List<ItemManager>();
            settings = new Settings();
        }
        public void GenerateEnemies(Map map,int numGrunts,int numChaser,int numRunner,int numBoss)
        {   
            int x;
            int y;
            bool ValidLocation = false;
                    while(!ValidLocation)
                    {
                        for (int i = 0; i < numGrunts; i++)
                        {
                            x = new Random().Next(0, map.MapChar[0].Length);
                            y = new Random().Next(0, map.MapChar.Length);
                            if (map.IsTileValid(x, y) == '.')
                            {
                                enemies.Add(new Grunt(settings.GruntAvatar,x, y, settings.GruntAttack, settings.GruntShield, settings.GruntMaxhp));
                                ValidLocation = true;
                            }
                        }
                    }
            //    for (int i = 0; i < numChaser; i++)
            //{
            //    bool ValidLocation = false;
            //    while(!ValidLocation)
            //    {
            //        x = new Random().Next(0, map.MapChar[0].Length);
            //        y = new Random().Next(0,map.MapChar.Length);
            //        if(map.IsTileValid(x,y) == '.')
            //        {
            //            enemies.Add(new Chaser(settings.ChaserAvatar,x,y, settings.ChaserAttack,settings.ChaserShield,settings.ChaserMaxhp));
            //            ValidLocation = true;
            //        }
            //    }
            //}

        }
        //Init
        public void Init(Map map)
        {
            GenerateEnemies(map,settings.numGrunt,settings.numChaser,0,0);
        }
        //Update
        public void Update(Player player,Map map)
        {
            foreach (Enemy enemy in enemies)
            {
                enemy.DisplayEnemy();
                enemy.Move(player,map);
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