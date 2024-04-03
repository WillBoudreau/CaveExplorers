using System;
using System.Collections.Generic;

namespace TextBasedRPG_OOP_WillB
{
    internal class EnemyManager
    {
        //Class calls
        public Player player;
        public Settings settings;
        public List<Enemy> enemies = new List<Enemy>();
        //Variables
        public bool BossDead = false;
        public bool IsAttacked;
        public string name;
        public EnemyManager()
        {
            settings = new Settings();
        }
        public void GenerateEnemies(Map map,List<Enemy>enemies,int numGrunts,int numChaser,int numRunner,int numBoss)
        {   
            for (int i = 0; i < numGrunts; i++)
            {
                int x;
                int y;
                bool ValidLocation = false;
                    while(!ValidLocation)
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
            Console.Clear();
            foreach(Enemy enemy in enemies)
            {
                Console.WriteLine(enemy.name);
            }
            Console.ReadKey();  
        }
        //Init
        public void Init(Map map, List<Enemy> enemies)
        {
            GenerateEnemies(map,enemies,settings.numGrunt,settings.numChaser,0,0);
        }
        //Update
        public void Update(Player player,Map map,List<Enemy>enemies)
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