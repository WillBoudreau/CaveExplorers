using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG_OOP_WillB
{
    internal class Map
    {
            public string path;
             string[] Mapstr;
            public char[][] MapChar;
        public Map()
        {
            MapArray();
        }
        public void UpdateMapTile(int x, int y, char tile)
        {
            MapChar[y][x] = tile;
            Console.SetCursorPosition(x, y);
            Console.Write(tile);
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
            
            ShowMap();
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
                        case '(':
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(MapChar[i][j]);
                            break;
                        case ')':
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(MapChar[i][j]);
                            break;
                        case 'S':
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write(MapChar[i][j]);
                            break;
                    }
                }
            }
            Console.ResetColor();
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

    }
}
