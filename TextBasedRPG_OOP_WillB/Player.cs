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
        public int health;
        public int shield;
        public int PlayerDamage = 3;
        public Player()
        {

            ExpirenceMan.level = 0;
            ExpirenceMan.xp = 0;
            score = 0;
            x = 3;
            y = 3;
            healthSys = new HealthSys(health, shield);
            healthSys.Heal(3);
            healthSys.ShieldUp(3);
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
                    healthSys.TakeDamage(1);
                    hud.AddEvent("Player moved onto a spike trap");
                    map.UpdateMapTile(this.x, this.y, '+');
                    return;
                case '*':
                    //CollectorMan.CollectCoins();
                    hud.AddEvent("Player collected a coin");
                    map.UpdateMapTile(this.x, this.y, '.');
                    score++;
                    break;
                case 'H':
                    //CollectorMan.CollectHealth();
                    hud.AddEvent("Player collected health");
                    map.UpdateMapTile(this.x, this.y, '.');
                    this.x -= x;
                    this.y -= y;
                    healthSys.Heal(1);
                    break;
                case 'S':
                    //CollectorMan.CollectShield();
                    hud.AddEvent("Player collected shield");
                    map.UpdateMapTile(this.x, this.y, '.');
                    healthSys.ShieldUp(1);
                    break;
                case 'D':
                    hud.AddEvent("Player collected a damage boost");
                    map.UpdateMapTile(this.x, this.y, '.');
                    this.x -= x;
                    this.y -= y;
                    damage++;
                    break;
                case '^':
                    hud.AddEvent("Player collected a Level Up");
                    map.UpdateMapTile(this.x, this.y, '.');
                    this.x -= x;
                    this.y -= y;
                    ExpirenceMan.LevelUp();
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
                    enemy.healthSys.TakeDamage(PlayerDamage);
                    this.x -= x;
                    this.y -= y;
                    hud.lastenemy(enemy);
                    break;
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