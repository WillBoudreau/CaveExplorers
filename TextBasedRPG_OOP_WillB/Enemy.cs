using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG_OOP_WillB
{
    struct EnemyVals
    {
        public int x;
        public int y;
        public int StartX;
        public int StartY;
        public bool Enemyturn;
    }
    internal class Enemy:Entity
    {
        EnemyVals enemy = new EnemyVals();
        Map mapVals = new Map();
        Displaymap map;
        public Enemy(Displaymap map)
        {
            this.map = map;
            enemy.x = 3;
            enemy.y = 3;
            enemy.Enemyturn = true;
        }
        public static char Input()
        {
            ConsoleKeyInfo key = Console.ReadKey(true);
            if (key.KeyChar == 'w')
            {
                return 'w';
            }
            else if (key.KeyChar == 'a')
            {
                return 'a';
            }
            else if (key.KeyChar == 's')
            {
                return 's';
            }
            else if (key.KeyChar == 'd')
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
                switch (Input())
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
            enemy.Enemyturn = true;
            switch (map.IsTileValid(enemy.x, enemy.y))
            {
                case '.':
                    break;
                case '#':
                    enemy.x -= x;
                    enemy.y -= y;
                    break;
                case '+':
                    break;

            }
        }
        public void DisplayPlayer()
        {
            Console.SetCursorPosition(enemy.x, enemy.y);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.Write('$');
            Console.ResetColor();
        }
    }
}
