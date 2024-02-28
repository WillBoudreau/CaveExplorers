using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG_OOP_WillB
{
    internal class HUD
    {
        Player player;
        List<Enemy> enemies;
        Map map;
        string LastSeen;
        int LastSeenDamage;
        int LastSeenHealth;
        int LastSeenHealthMax;
        public List<string> EventLog {  get; set; }
       public HUD(Player player,List<Enemy>enemies)
        {
            this.player = player;
            this.enemies = enemies;
            EventLog = new List<string>();
        }
        public void DisplayHUD()
        { 
            Console.WriteLine("\n");
            Objectives();
            Console.WriteLine("Stats");
            Console.WriteLine("Player Health: " + player.healthSys.normalHealth);
            Console.WriteLine("Player Shield: " + player.healthSys.normalShield);
            Console.WriteLine("Player Attack: " + player.PlayerDamage);
            Console.WriteLine("Player Score: " + player.score);
            Console.WriteLine("Player Level: "+ player.ExpirenceMan.level);
            Console.WriteLine("Player Xp: " + player.ExpirenceMan.xp);
            Console.WriteLine("\n");
        }
        public void LastSeenEnemy()
        {
            if(LastSeen != null)
            {
                Console.WriteLine("\nLast Enemy encountered: " + LastSeen +"\n" + LastSeen +" Damage "+ LastSeenDamage + "\n" +LastSeen+" Max Health "+LastSeenHealthMax+ "\n" + LastSeen+ " Current Health "+LastSeenHealth);    
            }

        }
        public void Legend()
        {
            Console.WriteLine("P = Player\nG = Grunt\nC = Chaser\nR = Runner\nB = Boss");
        }
        public void lastenemy(Enemy enemy)
        {
            LastSeen = enemy.name;
            LastSeenHealth = enemy.healthSys.normalHealth;
            LastSeenHealthMax = enemy.healthSys.maxHealth;
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
            int DisplayEventLogLimit = 3;
            Console.WriteLine("Event Log");
            int LogCount = 0;
            foreach(string Log in EventLog)
            {
                if(LogCount > DisplayEventLogLimit)
                {
                    break;
                }
                Console.WriteLine(Log);
                LogCount++;
            }
            EventLog.Clear();
        }
        public void Objectives()
        {
            Console.WriteLine("Current Objectives: ");
            List<string> CurrentObjective = new List<string>();
            CurrentObjective.Add("Collect as many coins as possible");
            CurrentObjective.Add("Defeat all Enemies(G)(C)(R)");
            foreach(string objective in CurrentObjective) 
            {
                Console.WriteLine(objective);
            }
        }
    }
}