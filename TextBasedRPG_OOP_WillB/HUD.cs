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
        public List<string> EventLog {  get; set; }
       public HUD(Player player,List<Enemy>enemies)
        {
            this.player = player;
            this.enemies = enemies;
            EventLog = new List<string>();
        }
        public void DisplayHUD()
        {
            Console.WriteLine("Player Health: " + player.healthSys.health);
            Console.WriteLine("Player Shield: " + player.healthSys.shield);
            Console.WriteLine("Player Score: " + player.score);
            Console.WriteLine("Player Level: "+ player.ExpirenceMan.level);
            Console.WriteLine("Player Xp: " + player.ExpirenceMan.xp);
            Console.WriteLine("Player POS: " + player.x + " " + player.y);
            DisplayEventLog();
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
        public void AddEvent(string log)
        {
            EventLog.Add(log);
        }
        public void ClearLog()
        {
            EventLog.Clear();
        }
        public void DisplayEventLog()
        {
            Console.WriteLine("Event Log");
            if(EventLog.Count > 3)
            {
                ClearLog();
            }
            foreach(string Log in EventLog)
            {
                Console.WriteLine(Log + "\n");
            }
        }
    }
}
