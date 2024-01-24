using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG_OOP_WillB
{
    struct PlayerVals
    {
        public int x; 
        public int y;
        public int StartX;
        public int StartY;
        public bool Playerturn;
    }
    internal class Player
    {
        PlayerVals player = new PlayerVals();
        DamageSystem Combat = new DamageSystem();
        public static char Input()
        {
            ConsoleKeyInfo key = Console.ReadKey(true);
            if(key.KeyChar == 'w')
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
            PlayerVals pos = new PlayerVals();
            if(pos.Playerturn == true)
            {
                switch (Player.Input())
                {
                    case 'w':
                        PlayerPOS(0, -1);
                        break;
                    case 'a':
                        PlayerPOS(-1, 0);
                        break;
                    case 's':
                        PlayerPOS(0,1);
                        break;
                    case 'd':
                        PlayerPOS(1, 0);
                        break;
                }

            }
        }
        public void PlayerPOS(int x, int y)
        {
            PlayerVals position = new PlayerVals();
            position.x += x;
            position.y += y;
            position.Playerturn = true;

        }
        public void DisplayPlayer()
        {
            player.StartX = 1;
            player.StartY = 1;
            Console.SetCursorPosition(player.StartX,player.StartY);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.Write('$');
            Console.ResetColor();
        }
    }
}
