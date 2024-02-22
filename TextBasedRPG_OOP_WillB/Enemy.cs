using System;
using System.Collections.Generic;
using System.Linq;
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
        public int health;
        public int shield;
        public EnemType enemType;
        EnemyVals enemyVals = new EnemyVals();
        public static HUD hud;
        public char enemyAvatar { get; set; }
        public int enemDamage { get; set; }
        Random rnd = new Random();
        public string name;
        public Enemy(int StartX, int StartY, EnemType enemType)
        {
            healthSys = new HealthSys(health, shield);
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
        public List<Enemy> DisplayEnemies()
        {
            List<Enemy> enemList = new List<Enemy>();
                enemList.Add(new Enemy(5, 5, EnemType.Grunt));
                enemList.Add(new Enemy(15,15,EnemType.Chaser));
                enemList.Add(new Enemy(14,14,EnemType.Runner));
                return enemList;
        //    for (int i = 0; i < count; i++)
        //    {
        //        //int Gx = 5;
        //        //int Gy = 5;
        //        //int Cx = 15;
        //        //int Cy = 15;
        //        //int Rx = 14;
        //        //int Ry = 14;
        //        //Enemy enemy = null;
        //        //switch(enemType)
        //        //{
        //        //    case EnemType.Grunt:
        //        //        enemy = new Enemy(Gx,Gy, EnemType.Grunt);
        //        //        break;
        //        //    case EnemType.Chaser:
        //        //        enemy = new Enemy(Cx, Cy, EnemType.Chaser);
        //        //        break;
        //        //    case EnemType.Runner:
        //        //        enemy = new Enemy(Rx,Ry, EnemType.Runner);
        //        //        break;

        //        //}
        //    }
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