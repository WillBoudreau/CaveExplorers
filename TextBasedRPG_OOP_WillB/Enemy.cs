using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

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
    internal class Enemy : Entity
    {
        Settings settings = new Settings();
        EnemyVals enemyVals = new EnemyVals();
        public EnemType enemType;
        public static HUD hud;
        public string name;
        int enemHealth;
        int enemShield;
         public bool BossDead = false;

        public Enemy(int StartX, int StartY, EnemType enemType, int damage, int shield, int health)
        {
            healthSys = new HealthSys(enemHealth, enemShield);
            x = StartX;
            y = StartY;
            enemyVals.EnemyActive = true;
            this.enemType = enemType;
            switch (enemType)
            {
                case EnemType.Grunt:
                    break;
                case EnemType.Chaser:
                    break;
                case EnemType.Runner:
                    break;
                case EnemType.Boss:
                    break;
            }
        }

        public virtual void Move(Player player,List<Enemy> enemies)
        {
            switch (enemType)
            {
                case EnemType.Grunt:
                    
                    Move(player, enemies);
                    break;
                case EnemType.Chaser:
                    Move(player, enemies);
                    break;
                case EnemType.Runner:
                    Move(player,enemies);
                    break;
                case EnemType.Boss:
                    Move(player, enemies);
                    break;
            }
        }
        
        public void POS(int x, int y,Player player,List<Enemy> enemies)
        {
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
            foreach (Enemy enemy in enemies)
            {
                if(enemy != this && enemy.x == this.x && enemy.y == this.y)
                {
                    this.x -= x;
                    this.y -= y;
                }
                if (this.x == player.x && this.y == player.y)
                {
                    player.healthSys.TakeDamage(enemDamage);
                    this.x -= x;
                    this.y -= y;
                }
            }
        }

        public static List<Enemy> GenerateEnenmies( int numGrunts, int numChasers, int numRunners, int numBoss,Map map)
        {
                int[,] ChaserPOS = { { 15, 15 }, { 14, 14 } };
                int[,] RunnerPOS = { { 16,16}, { 17,17 } }; 
                List<Enemy> enemies = new List<Enemy>();
            Random rnd = new Random();
            char[] obstacles = { '#', 'C', '@', '+', 'H', 'S', '*', 'D', '~' };
                for (int i = 0; i < numGrunts; i++)
                {
                    int x;
                    int y;
                    bool ValidSpawn = false;
                    while(!ValidSpawn)
                    {
                        x = rnd.Next(1, map.MapChar[0].Length);
                        y = rnd.Next(1,map.MapChar.Length);
                        if(map.IsTileValid(x, y) == '.')
                        {
                            enemies.Add(new Enemy(x, y,EnemType.Grunt));
                            ValidSpawn = true;
                        }
                    }
                }
                for (int i = 0; i < ChaserPOS.GetLength(0); i++)
                {
                    enemies.Add(new Enemy(ChaserPOS[i,0], ChaserPOS[i,1], EnemType.Chaser));
                }
                for (int i = 0; i < RunnerPOS.GetLength(0); i++)
                {
                    enemies.Add(new Enemy(RunnerPOS[i,0], RunnerPOS[i,1], EnemType.Runner));
                }
                enemies.Add(new Enemy(20, 20, EnemType.Boss));
                return enemies;
        }

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