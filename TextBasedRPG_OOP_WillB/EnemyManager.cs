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
        public Runner runner;
        public Settings settings = new Settings();
        public string name;
        public bool BossDead = false;
        public bool IsAttacked;
        public Player player;
        private ItemManager itemManager;
        public List<EnemyManager> enemManagers;
        private List<ItemManager> items;
        private Map map = new Map();
        public EnemyManager(Settings settings, Player player, List<ItemManager> items, Map map)
        {
            map = new Map();
            this.player = player;
            this.items = items;
            this.map = map;
            this.map = map;
            enemyVals.EnemyActive = true;
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
        public EnemyManager(int StartX, int StartY, EnemType enemType, int damage, int shield, int health, Player player, List<ItemManager> item)
        {
            healthSys = new HealthSys(health, shield);
            this.player = player;
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
        public void Init()
        {
            GenerateEnemies(settings.numGrunt, settings.numChaser, settings.numRunner, settings.numBoss, map, player, items, settings);
        }
        public void Update(Player player, List<EnemyManager> enemies, List<ItemManager> items)
        {
            Move(player, enemies, items);
            Attack(player, enemies);
        }
        public void Draw(Player player,List<EnemyManager>enemies, List<ItemManager>items)
        {
            foreach (EnemyManager enemy in enemies)
            {
                enemy.DisplayEnemy(player);
            }
        }
        //Generate Enemies
        public static List<EnemyManager> GenerateEnemies(int numGrunts, int numChasers, int numRunners, int numBoss, Map map, Player player, List<ItemManager> items, Settings settings)
        {
            Random rnd = new Random();
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
                        enemies.Add(new Grunt(x, y, EnemType.Grunt, 1, 1, 3, player, items));
                        map.UpdateMapTile(x, y, 'G');
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
                        enemies.Add(new Chaser(x, y, EnemType.Chaser, 1, 1, 3, player, items));
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
                        enemies.Add(new Runner(x, y, EnemType.Runner, 1, 1, 3, player, items));
                        ValidSpawn = true;
                    }
                }
            }
            for (int i = 0; i < numBoss; i++)
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
                        enemies.Add(new Boss(x, y, EnemType.Boss, 1, 1, 3, player, items));
                        map.UpdateMapTile(x, y, 'B');
                        ValidSpawn = true;
                    }
                }
            }
            return enemies;
            
        }
        //move enemy
        public virtual void Move(Player player, List<EnemyManager> enemies, List<ItemManager> items)
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
            POS(newX, newY, player, enemies, items);
        }
        //Position of enemy
        public void POS(int x, int y, Player player, List<EnemyManager> enemies, List<ItemManager> items)
        {
            enemies = new List<EnemyManager>();
            //items = new List<ItemManager>();
            this.x += x;
            this.y += y;
            if (this.x == player.x && this.y == player.y)
            {

                player.healthSys.TakeDamage(1);
                this.x -= x;
                this.y -= y;
            }
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
                Console.WriteLine(enemies[i]);
            }
            //Checks if the enemy is on the same tile as player
            //foreach (EnemyManager enemy in enemies)
            //{
            //    if (enemy != this && enemy.x == this.x && enemy.y == this.y)
            //    {
            //        this.x -= x;
            //        this.y -= y;
            //        break;
            //    }
            //}
            foreach (ItemManager item in items)
            {
                if (item.x == this.x && item.y == this.y)
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
                player.healthSys.TakeDamage(1);
                this.x -= x;
                this.y -= y;
            }
        }

        //Display Enemy
        public virtual void DisplayEnemy(Player player)
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
                sound.PlaySound("EnemyDeath");
                this.x = 0;
                this.y = 0;
            }
        }
    }
}