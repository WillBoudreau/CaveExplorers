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
        //Runner,

    }
    struct EnemyVals
    {
        public int StartX;
        public int StartY;
        public bool Enemyturn;
        public bool EnemyActive;
    }
    internal class Enemy : Entity
    {
        public EnemType enemType;
        private List<Enemy> enemies;
        EnemyVals enemyVals = new EnemyVals();
        public char enemyAvatar { get; set; }
        Random rnd = new Random();
        public Enemy(int StartX, int StartY, EnemType enemType)
        {
            x = StartX;
            y = StartY;
            healthSys.health = 2;
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
                    //case EnemType.Runner:
                    //    enemyAvatar = 'R';
                    //    break;
            }
        }
        public void EnemyMove(Player player)
        {
            switch (enemType)
            {
                case EnemType.Grunt:
                    MoveRnd(player);
                    break;
                case EnemType.Chaser:
                    MoveChase(player);
                    break;
                    //case EnemType.Runner:
                    //    MoveRun(player);
                    //    break;
            }
        }
        public void MoveRnd(Player player)
        {
            int Move = rnd.Next(1, 5);
            int dx = 0, dy = 0;
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
        public void EnemyCombatCheck(int dx, int dy, Player player)
        {
            int EnemyNewX = x + dx;
            int EnemyNewY = y + dy;
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
                    TakeDamage(1);
                    break;
            }
            if (this.x == player.x && this.y == player.y)
            {
                player.TakeDamage(1);
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

            }
        }
    }
}
