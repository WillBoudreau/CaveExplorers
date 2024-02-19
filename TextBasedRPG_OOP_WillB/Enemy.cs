using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG_OOP_WillB
{
    struct EnemyVals
    {
        public int StartX;
        public int StartY;
        public bool Enemyturn;
        public bool EnemyActive;
    }
    internal class Enemy:Entity
    {
        EnemyVals enemyVals = new EnemyVals();
        public Enemy(int StartX, int StartY)
        {
            x = StartX;
            y = StartY;
            healthSys.health = 2;
            enemyVals.EnemyActive = true;
        }
        public static char EnemyInput()
        {
            Random rnd = new Random();
           int Move =  rnd.Next(1,4);
            if (Move == 1)
            {
                return 'w';
            }
            else if (Move == 2)
            {
                return 'a';
            }
            else if (Move == 3)
            {
                return 's';
            }
            else if (Move == 4)
            {
                return 'd';
            }
            else
            {
                return 'e';
            }
        }
        public void EnemyPOSMove(Player player)
        {
            {
                switch (EnemyInput())
                {
                    case 'w':
                        EnemyMoveCheck(0, -1, player);
                        break;
                    case 'a':
                        EnemyMoveCheck(-1,0,player);
                        break;
                    case 's':
                        EnemyMoveCheck(0,1,player);
                        break;
                    case 'd':
                        EnemyMoveCheck(1,0,player);
                        break;
                }

            }
        }
        public void EnemyMoveCheck(int dx, int dy, Player player)
        {
            int EnemyNewX = x + dx;
            int EnemyNewY = y + dy;
            if(EnemyNewX == player.x &&  EnemyNewY == player.y)
            {
                player.TakeDamage(1);
            }
            else
            {
                POS(dx, dy);
            }
        }
        public void POS(int x, int y)
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
        }
        public void TakeDamage(int damage)
        {
            healthSys.health -= damage;
            if (healthSys.health <= 0)
            {
                healthSys.health = 0;
                enemyVals.EnemyActive = false;
            }
        }
        public void DisplayEnemy()
        {
            if (enemyVals.EnemyActive == true)
            {
                Console.SetCursorPosition(this.x, this.y);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.Write('E');
                Console.ResetColor();
            }
            else
            {

            }
        }
    }
}
