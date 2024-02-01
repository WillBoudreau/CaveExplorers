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
        EnemyVals enemy = new EnemyVals();
        Map mapVals = new Map();
        Entity entity = new Entity();
        Displaymap map = new Displaymap();

        public Enemy()
        {
            entity.x = 15;
            entity.y = 15;
            enemy.Enemyturn = true;
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
            if (enemy.Enemyturn == true)
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
            entity.x += x;
            entity.y += y;
            enemy.Enemyturn = true;
            switch (map.IsTileValid(entity.x, entity.y))
            {
                case '.':
                    break;
                case '#':
                    entity.x -= x;
                    entity.y -= y;
                    break;
                case '+':
                    entity.x -= x;
                    entity.y -= y;
                    break;
                case '*':
                    break;
                case 'H':
                    break;
                case 'P':
                    entity.x -= x;
                    entity.y -= y;
                    break;
            }
        }
        public void DisplayEnemy()
        {
            Console.SetCursorPosition(entity.x, entity.y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.Write('E');
            Console.ResetColor();
        }
    }
}
