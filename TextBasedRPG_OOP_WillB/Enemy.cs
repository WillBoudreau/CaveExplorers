using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG_OOP_WillB
{
    struct EnemyVals
    {
        public int StartX;
        public int StartY;
        public bool Enemyturn;
    }
    internal class Enemy:Entity
    {
        EnemyVals enemyVals = new EnemyVals();
        Map mapVals = new Map();
        Entity enemy = new Entity();
        Displaymap map = new Displaymap();

        public Enemy()
        {
            enemy.x = 15;
            enemy.y = 15;
            enemyVals.Enemyturn = true;
            Console.Clear();
            Console.WriteLine(enemy.x + " " + enemy.y);
            Console.ReadKey();
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
        public void EnemyPOSMove()
        {
            if (enemyVals.Enemyturn == true)
            {
                switch (EnemyInput())
                {
                    case 'w':
                        EnemyPOS(0, -1);
                        break;
                    case 'a':
                        EnemyPOS(-1, 0);
                        break;
                    case 's':
                        EnemyPOS(0, 1);
                        break;
                    case 'd':
                        EnemyPOS(1, 0);
                        break;
                }

            }
        }
        public void EnemyPOS(int x, int y)
        {
            enemy.x += x;
            enemy.y += y;
            enemyVals.Enemyturn = true;
            switch (map.IsTileValid(enemy.x, enemy.y))
            {
                case '.':
                    break;
                case '#':
                    enemy.x -= x;
                    enemy.y -= y;
                    break;
                case '+':
                    enemy.x -= x;
                    enemy.y -= y;
                    break;
                case '*':
                    break;
                case 'H':
                    break;
                case 'P':
                    enemy.x -= x;
                    enemy.y -= y;
                    break;
            }
        }
        public void DisplayEnemy()
        {
            Console.SetCursorPosition(enemy.x, enemy.y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.Write('E');
            Console.ResetColor();
        }
    }
}
