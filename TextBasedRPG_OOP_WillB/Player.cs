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
        Map mapVals = new Map();
        Entity player = new Entity();
        Displaymap map = new Displaymap();
        Enemy enemy = new Enemy();
        public Player()
        {
            player.x = 3;
            player.y = 3;
            playerVals.Playerturn = true;
            Console.Clear();
            Console.WriteLine(player.x + " " + player.y);
            Console.ReadKey();
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
                        PlayerPOS(0, -1);
                        break;
                    case 'a':
                        PlayerPOS(-1, 0);
                        break;
                    case 's':
                        PlayerPOS(0, 1);
                        break;
                    case 'd':
                        PlayerPOS(1, 0);
                        break;
                }

            }
        }
        public void PlayerPOS(int x, int y)
        {
            player.x += x;
            player.y += y;
            playerVals.Playerturn = true;
            Combat(x, y);
            switch (map.IsTileValid(player.x, player.y))
            {
                case '.':
                    break;
                case '#':
                    player.x -= x;
                    player.y -= y;
                    break;
                case '+':
                    healthSys.TakeDamage(1);
                    break;
                case 'H':
                    healthSys.Heal(1);
                    break;
            }
        }
        public void DisplayPlayer()
        {
            Console.SetCursorPosition(player.x, player.y);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.Write('P');
            Console.ResetColor();
        }
        public void Combat(int x, int y)
        {
            Console.Clear();
            Console.ReadKey();
            if (player.x == enemy.x && player.y == enemy.y)
            {
               healthSys.TakeDamage(1);
            }
        }
    }
}
