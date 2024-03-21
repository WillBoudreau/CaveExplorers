using System;
using System.Collections.Generic;

namespace TextBasedRPG_OOP_WillB
{
    enum EnemType
    {
        Grunt,
        Chaser,
        Runner,
        Boss,
    }
    struct EnemyVals
    {
        public int StartX;
        public int StartY;
        public int enemDamage;
        public bool Enemyturn;
        public bool EnemyActive;
    }
    internal class EnemyManager : Entity
    {
        public char enemyAvatar { get; set; }
        EnemyVals enemyVals = new EnemyVals();
        public EnemType enemType;
        //Class calls
        public static HUD hud;
        public Grunt grunt;
        public Chaser Chaser;
        public Player Player;
        public Settings settings = new Settings();
        public string name;
        public bool BossDead = false;

        public EnemyManager(int StartX, int StartY, EnemType enemType, int damage, int shield, int health)
        {
            healthSys = new HealthSys(health, shield);
            x = StartX;
            y = StartY;
            enemyVals.EnemyActive = true;
            this.enemType = enemType;
            switch (enemType)
            {
                case EnemType.Grunt:
                    enemyAvatar = 'G';
                    break;
                case EnemType.Chaser:
                    enemyAvatar = 'C';
                    break;
                case EnemType.Runner:
                    enemyAvatar = 'R';
                    break;
                case EnemType.Boss:
                    enemyAvatar = 'B';
                    break;
            }
        }
        //Generate Enemies
        public static List<EnemyManager> GenerateEnemies(int numGrunts, int numChasers, int numRunners, int numBoss, Map map)
        {
                Random rnd = new Random();
                Grunt grunt = new Grunt(0, 0, EnemType.Grunt, 1, 1, 3);
                Chaser chaser = new Chaser(0, 0, EnemType.Chaser, 1, 1, 3);
                Runner runner = new Runner(0, 0, EnemType.Runner, 1, 1, 3);
                Player player = new Player();
                List<EnemyManager> enemies = new List<EnemyManager>();
                char[] obstacles = { '#', 'C', '@', '+', 'H', 'S', '*', 'D', '~' };
                for (int i = 0; i < numGrunts; i++)
                {
                    int x;
                    int y;
                    bool ValidSpawn = false;
                    while (!ValidSpawn)
                    {
                        x = rnd.Next(1, map.MapChar[0].Length);
                        y = rnd.Next(1, map.MapChar.Length);
                        if (map.IsTileValid(x, y) == '.')
                        {
                            enemies.Add(new Grunt(x, y, EnemType.Grunt, 1, 1, 3));
                            ValidSpawn = true;
                        }
                    }
                }
            for (int i = 0; i < numChasers; i++)
            {
                int x;
                int y;
                bool ValidSpawn = false;
                while (!ValidSpawn)
                {
                    x = rnd.Next(1, map.MapChar[0].Length);
                    y = rnd.Next(1, map.MapChar.Length);
                    if (map.IsTileValid(x, y) == '.')
                    {
                        enemies.Add(new Chaser(x, y, EnemType.Chaser, 1, 1, 3));
                        ValidSpawn = true;
                    }
                }
            }
            for (int i = 0; i < numRunners; i++)
            {
                int x;
                int y;
                bool ValidSpawn = false;
                while (!ValidSpawn)
                {
                    x = rnd.Next(1, map.MapChar[0].Length);
                    y = rnd.Next(1, map.MapChar.Length);
                    if (map.IsTileValid(x, y) == '.')
                    {
                        enemies.Add(new Runner(x, y, EnemType.Runner, 1, 1, 3));
                        ValidSpawn = true;
                    }
                }
            }
            if (enemies == null)
            {
                    Console.Clear();
                    Console.WriteLine("No Enemiessssss");
                    Console.ReadKey();
                }
            return enemies;

        }
        //move enemy
        public virtual void Move(Player player, List<EnemyManager> enemies)
        {
            int newX = player.x - this.x;
            int newY = player.y - this.y;

            if (Math.Abs(newX) > Math.Abs(newY))
            {
                newX = Math.Sign(newX);
                newY = 0;
            }
            else
            {
                newX = 0;
                newY = Math.Sign(newY);
            }
            POS(newX, newY, player, enemies);
        }
        //Position of enemy
        public void POS(int x, int y, Player player, List<EnemyManager> enemies)
        {
                enemies = new List<EnemyManager>();
            this.x += x;
            this.y += y;
            switch (map.IsTileValid(this.x, this.y))
            {
                case '.':
                    break;
                case '#':
                    this.x -= x;
                    this.y -= y;
                    break;
                case '+':
                    this.x -= x;
                    this.y -= y;
                    break;
                case '(':
                    this.x -= x;
                    this.y -= y;
                    break;
                case ')':
                    this.x -= x;
                    this.y -= y;
                    break;
                case 'H':
                    this.x -= x;
                    this.y -= y;
                    break;
                case 'S':
                    this.x -= x;
                    this.y -= y;
                    break;
                case '*':
                    this.x -= x;
                    this.y -= y;
                    break;
                case 'D':
                    this.x -= x;
                    this.y -= y;
                    break;
                case '~':
                    this.x -= x;
                    this.y -= y;
                    break;
            }
            //Enemy List Check
            for (int i = 0; i < enemies.Count; i++)
            {
                Console.WriteLine(enemies[i].ToString());
            }
            //Checks if the enemy is on the same tile as player
            foreach (EnemyManager enemy in enemies)
            {
                if (enemy != this && enemy.x == this.x && enemy.y == this.y)
                {
                    this.x -= x;
                    this.y -= y;
                    break;
                }
            }
        }
        //Attack Player
        public virtual void Attack(Player player, List<EnemyManager> enemies)
        {
            if (this.x == player.x && this.y == player.y)
            {
                player.healthSys.TakeDamage(0);
                this.x -= x;
                this.y -= y;
            }
        }

        //Display Enemy
        public void DisplayEnemy()//Displays the enemies
        {
            if (healthSys.IsAlive == true)
            {
                Console.SetCursorPosition(this.x, this.y);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.Write(enemyAvatar);
                Console.ResetColor();
            }
            else
            {
                this.x = 0;
                this.y = 0;
            }
        }
    }
}