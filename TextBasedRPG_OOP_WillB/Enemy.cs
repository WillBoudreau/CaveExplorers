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
        public EnemType enemType;
        EnemyVals enemyVals = new EnemyVals();
        public char enemyAvatar { get; set; }
        public int enemDamage { get; set; }
        Random rnd = new Random();
        public string name;
        public Enemy(int StartX, int StartY, EnemType enemType)
        {
            healthSys.health = 0;
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
                    healthSys.health += 2;
                    break;
                case EnemType.Chaser:
                    enemyAvatar = 'C';
                    name = "Chaser";
                    healthSys.health += 1;
                    break;
                case EnemType.Runner:
                    enemyAvatar = 'R';
                    name = "Runner";
                    healthSys.health += 2;
                    break;
                case EnemType.Boss:
                    enemyAvatar = 'B';
                    name = "Boss";
                    healthSys.health += 3;
                    break;
            }
        }
        public void EnemyMove(Player player)
        {
            switch (enemType)
            {
                case EnemType.Grunt:
                    enemDamage = 1;
                    MoveRnd(player);
                    break;
                case EnemType.Chaser:
                    enemDamage = 2;
                    MoveChase(player);
                    break;
                case EnemType.Runner:
                    enemDamage = 1;
                    MoveRun(player);
                    break;
                case EnemType.Boss:
                    enemDamage = 3;
                    MoveBoss(player);
                    break;
            }
        }
        public void MoveBoss(Player player)
        {
            int distanceToplayer = Math.Abs(player.x - x) + Math.Abs(player.y - y);
            if(distanceToplayer <= 3)
            {
                MoveChase(player);
            }
        }
        public void MoveRun(Player player)
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
            POS(dx, dy, player);
        }
        public void MoveRnd(Player player)
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
            POS(dx, dy, player);
        }
        public void MoveChase(Player player)
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
            POS(dx, dy,player);
        }
        public void POS(int x, int y,Player player)
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
            if (this.x == player.x && this.y == player.y)
            {
                player.TakeDamage(enemDamage);
                this.x -= x;
                this.y -= y;
                return;
            }
        }
        public void TakeDamage(int damage)//Allows the enemies to take damage
        {
            healthSys.health -= damage;
            if (healthSys.health <= 0)
            {
                healthSys.health = 0;
                enemyVals.EnemyActive = false;
            }
        }
        public void DisplayEnemy()//Displays the enemies
        {
            if (enemyVals.EnemyActive == true)
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