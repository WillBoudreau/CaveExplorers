using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;

namespace TextBasedRPG_OOP_WillB
{

    internal class Player : Entity
    {
        public bool Playerturn = true;
        public bool Attacked = false;
        public bool IsSlowed = false;
        public Stopwatch stopwatch = new Stopwatch();
        public static HUD hud;
        Settings settings;
        public int killCount;
        public int Attack;
        public Player(Map map)
        {   
            settings = new Settings();
            ExpirenceMan.level = 0;
            ExpirenceMan.xp = 0;
            score = 0;
            x = 3;
            y = 3;
            settings.PlayerMaxhp = 3;
            settings.PlayerAttack = 3;
            settings.PlayerMaxShield = 3;
            Attack = settings.PlayerAttack;
            healthSys = new HealthSystem(settings.PlayerMaxhp, settings.PlayerMaxShield);
        }

        public void Init()
        {
            StartTimer();
        }

        public void Update(List<Enemy>enemies, List<Items> items,Map map)
        {
            PlayerPOSMove(enemies, items,map);
        }

        public void Draw()
        {
            DisplayPlayer();
        }

        //Takes input from the player
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

        //Player Movement   
        public void PlayerPOSMove(List<Enemy> enemies, List<Items> items,Map map)
        {
            if (items == null)
            {
                Console.WriteLine("No Items1");
                Console.ReadKey();
                if (items.Count == 0)
                {
                    Console.Clear();
                    Console.WriteLine("No Items2");
                    Console.ReadKey();
                }
            }
           
            if (Playerturn == true && Attacked == false && IsSlowed == false)
            {
                if (!IsSlowed)
                {
                    switch (Input())
                    {
                        case 'w':
                            POS(0, -1, enemies, items, map);
                            hud.AddEvent("Player moved up");
                            break;
                        case 'a':
                            POS(-1, 0, enemies, items, map);
                            hud.AddEvent("Player moved left");
                            break;
                        case 's':
                            POS(0, 1, enemies, items, map);
                            hud.AddEvent("Player moved down");
                            break;
                        case 'd':
                            POS(1, 0, enemies, items, map);
                            hud.AddEvent("Player moved right");
                            break;
                    }

                }
            }
            else if (IsSlowed == true)
            {
                switch (Input())
                {
                    case 'w':
                        POS(0, 0, enemies, items,map);
                        break;
                    case 'a':
                        POS(0, 0, enemies, items,map);
                        break;
                    case 's':
                        POS(0, 0, enemies, items,map);
                        break;
                    case 'd':
                        POS(0, 0, enemies, items,map);
                        break;
                }
                IsSlowed = false;
            }
            Attacked = false;
        }

        //Player Position
        public void POS(int x, int y, List<Enemy> enemies, List<Items> items,Map map)
        { 
            this.x += x;
            this.y += y;
            foreach(Enemy enemy in enemies)
            {
                if (this.x == enemy.x && this.y == enemy.y)
                {
                    this.y -= y;
                    this.x -= x;
                    enemy.isAttacked = true;
                    enemy.healthSys.TakeDamage(settings.PlayerAttack);
                    hud.LastSeenEnemy();
                    if(enemy.healthSys.IsAlive == false)
                    {
                        killCount++;
                        score += 10;
                        if(enemy is Boss)
                        {
                            score += 50;
                        }
                    }
                }
            }
            foreach (Items item in items)
            {
                if (this.x == item.x && this.y == item.y)
                {
                    this.y -= y;
                    this.x -= x;
                    item.UseItem(this);
                    items.Remove(item);
                    break;
                }
            }
            switch (map.IsTileValid(this.x, this.y))
            {

                case '.':
                    IsSlowed = false;
                    break;
                case '#':
                    hud.AddEvent("Player moved into a wall");
                    this.x -= x;
                    this.y -= y;
                    break;
                case '+':
                    healthSys.TakeDamage(2);
                    hud.AddEvent("Player moved onto a spike trap");
                    map.UpdateMapTile(this.x, this.y, '+');
                    return;
                case '^':
                    hud.AddEvent("Player collected a Level Up");
                    map.UpdateMapTile(this.x, this.y, '.');
                    this.x -= x;
                    this.y -= y;
                    ExpirenceMan.LevelUp();
                    break;
                case '>':
                    hud.AddEvent("Player used the Teleporter");
                    this.y += 2;
                    break;
                case '<':
                    hud.AddEvent("Player used the Teleporter");
                    this.y -= 2;
                    break;
                case '~':
                    IsSlowed = true;
                    hud.AddEvent("Player moved in water");
                    break;
                case 'C':
                    map.UpdateMapTile(this.x, this.y, 'C');
                    ExpirenceMan.LevelDown();
                    hud.AddEvent("Player recieved a curse");
                    this.x -= x;
                    this.y -= y;
                    break;
                case '@':
                    Console.Clear();
                    map.LoadNextLevel();
                    break;
                case '!':
                    Win();
                    break;
                case 'G':
                    hud.AddEvent("Player moved into a Grunt");
                    healthSys.TakeDamage(1);
                    this.x -= x;
                    this.y -= y;
                    break;
                case 'V':
                    //npc.Talk("Villager");
                    this.x -= x;
                    this.y -= y;
                    break;
            }
            if (IsSlowed == true)
            {
                map.UpdateMapTile(this.x, this.y, '~');
            }
            else
            {
                map.UpdateMapTile(this.x, this.y, '.');
            }
        }
        public void DamageUp(int damage)
        {
            settings.PlayerAttack += damage;
            Attack = settings.PlayerAttack;
        }
        //Player win condition
        public void Win()
        {
            Console.ResetColor();
                StopTimer();
                Console.Clear();
                Console.WriteLine("You Win");
                Console.WriteLine("Score: " + score);
                Console.WriteLine("Kills: " + killCount);
                Console.WriteLine("Time: " + stopwatch.Elapsed);
                Console.ReadKey();
                Environment.Exit(0);
        }
        //Starts the timer for the player
        public void StartTimer()
        {
            stopwatch.Start();
        }
        public void StopTimer()
        {
            stopwatch.Stop();
            TimeSpan timeSpan = stopwatch.Elapsed;
            string EndTime = String.Format("{0:00}:{1:00}:{2:00}", timeSpan.TotalHours, timeSpan.TotalMinutes, timeSpan.TotalSeconds);
            Console.WriteLine("Level Completed in: " + EndTime);
        }

        //Displays the player
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