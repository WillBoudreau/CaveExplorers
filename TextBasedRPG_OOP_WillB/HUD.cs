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
        public void EndScreen(Enemy enemy)
        {
            Console.WriteLine("You where killed by a " + enemy.name);
            Console.WriteLine("Tip:");
            if(LastSeen =="Grunt")
            {
                Console.WriteLine("The Grunt moves in random directions randomly, try to corner it's escape");
            }
            if(LastSeen =="Chaser")
            {
                Console.WriteLine("The Chaser will chase after you, the only way to win is to stand your ground");
            }
        }
    }
}
