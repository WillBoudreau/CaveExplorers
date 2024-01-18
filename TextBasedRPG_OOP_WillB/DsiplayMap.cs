using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG_OOP_WillB
{
    struct Map
    {
        public string path;
        public string[] Mapstr;
        public char[][] MapChar;
    }
    internal class DisplayMap
    {
        Map map = new Map();
        public DisplayMap() 
        {
            for(int i = 0; i < map.MapChar.Length; i++)
            {
                for(int k = 0; k < map.MapChar[i].Length; k++)
                {
                    Console.SetCursorPosition(k, i);
                    switch (map.MapChar[i][k])
                    {
                        case '#':
                            Console.BackgroundColor = ConsoleColor.Gray;
                            Console.Write(map.MapChar[i][k]);
                            break;
                        case '+':
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Write(map.MapChar[i][k]);
                            break;
                        case '.':
                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                            Console.Write(map.MapChar[i][k]);
                            break;
                        case '*':
                            Console.BackgroundColor = ConsoleColor.Yellow;
                            Console.Write(map.MapChar[i][k]);
                            break;
                    }
                }
            }
        }
    }
    internal class MapArray
    {
        public MapArray()
        {
            Map map = new Map();
            map.path = @"Map.txt";
            map.Mapstr = File.ReadAllLines(map.path);
            int MapY = map.Mapstr.Length;
            int MapX = map.Mapstr[0].Length;
            map.MapChar = new char[MapY][];
            for(int i = 0; i < MapY; i++)
            {
                map.MapChar[i] = map.Mapstr[i].ToCharArray();
            }
        }
    }
}
