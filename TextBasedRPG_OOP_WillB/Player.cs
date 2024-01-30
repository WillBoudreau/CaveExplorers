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
        public bool Playerturn;
    }
    internal class Player:Entity
    {
        PlayerVals player = new PlayerVals();
        Map mapVals = new Map();
        Entity entity = new Entity();
        Displaymap map;
        public Player(Displaymap map) 
        {
            this.map = map;
            entity.x = 3;
            entity.y = 3;
            player.Playerturn = true;
        }
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
            if(player.Playerturn == true)
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
            entity.x += x;
            entity.y += y;
            player.Playerturn = true;
            switch(map.IsTileValid(entity.x, entity.y)) 
            {
                case '.':
                break;
                case '#':
                    entity.x -= x;
                    entity.y -= y;
                    break;
                case '+':
                    break;

            }
        }
        public void DisplayPlayer()
        { 
            Console.SetCursorPosition(entity.x,entity.y);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.Write('$');
            Console.ResetColor();
        }
    }
}
