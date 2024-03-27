using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace TextBasedRPG_OOP_WillB
{

    internal class Player : Entity
    {
        public bool Playerturn = true;
        public bool Attacked = false;
        public bool IsSlowed = false;
        Chaser Chaser;
        Runner Runner;
        Grunt Grunt;
        Generation generation;
        public List<EnemyManager> enemies = new List<EnemyManager>();
        List<ItemManager> items;
        NPCManager npc;
        public Stopwatch stopwatch = new Stopwatch();
        public static HUD hud;
        Settings settings;
        public int PlayerDamage;
        public int killCount;
        public Player(List<ItemManager> items, Map map, List<EnemyManager> enemies)
        {
            this.items = items;
            this.map = map;
            this.enemies = enemies;
            settings = new Settings();
            npc = new NPCManager(settings, this, map);
            ExpirenceMan.level = 0;
            ExpirenceMan.xp = 0;
            score = 0;
            x = 3;
            y = 3;
            PlayerDamage = settings.PlayerAttack;
            settings.PlayerMaxhp = 3;
            settings.PlayerAttack = 3;
            settings.PlayerMaxShield = 3;
            healthSys = new HealthSys(settings.PlayerMaxhp, settings.PlayerMaxShield);
        }

        public void Init()
        {
            StartTimer();
        }

        public void Update(List<EnemyManager> enemies, List<ItemManager> items, Chaser chaser, Runner runner, Grunt grunt)
        {
            PlayerPOSMove(this.enemies, items, chaser, runner, grunt);
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
        public void PlayerPOSMove(List<EnemyManager> enemies, List<ItemManager> items, Chaser chaser, Runner runner, Grunt grunt)
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
                            POS(0, -1, enemies, items, chaser, grunt);
                            hud.AddEvent("Player moved up");
                            break;
                        case 'a':
                            POS(-1, 0, enemies, items, chaser, grunt);
                            hud.AddEvent("Player moved left");
                            break;
                        case 's':
                            POS(0, 1, enemies, items, chaser, grunt);
                            hud.AddEvent("Player moved down");
                            break;
                        case 'd':
                            POS(1, 0, enemies, items, chaser, grunt);
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
                        POS(0, 0, enemies, items, chaser, grunt);
                        break;
                    case 'a':
                        POS(0, 0, enemies, items, chaser, grunt);
                        break;
                    case 's':
                        POS(0, 0, enemies, items, chaser, grunt);
                        break;
                    case 'd':
                        POS(0, 0, enemies, items, chaser, grunt);
                        break;
                }
                IsSlowed = false;
            }
            Attacked = false;
        }

        //Player Position
        public void POS(int x, int y, List<EnemyManager> enemies, List<ItemManager> items, Chaser chaser, Grunt grunt)
        { 
            this.x += x;
            this.y += y;

            foreach (EnemyManager enemy in enemies)
            {
                if (this.x == enemy.x && this.y == enemy.y)
                { 
                    this.x -= x;
                    this.y -= y;
                    enemy.IsAttacked = true;
                    enemy.healthSys.TakeDamage(PlayerDamage);
                    hud.lastenemy(enemy);
                    if (enemy.healthSys.IsAlive == false)
                    {
                        enemies.Remove(enemy);
                        score += 10 * ExpirenceMan.level;
                        killCount++;
                        if (enemy.healthSys.IsAlive == false && enemy.enemType == EnemType.Boss)
                        {
                            Win();
                        }
                    }
                    break;
                }
            }
            if (this.x == npc.x && this.y == npc.y)
            {
                this.x -= x;
                this.y -= y;
                npc.Talk("Villager");
            }
            if(items == null)
            {
                Console.Clear();
                Console.WriteLine("No Items");
                Console.ReadKey();
            }
            foreach (ItemManager item in items)
            {
                if (items == null)
                {
                    Console.Clear();
                    Console.WriteLine("No Items");
                    Console.ReadKey();
                }
                if (this.x == item.x && this.y == item.y)
                {
                    this.y -= y;
                    this.x -= x;
                    switch (item.itemType)
                    {
                        case ItemType.Coin:
                            hud.AddEvent("Player collected a coin");
                            map.UpdateMapTile(this.x, this.y, '.');
                            ExpirenceMan.XpUp();
                            break;
                        case ItemType.Health:
                            hud.AddEvent("Player collected a health potion");
                            map.UpdateMapTile(this.x, this.y, '.');
                            healthSys.Heal(1);
                            break;
                        case ItemType.Shield:
                            hud.AddEvent("Player collected a shield potion");
                            map.UpdateMapTile(this.x, this.y, '.');
                            healthSys.ShieldUp(1);
                            break;
                        case ItemType.Damage:
                            hud.AddEvent("Player collected a damage potion");
                            map.UpdateMapTile(this.x, this.y, '.');
                            PlayerDamage += 1;
                            break;
                    }
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
                    //map.LoadNextLevel();
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
                case 'H':
                    hud.AddEvent("Player moved into a Health Pickup");
                    healthSys.Heal(1);
                    map.UpdateMapTile(this.x, this.y, '.');
                    this.x -= x;
                    this.y -= y;
                    break;
                case '*':
                    hud.AddEvent("Player moved into a Coin");
                    score += 10;
                    map.UpdateMapTile(this.x, this.y, '.');
                    this.x -= x;
                    this.y -= y;
                    break;
                case 'S':
                    hud.AddEvent("Player moved into a Shield Pickup");
                    healthSys.ShieldUp(1);
                    map.UpdateMapTile(this.x, this.y, '.');
                    this.x -= x;
                    this.y -= y;
                    break;
                case 'V':
                    npc.Talk("Villager");
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
        //Player win condition
        public void Win()
        {
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