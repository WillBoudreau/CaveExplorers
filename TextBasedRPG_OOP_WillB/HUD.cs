using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG_OOP_WillB
{
    internal class HUD
    {
        Player player;
        Enemy enemy;
        public HUD(Player player, Enemy enemy)
        {
            this.player = player;
            this.enemy = enemy;
        } 
        public void DisplayHUD()
        {
            Console.WriteLine("Player Health: " + player.healthSys.health);
            Console.WriteLine("Player Shield: " + player.healthSys.shield);
        }
    }
}
