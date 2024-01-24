using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG_OOP_WillB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                Player player = new Player();
                Enemy enemy = new Enemy();
                string path = @"Map.txt";
                DisplayMap map = new DisplayMap(path);
                map.ShowMap();
                player.DisplayPlayer();
                player.PlayerPOSMove();

            }
        }
    }
}
