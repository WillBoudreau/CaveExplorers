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
    struct Map
    {
        public string path;
        public string[] Mapstr;
        public char[][] MapChar;
    }
    internal class DisplayMap
    {
        Map map;
        
        public DisplayMap(string path) 
        {
            MapArray(path);
        }
        public void MapArray(string path) 
        {
            map.Mapstr = File.ReadAllLines(path);
            int Mapx = map.Mapstr.Length;
            int Mapy = map.Mapstr[0].Length;
            map.MapChar = new char[Mapx][];
            for (int i = 0; i < Mapx; i++) 
            {
                map.MapChar[i] = map.Mapstr[i].ToCharArray();
                Console.WriteLine(map.Mapstr[i].ToCharArray());
            }
        }
        public void ShowMap()
        {
            for (int i = 0; i < map.MapChar.Length; i++)
            {
                for (int j = 0; j < map.MapChar[i].Length; j++)
                {
                    Console.SetCursorPosition(j, i);
                    switch (map.MapChar[i][j])
                    {
                        case '#':
                            Console.BackgroundColor = ConsoleColor.Gray;
                            Console.Write(map.MapChar[i][j]);
                            break;
                        case '+':
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.WriteLine(map.MapChar[i][j]);
                            break;
                        case '.':
                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                            Console.Write(map.MapChar[i][j]);
                            break;
                    }
                }
            }
        }
    }
}
