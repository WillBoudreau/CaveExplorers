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
        public static HUD hud;
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
        public void PlayerPOSMove(List<Enemy> enemies)
        {
            if (Playerturn == true && Attacked == false)
            {
                switch (Input())
                {
                    case 'w':
                        POS(0, -1, enemies);
                        hud.AddEvent("Player moved up");
                        break;
                    case 'a':
                        POS(-1, 0, enemies);
                        hud.AddEvent("Player moved left");
                        break;
                    case 's':
                        POS(0, 1, enemies);
                        hud.AddEvent("Player moved down");
                        break;
                    case 'd':
                        POS(1, 0, enemies);
                        hud.AddEvent("Player moved right");
                        break;
                }
            }
            Attacked = false;
        }
        public void POS(int x, int y, List<Enemy> enemies)
        {
            this.x += x;
            this.y += y;
            switch (map.IsTileValid(this.x, this.y))
            {
                case '.':
                    break;
                case '#':
                    hud.AddEvent("Player moved into a wall");
                    this.x -= x;
                    this.y -= y;
                    break;
                case '+':
                    TakeDamage(1);
                    map.UpdateMapTile(this.x, this.y, '+');
                    return;
                case '*':
                    CollectorMan.CollectCoins();
                    map.UpdateMapTile(this.x, this.y, '.');
                    score++;
                    break;
                case 'H':
                    CollectorMan.CollectHealth();
                    map.UpdateMapTile(this.x, this.y, '.');
                    healthSys.Heal(heal);
                    break;
                case 'S':
                    CollectorMan.CollectShield();
                    map.UpdateMapTile(this.x, this.y, '.');
                    healthSys.ShieldUp(shieldUp);
                    break;
                case '(':
                    this.y += 2;
                    break;
                case ')':
                    this.y -= 2;
                    break;

            }
            map.UpdateMapTile(this.x, this.y, '.');
            foreach (Enemy enemy in enemies)
            {
                if (this.x == enemy.x && this.y == enemy.y)
                {
                    enemy.TakeDamage(1);
                    hud.lastenemy(enemy);
                    this.x -= x;
                    this.y -= y;
                    return;
                }
            }
        }
        public void TakeDamage(int damage)
        {
            if(healthSys.shield > 0)
            {
                healthSys.shield -= damage;
                if(healthSys.shield < 0)
                {
                    healthSys.shield = 0;
                }
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