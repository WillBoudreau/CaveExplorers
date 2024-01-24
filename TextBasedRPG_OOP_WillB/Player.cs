using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG_OOP_WillB
{
    struct PlayerVals
    {
        public int x; 
        public int y;
        public bool Playerturn;
    }
    internal class Player
    {
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
            Console.SetCursorPosition(1,1);
            Console.Write('*');
        }
    }
}
