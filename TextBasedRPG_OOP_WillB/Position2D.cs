using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG_OOP_WillB
{
    internal struct POS
    {
        public int x; 
        public int y;
    }
    internal class Position2D
    {
        class PlayerPOS
        {
            POS pos;
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
                if (player.Playerturn == true)
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
        }
    }
}
