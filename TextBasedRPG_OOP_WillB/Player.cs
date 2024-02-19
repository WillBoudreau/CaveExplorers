using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace TextBasedRPG_OOP_WillB
{

    internal class Player : Entity
    {
        public bool Playerturn = true;
        public bool Attacked = false;
        public Player()
        {
            score = 0;
            x = 3;
            y = 3;
            heal = 1;
            shieldUp = 1;
            healthSys.health = 3;
            healthSys.shield = 3;
            damage = 3;
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
        public void PlayerPOSMove(Enemy enemy)
        {
            if (Playerturn == true && Attacked == false)
            {
                switch (Input())
                {
                    case 'w':
                        MoveCheck(0, -1, enemy);
                        break;
                    case 'a':
                        MoveCheck(-1, 0,enemy);
                        break;
                    case 's':
                        MoveCheck(0, 1, enemy);
                        break;
                    case 'd':
                        MoveCheck(1, 0, enemy);
                        break;
                }
            }
            Attacked = false;
        }
        public void MoveCheck(int dx, int dy,Enemy enemy)
        {
            int NewX = x + dx;
            int NewY = y + dy;
            char tile = map.IsTileValid(NewX, NewY);
            if(tile=='*')
            {
                map.UpdateMapTile(NewX, NewY,'.');
                score++;
            }
            else if(NewX == enemy.x && NewY == enemy.y)
            {
                enemy.TakeDamage(damage);
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
                case '*':
                    CollectorMan.CollectCoins();
                    score++;
                    break;
                case 'H':
                    CollectorMan.CollectHealth();
                    healthSys.Heal(heal);
                    break;
                case 'S':
                    healthSys.ShieldUp(shieldUp);
                    break;
            }
        }
        public void TakeDamage(int damage)
        {
            if(healthSys.shield > 0)
            {
                healthSys.shield -= damage;
            }
            else
            {
                healthSys.health -= damage;
                if (healthSys.health <= 0)
                {
                    healthSys.health = 0;
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
    }
}