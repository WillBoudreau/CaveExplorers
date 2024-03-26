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
        List<EnemyManager> enemies;
        EnemyManager enemy;
        Map map;
        string LastSeen;
        int LastSeenDamage;
        int LastSeenHealth;
        int LastSeenHealthMax;
        public List<string> UnlockedAchievements { get; private set; }
        public List<string> EventLog {  get; set; }
        public List<string> playerAchievements = new List<string>();
       public HUD(Player player,List<EnemyManager>enemies,Map map)
        {
            UnlockedAchievements = new List<string>();
            this.player = player;
            this.enemies = enemies;
            this.map = map;
            EventLog = new List<string>();
        }
        public void Update(List<EnemyManager>enemies)
        {
            DisplayHUD(enemies,map); 
            LastSeenEnemy();
            Legend();
            WriteAchievment("First Blood", "Kill your first enemy");
        }
        public void DisplayHUD(List<EnemyManager> enemies,Map map)
        {
            Console.SetCursorPosition(0,map.MapChar.Length);
            Objectives();
            Console.WriteLine("\n");
            Console.WriteLine("Stats");
            Console.WriteLine(player.x + " " + player.y);
            Console.WriteLine("Player Health: " + player.healthSys.normalHealth);
            Console.WriteLine("Player Shield: " + player.healthSys.normalShield);
            Console.WriteLine("Player Attack: " + player.PlayerDamage);
            Console.WriteLine("Player Score: " + player.score);
            Console.WriteLine("Player Level: " + player.ExpirenceMan.level);
            Console.WriteLine("Player Xp: " + player.ExpirenceMan.xp);
            Console.WriteLine("Player Kills: " + player.killCount);
            Console.WriteLine("\n");
        }
        public void LastSeenEnemy()
        {
            if(LastSeen != null)
            {
                Console.WriteLine("\nLast Enemy encountered: " + LastSeen + " | " +LastSeen+" Max Health "+LastSeenHealthMax+ " | " + LastSeen+ " Current Health "+LastSeenHealth);    
            }
        }
        public void Legend()
        {
            Console.WriteLine("P = Player" + " "+ "G = Grunt" + " "+ "C = Chaser" +" "+ "R = Runner" + "  " + "B = Boss");
        }
        public void lastenemy(EnemyManager enemy)
        {
            LastSeen = enemy.name;
            LastSeenHealth = enemy.healthSys.normalHealth;
            LastSeenHealthMax = enemy.healthSys.maxHealth;
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
            Console.WriteLine("\n");
            Console.WriteLine("Current Objectives: ");
            List<string> CurrentObjective = new List<string>();
            CurrentObjective.Add("Collect as many coins as possible");
            CurrentObjective.Add("Defeat the Boss (B)");
            foreach(string objective in CurrentObjective) 
            {
                Console.WriteLine(objective);
            }
        }
        public void WriteAchievment(string name, string Description)
        {
            Console.SetCursorPosition(map.MapChar.GetLength(0) + 50, 10);
            Console.Write("Achievments " + name);
            foreach(string achievement in playerAchievements)
            {
                Console.WriteLine(achievement);
            }
        }
    }
}