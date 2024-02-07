using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG_OOP_WillB
{
    struct PlayerVals
    {
        public bool Playerturn;
        public string name;
    }
    internal class Player : Entity
    {
        PlayerVals playerVals = new PlayerVals();
        public Player()
        {
            x = 3;
            y = 3;
            playerVals.Playerturn = true;
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
        public void PlayerPOSMove()
        {
            if (playerVals.Playerturn == true)
            {
                switch (Input())
                {
                    case 'w':
                        POS(0, -1);
                        break;
                    case 'a':
                        POS(-1, 0);
                        break;
                    case 's':
                        POS(0, 1);
                        break;
                    case 'd':
                        POS(1, 0);
                        break;
                }

            }
        }
        public void DisplayPlayer()
        {
            Console.SetCursorPosition(this.x, this.y);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.Write('P');
            Console.ResetColor();
        }
        public void AttackEnemy(Enemy enemy)
        {
            if (Math.Abs(this.x - enemy.x) <= 1 && Math.Abs(this.y - enemy.y) <= 1)
            {
                enemy.healthSys.TakeDamage(2);
                
                if (enemy.healthSys.enemyhp <= 0)
                {
                    enemy.healthSys.enemyhp = 0;
                }
                return;
            }
        }
    }
}
