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
        public char enemyAvatar { get; set; }
        public int enemDamage { get; set; }
        Random rnd = new Random();
        EnemyVals enemyVals = new EnemyVals();
        public EnemType enemType;
        public static HUD hud;
        public string name;
        int enemHealth;
        int enemShield;
        public Enemy(int StartX, int StartY, EnemType enemType)
        {
            healthSys = new HealthSys(enemHealth, enemShield);
            damage = enemyVals.enemDamage;
            x = StartX;
            y = StartY;
            enemyVals.EnemyActive = true;
            this.enemType = enemType;
            switch (enemType)
            {
                case EnemType.Grunt:
                    enemyAvatar = 'G';
                    name = "Grunt";
                    healthSys.Heal(1);
                    break;
                case EnemType.Chaser:
                    enemyAvatar = 'C';
                    name = "Chaser";
                    healthSys.Heal(2);
                    break;
                case EnemType.Runner:
                    enemyAvatar = 'R';
                    name = "Runner";
                    healthSys.Heal(1);
                    break;
                case EnemType.Boss:
                    enemyAvatar = 'B';
                    name = "Boss";
                    healthSys.Heal(4);
                    break;
            }
        }
        public void EnemyMove(Player player,List<Enemy> enemies)
        {
            switch (enemType)
            {
                case EnemType.Grunt:
                    enemDamage = 1;
                    MoveRnd(player, enemies);
                    break;
                case EnemType.Chaser:
                    enemDamage = 2;
                    MoveChase(player, enemies);
                    break;
                case EnemType.Runner:
                    enemDamage = 1;
                    MoveRun(player,enemies);
                    break;
                case EnemType.Boss:
                    enemDamage = 3;
                    MoveBoss(player, enemies);
                    break;
            }
        }
        public void MoveBoss(Player player,List<Enemy> enemies)
        {
            int distanceToplayer = Math.Abs(player.x - x) + Math.Abs(player.y - y);
            
            if(distanceToplayer <= 5)
            {
                MoveChase(player, enemies);
                
            }
        }
        public void MoveRun(Player player,List<Enemy>enemies)
        {
            int dx = player.x + x;
            int dy = player.y + y;
            if (Math.Abs(dx) > Math.Abs(dy))
            {
                dx = Math.Sign(dx);
                dy = 0;
            }
            else
            {
                dx = 0;
                dy = Math.Sign(dy);
            }
            POS(dx, dy, player,enemies);
        }
        public void MoveRnd(Player player,List<Enemy>enemies)
        {
            int Move = rnd.Next(1, 5);
            int dx = 0, 
                dy = 0;
            switch (Move)
            {
                case 1:
                    
                    dy = -1;
                    break;
                case 2:
                    
                    dx = -1;
                    break;
                case 3:
                   
                    dy = 1;
                    break;
                case 4:
                   
                    dx = 1;
                    break;
            }
            POS(dx, dy, player,enemies);
        }
        public void MoveChase(Player player,List<Enemy>enemies)
        {
            int dx = player.x - x;
            int dy = player.y - y;
            if (Math.Abs(dx) > Math.Abs(dy))
            {
                
                dx = Math.Sign(dx);
                dy = 0;
            }
            else
            {
                
                dx = 0;
                dy = Math.Sign(dy);
            }
            POS(dx, dy,player, enemies);
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
                    break;
            }
            foreach (Enemy enemy in enemies)
            {
                if(enemy != this && enemy.x == this.x && enemy.y == this.y)
                {
                    this.x -= x;
                    this.y -= y;
                }
            }
            if (this.x == player.x && this.y == player.y)
            {
                player.healthSys.TakeDamage(enemDamage);
                this.x -= x;
                this.y -= y;
            }
        }
        public static List<Enemy> GenerateEnenmies()
        {
            int[,] GruntPOS = { { 14, 9 }, { 14, 8 }, { 13, 9 }, { 15, 9 }, {5,5} };
            int[,] ChaserPOS = { { 15, 15 }, { 14, 14 } };
            int[,] RunnerPOS = { { 16,16}, { 17,17 } }; 
            List<Enemy> enemies = new List<Enemy>();
            for (int i = 0; i < GruntPOS.GetLength(0); i++)
            {
                enemies.Add(new Enemy(GruntPOS[i, 0], GruntPOS[i,1], EnemType.Grunt));
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