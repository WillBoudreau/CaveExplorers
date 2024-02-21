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
        string LastSeen;
        int LastSeenDamage;
        int LastSeenHealth;
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
            UpdateLog();
            if(LastSeen != null)
            {
                Console.WriteLine("Last Enemy encountered: " + LastSeen +"\n" + LastSeen +" Damage "+ LastSeenDamage + "\n" + LastSeen+ " Health "+LastSeenHealth);
            }
        }
        public void lastenemy(Enemy enemy)
        {
            LastSeen = enemy.name;
            LastSeenHealth = enemy.healthSys.health;
            LastSeenDamage = enemy.enemDamage;
        }
        public void UpdateLog()
        {
            if(player.x == player.x - 1)
            {
                Console.WriteLine("Player was moved to the Left");
            }
            if(player.y == player.y - 1)
            {

            }
        }
    }
}
