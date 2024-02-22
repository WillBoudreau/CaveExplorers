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
        int currentObjective;
        public HUD(Player player,List<Enemy>enemies)
        {
            currentObjective = 0;
            this.player = player;
            this.enemies = enemies;
        }
        public void DisplayHUD()
        {
            EventLog(player, enemies);
            Console.WriteLine("Player Health: " + player.healthSys.health);
            Console.WriteLine("Player Shield: " + player.healthSys.shield);
            Console.WriteLine("Player Damage: " + player.damage);
            Console.WriteLine("Player Level: ");
            Console.WriteLine("Player Score: " + player.score);
            Console.WriteLine("Player POS: " + player.x + " " + player.y);
            DisplayLegend();
            if(LastSeen != null)
            {
                Console.WriteLine("Last Enemy encountered: " + LastSeen +"\n" + LastSeen +" Damage "+ LastSeenDamage + "\n" + LastSeen+ " Health "+LastSeenHealth);
            }
        }
        public void DisplayLegend()
        {
            Console.WriteLine("-------------\nLegend: \nPlayer = P\nGrunt = G\nChaser = C\nRunner = R\nBoss = B\n-------------\nHealth Pickup = H\nShield Pickup = S\nDamage Pickup = D\n-------------\nSpikeTraps = +\nWater = ~\nTeleporter = (( or ))");
        }
        public void EventLog(Player player,List <Enemy> enemies)
        {
            
        }
        public void lastenemy(Enemy enemy)
        {
            LastSeen = enemy.name;
            LastSeenHealth = enemy.healthSys.health;
            LastSeenDamage = enemy.enemDamage;
        }
        public void EndScreen(Enemy enemy)
        {
            //Console.WriteLine("You where killed by a " + enemy.name);
            //Console.WriteLine("Tip:");
            //if(LastSeen =="Grunt")
            //{
            //    Console.WriteLine("The Grunt moves in random directions randomly, try to corner it's escape");
            //}
            //if(LastSeen =="Chaser")
            //{
            //    Console.WriteLine("The Chaser will chase after you, the only way to win is to stand your ground");
            //}
        }
        public void Win()
        {
            Console.Clear();
            Console.WriteLine("Congrats! You win! Your final stats are: \n Ramaining Health: " + player.healthSys.health + "\nRemaining Shield: " +  player.healthSys.shield + "\nScore: " + player.score);
            Console.WriteLine();
            Console.WriteLine("Press any key to quit");
            Console.ReadKey();
        }
    }
}
