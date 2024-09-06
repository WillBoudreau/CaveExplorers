using System;
using System.Collections.Generic;

namespace TextBasedRPG_OOP_WillB
{
    internal class EnemyManager
    {
        //Class calls
        public Player player;
        public Settings settings;
        public List<Enemy> enemies { get; set; }
        //Variables
        public bool BossDead = false;
        public bool IsAttacked;
        public string name;
        public EnemyManager()
        {
            settings = new Settings();
            enemies = new List<Enemy>();
        }
        //Generates enemies based on specified variables
        public void GenerateEnemies(Map map,List<Enemy>enemies,int numGrunts,int numChaser,int numRunner)
        {   
            Random rnd = new Random();
            for (int i = 0; i < numGrunts; i++)
            {
                int x;
                int y;
                bool ValidLocation = false;
                    while(!ValidLocation)
                    {
                            x = rnd.Next(1, map.MapChar[0].Length);
                            y = rnd.Next(1, map.MapChar.Length);
                            if (map.IsTileValid(x, y) == '.')
                            {
                                enemies.Add(new Grunt(settings.GruntAvatar,x, y, settings.GruntAttack, settings.GruntShield, settings.GruntMaxhp));
                                ValidLocation = true;
                            }
                    }
            }
            for (int i = 0; i < numChaser; i++)
            {
                int x;
                int y;
                bool ValidLocation = false;
                    while(!ValidLocation)
                    {
                            x = rnd.Next(1, map.MapChar[0].Length);
                            y = rnd.Next(1, map.MapChar.Length);
                            if (map.IsTileValid(x, y) == '.')
                            {
                                enemies.Add(new Chaser(settings.ChaserAvatar,x, y, settings.ChaserAttack, settings.ChaserShield, settings.ChaserMaxhp));
                                ValidLocation = true;
                            }
                    }
            }
            for(int i = 0; i <numRunner; i++)
            {
                int x;
                int y;
                bool ValidLocation = false;
                    while(!ValidLocation)
                    {
                            x = rnd.Next(1, map.MapChar[0].Length);
                            y = rnd.Next(1, map.MapChar.Length);
                            if (map.IsTileValid(x, y) == '.')
                            {
                                enemies.Add(new Runner(settings.RunnerAvatar,x, y, settings.RunnerAttack,settings.RunnerShield,settings.RunnerMaxhp));
                                ValidLocation = true;
                            }
                    }
            }
        }
        //Init
        public void Init(Map map)
        {
            GenerateEnemies(map,enemies, settings.numGrunt, settings.numChaser,settings.numRunner);
        }
        //Update
        public void Update(Player player,Map map)
        {
            foreach (Enemy enemy in enemies)
            {
                //enemy.DisplayEnemy();
                enemy.Move(player,map);
            }
        }
        //Draw
        public void Draw()
        {
            foreach (Enemy enemy in enemies)
            {
                enemy.DisplayEnemy();
            }
        }
    }
}