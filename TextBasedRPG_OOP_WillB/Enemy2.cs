using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG_OOP_WillB
{
    struct Enemy2Vals
    {
        public int StartX;
        public int StartY;
        public bool Enemyturn;
        public bool EnemyActive;
    }
    internal class Enemy2 : Entity
    {
        EnemyVals enemyVals = new EnemyVals();
        Displaymap map = new Displaymap();
        public bool EnemyActive = true;
        public Enemy2()
        {
            x = 5;
            y = 13;
            enemyVals.Enemyturn = true;
        }
        public static char Enemy2Input()
        {
            Random rnd = new Random();
            int Move = rnd.Next(1, 3);
            if (Move == 1)
            {
                return 'w';
            }
            else if (Move == 2)
            {
                return 'a';
            }
            else
            {
                return 's';
            }
        }
        public void EnemyPOS2Move()
        {
            if (enemyVals.Enemyturn == true)
            {
                switch (Enemy2Input())
                {
                    case 'w':
                        Enemy2POS(0, -1);
                        break;
                    case 'a':
                        Enemy2POS(0, 1);
                        break;
                }

            }
        }
        public void Enemy2POS(int x, int y)
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
                case '*':
                    break;
                case 'H':
                    break;
            }
        }
        public void DisplayEnemy()
        {

            Console.SetCursorPosition(this.x, this.y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.Write('S');
            Console.ResetColor();

        }
        public void AttackPlayer(Player player)
        {
            if (Math.Abs(this.x - player.x) <= 1 && Math.Abs(this.y - player.y) <= 1)
            {
                player.healthSys.TakeDamage(2);
            }
        }
    }
}
