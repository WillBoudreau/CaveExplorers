using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace TextBasedRPG_OOP_WillB
{
    internal class Map
    {
        public string path;
        string[] Mapstr;
        public char[][] MapChar;
        public List<ItemManager> itemManager;
        public List<Enemy> enemies;
        public Settings settings = new Settings();
        public Map()
        {
            enemies = new List<Enemy>();
            itemManager = new List<ItemManager>();
            MapArray();
        }
        public void Init()
        {
            //GenerateLlevel(0);
        }
        public void Update()
        {
            MapArray();
            ShowMap();
        }
        public void Draw()
        {
            ShowMap();
        }
        public void UpdateMapTile(int x, int y, char tile)
        {
            MapChar[y][x] = tile;
            Console.SetCursorPosition(x, y);
            Console.Write(tile);
            ShowMap();
        }
        public void MapArray()
        {
            path = @"Map.txt";
            Mapstr = File.ReadAllLines(path);
            int Mapx = Mapstr.Length;
            int Mapy = Mapstr[0].Length;
            MapChar = new char[Mapx][];
            for (int i = 0; i < Mapx; i++)
            {
                MapChar[i] = Mapstr[i].ToCharArray();
            }
            Draw();
        }
        public void ShowMap()
        {
            for (int i = 0; i < MapChar.Length; i++)
            {
                for (int j = 0; j < MapChar[i].Length; j++)
                {

                    Console.SetCursorPosition(j, i);

                    switch (MapChar[i][j])
                    {
                        case '#':
                            Console.BackgroundColor = ConsoleColor.Gray;
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write(MapChar[i][j]);
                            break;
                        case '+':
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.WriteLine(MapChar[i][j]);
                            break;
                        case '.':
                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Write(MapChar[i][j]);
                            break;
                        case 'H':
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(MapChar[i][j]);
                            break;
                        case '*':
                            Console.BackgroundColor = ConsoleColor.DarkYellow;
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write(MapChar[i][j]);
                            break;
                        case '<':
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(MapChar[i][j]);
                            break;
                        case '>':
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(MapChar[i][j]);
                            break;
                        case 'S':
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write(MapChar[i][j]);
                            break;
                        case 'D':
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write(MapChar[i][j]);
                            break;
                        case '^':
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write(MapChar[i][j]);
                            break;
                        case '~':
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine(MapChar[i][j]);
                            break;
                        case 'C':
                            Console.BackgroundColor = ConsoleColor.DarkMagenta;
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine(MapChar[i][j]);
                            break;
                        case '@':
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine(MapChar[i][j]);
                            break;
                        case '{':
                            Console.BackgroundColor = ConsoleColor.Gray;
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.WriteLine(MapChar[i][j]);
                            break;
                        case '!':
                            Console.BackgroundColor = ConsoleColor.DarkYellow;
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine(MapChar[i][j]);
                            break;
                        case '|':
                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Write(MapChar[i][j]);
                            break;
                        case 'V':
                            Console.BackgroundColor = ConsoleColor.DarkMagenta;
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write(MapChar[i][j]);
                            break;
                        case ')':
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.Write(MapChar[i][j]);
                            break;
                    }
                }
            }
            Console.ResetColor();
        }
        public void LoadNextLevel()
        {
            path = @"Level2.txt";
            Mapstr = File.ReadAllLines(path);
            int MapX = Mapstr.Length;
            int MapY = Mapstr[0].Length;
            MapChar = new char[MapX][];
            for (int i = 0; i < MapX; i++)
            {
                MapChar[i] = Mapstr[i].ToCharArray();
            }
            Draw();
            Console.Clear();
            //GenerateLlevel(1);
        }
        public char IsTileValid(int x, int y)
        {
            if (y >= 0 && y < MapChar.Length && x >= 0 && x < MapChar[y].Length)
            {
                return MapChar[y][x];
            }
            else
            {
                return ' ';
            }
        }
        //    public void GenerateLlevel(int level)
        //    {
        //        ClearLists();
        //        switch (level)
        //        {
        //            case 0:
        //                Console.Clear();
        //                itemManager = ItemManager.GenerateItems(settings.numCoins, settings.numHealth, settings.numShield, settings.numDamage, this);

        //                Console.CursorVisible = false;
        //                //Update();
        //                break;
        //            case 1:
        //                Console.Clear();
        //                itemManager = ItemManager.GenerateItems(settings.numCoins, settings.numHealth, settings.numShield, settings.numDamage, this);
        //                Console.CursorVisible = false;
        //                //Update();
        //                break;
        //            case 2:
        //                Console.CursorVisible = false;
        //                //Update();
        //                break;
        //        }
        //    }
        //    void ClearLists()
        //    {
        //        //if (enemies != null)
        //        //{
        //        //    enemies.Clear();
        //        //}
        //        if (itemManager != null)
        //        {
        //            itemManager.Clear();
        //        }
        //    }
        //}
    }
}
