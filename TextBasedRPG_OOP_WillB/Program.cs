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
            Enemy enemy = new Enemy(map);
            while (true)
            {
                map.MapArray();
                player.DisplayPlayer();
                enemy.DisplayEnemy();
                player.PlayerPOSMove();
                enemy.EnemyPOSMove();
                playerVals.Playerturn = true;
            }
        }
    }
}
