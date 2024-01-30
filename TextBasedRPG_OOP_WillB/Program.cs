using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace TextBasedRPG_OOP_WillB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Displaymap map = new Displaymap();
            Player player = new Player(map);
            PlayerVals playerVals = new PlayerVals();
            while (true)
            {
                map.MapArray();
                player.DisplayPlayer();
                player.PlayerPOSMove();
                playerVals.Playerturn = true;
                player.healthSys.GetHealth(100);
            }
        }
    }
}
