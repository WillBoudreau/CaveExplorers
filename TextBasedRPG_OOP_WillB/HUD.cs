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
        Enemy LastSeen;
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
            Console.WriteLine("Player POS: " + player.x + " " + player.y);
            if(LastSeen != null)
            {
                Console.WriteLine("Last Enemy encountered: " + LastSeen);
            }
        }
        public void lastenemy(Enemy enemy)
        {
            LastSeen = enemy;
        }
    }
}
