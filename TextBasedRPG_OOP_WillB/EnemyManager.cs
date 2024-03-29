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
        //Init
        public void Init()
        {
            GenerateEnemies(settings.numGrunt);
        }
        //Update
        public void Update(Player player, List<Enemy> enemies)
        {

        }
        //Draw
        public void Draw(Player player, List<Enemy> enemies)
        {

        }
        public void GenerateEnemies(int numGrunts)
        {
            //List<Enemy> enemies = new List<Enemy>();    
            int x;
            int y;
            bool ValidLocation = false;
            while(!ValidLocation)
            {
                for(int i = 0; i < numGrunts; i++)
                {
                    x = new Random().Next(0, map.MapChar[0].Length);
                    y = new Random().Next(0, map.MapChar.Length);
                    if (map.IsTileValid(x,y)== '.')
                    {
                        enemies.Add(new Grunt(x, y, settings.GruntAttack, settings.GruntShield, settings.GruntMaxhp, player));
                        ValidLocation = true;
                    }
                }
            }
            Console.WriteLine("Enemies: " + enemies.Count);
            foreach (var enemy in enemies)
            {
                Console.WriteLine(enemies.Count);
                Console.WriteLine("Enemy " + enemy);
                Console.WriteLine(enemy);
            }
            Console.ReadKey();
        }
    }
}