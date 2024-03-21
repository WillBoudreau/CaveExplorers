using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mime;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace TextBasedRPG_OOP_WillB
{

    internal class Player : Entity
    {
        public bool Playerturn = true;
        public bool Attacked = false;
        public bool IsSlowed = false;
        List<EnemyManager> enemies =  new List<EnemyManager>();
        List<ItemManager> items;
        private Stopwatch stopwatch = new Stopwatch();
        public static HUD hud;
        Settings settings;
        public int PlayerDamage = 3;
        public Player()
        {
            Console.Clear();
            items = new List<ItemManager>();
            Console.WriteLine(items.Count());
            Console.ReadKey();
            settings = new Settings();
            ExpirenceMan.level = 0;
            ExpirenceMan.xp = 0;
            score = 0;
            x = 3;
            y = 3;
            settings.PlayerMaxhp = 3;
            settings.PlayerAttack = 3;
            settings.PlayerMaxShield = 3;
            healthSys = new HealthSys(settings.PlayerMaxhp, settings.PlayerMaxShield);
        }
        public void Init()
        {
            StartTimer();
        }
        //public void Update()
        //{
        //    PlayerPOSMove(enemies);
        //}
        public void Draw()
        {
            DisplayPlayer();
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
        public void PlayerPOSMove(List<EnemyManager> enemies,List<ItemManager> items)
        {
            items = new List<ItemManager>();
            //PlayerItemCheck(x, y);
            if (items == null)
            {
                //Console.Clear();
                //Console.Write(enemies.Count);
                //Console.ReadKey();
                //Console.Write(items.Count);
                //Console.ReadKey();
                Console.WriteLine("No Items1");
                Console.ReadKey();
                if(items.Count == 0)
                {
                    Console.Clear();
                    Console.WriteLine("No Items2");
                    Console.ReadKey();
                }
            }
            if (Playerturn == true && Attacked == false && IsSlowed == false)
            {
                if(!IsSlowed)
                {
                    switch (Input())
                    {
                        case 'w':
                            POS(0, -1, enemies, items);
                            hud.AddEvent("Player moved up");
                            break;
                        case 'a':
                            POS(-1, 0, enemies, items);
                            hud.AddEvent("Player moved left");
                            break;
                        case 's':
                            POS(0, 1, enemies, items);
                            hud.AddEvent("Player moved down");
                            break;
                        case 'd':
                            POS(1, 0, enemies, items);
                            hud.AddEvent("Player moved right");
                            break;
                    }

                }
            }
            else if(IsSlowed == true)
            {
                switch(Input())
                {
                    case 'w':
                        POS(0,0,enemies, items);
                        break;
                    case 'a':
                        POS(0,0, enemies, items);
                        break;
                    case 's':
                        POS(0,0, enemies, items);
                        break;
                    case 'd':
                        POS(0,0, enemies,items);
                        break;
                }
                IsSlowed = false;
            }
            Attacked = false;
        }
        public void POS(int x, int y, List<EnemyManager> enemies, List<ItemManager> items)
        {
            if(items == null)
            {
                Console.Clear();
                Console.WriteLine("No Items1");
                Console.ReadKey();
                if(items.Count == 0)
                {
                    Console.Clear();
                    Console.WriteLine("No Items2");
                    Console.ReadKey();
                }
            }
            this.x += x;
            this.y += y;
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
            }
            //PlayerItemCheck(x ,y);
            if (IsSlowed == true)
            {
                map.UpdateMapTile(this.x, this.y, '~');
            }
            else
            {
                map.UpdateMapTile(this.x, this.y, '.');
            }
            foreach (EnemyManager enemy in enemies)
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
            foreach (ItemManager itemMan in items)
            {
                if (items == null)
                {
                    Console.Clear();
                    Console.WriteLine("No Items1");
                    Console.ReadKey();
                    if (items.Count == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("No Items2");
                        Console.ReadKey();
                    }
                }
                if(this.x == itemMan.x && this.y == itemMan.y)
                {
                    if(itemMan.ItemAvatar == '*')
                    {
                        score += 1;
                        this.y -= y;
                        this.x -= x;
                        items.Remove(itemMan);
                        map.UpdateMapTile(this.x, this.y, '.');
                        return;
                    }
                    if(itemMan.ItemAvatar == 'H')
                    {
                        healthSys.normalHealth += 1;
                        items.Remove(itemMan);
                    }
                    if(itemMan.ItemAvatar == 'S')
                    {
                        healthSys.normalShield += 1;
                        items.Remove(itemMan);
                    }
                    if(itemMan.ItemAvatar == 'D')
                    {
                        PlayerDamage += 1;
                        items.Remove(itemMan);
                    }
                    items.Remove(itemMan);
                    return;
                }
            }
        }
        //void PlayerItemCheck( int x,int y)
        //{
        //    //this.x += x;
        //    //this.y += y;
        //    foreach (ItemManager item in list)
        //    {
        //        if (this.x == item.x && this.y == item.y)
        //        {
        //            this.x -= x;
        //            this.y -= y;
        //            if (item.ItemAvatar == '*')
        //            {
        //                score += 1;
        //                this.y -= y;
        //                this.x -= x;
        //                list.Remove(item);
        //                map.UpdateMapTile(this.x, this.y, '.');
        //                return;
        //            }
        //            if (item.ItemAvatar == 'H')
        //            {
        //                healthSys.normalHealth += 1;
        //                list.Remove(item);
        //            }
        //            if (item.ItemAvatar == 'S')
        //            {
        //                healthSys.normalShield += 1;
        //                list.Remove(item);
        //            }
        //            if (item.ItemAvatar == 'D')
        //            {
        //                PlayerDamage += 1;
        //                list.Remove(item);
        //            }
        //            list.Remove(item);
        //            return;
        //        }
        //    }


        //}
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