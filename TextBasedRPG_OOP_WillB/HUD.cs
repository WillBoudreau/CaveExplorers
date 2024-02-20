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
        List<Enemy> enemies;
        public HUD(Player player,List<Enemy>enemies)
        {
            this.player = player;
            this.enemies = enemies;
        } 
        public void DisplayHUD()
        {
            Console.WriteLine("Player Health: " + player.healthSys.health);
            Console.WriteLine("Player Shield: " + player.healthSys.shield);
            Console.WriteLine("Player Score: " + player.score);
            Console.WriteLine("Enemy health: " + enemies[0].healthSys.health);
            Console.WriteLine("Enemy health: "+ enemies[1].healthSys.health);
        }
    }
}
