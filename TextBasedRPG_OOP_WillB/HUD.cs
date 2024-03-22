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
       public HUD(Player player,List<EnemyManager>enemies)
        {
            UnlockedAchievements = new List<string>();
            this.player = player;
            this.enemies = enemies;
            EventLog = new List<string>();
        }
        public void Update(List<EnemyManager>enemies)
        {
            DisplayHUD(enemies);
            LastSeenEnemy();
        }
        public void Draw(List<EnemyManager>enemies)
        {
            
        }
        public void DisplayHUD(List<EnemyManager> enemies)
        {
            Console.WriteLine();
            Console.WriteLine("\n");
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
                Console.WriteLine("\nLast Enemy encountered: " + LastSeen + "\n" +LastSeen+" Max Health "+LastSeenHealthMax+ "\n" + LastSeen+ " Current Health "+LastSeenHealth);    
            }
            else
            {
                Random random = new Random();
                switch(random.Next(1, 5))
                {
                    case 1:
                    Console.WriteLine("Go find some friends");
                    break;
                    case 2:
                    Console.WriteLine("You are alone");
                    break;
                    case 3:
                    Console.WriteLine("Stop being Chill like Will");
                    break;
                    case 4:
                    Console.WriteLine("You been on for a while... maybe you should go outside");
                    break;
                    case 5:
                    Console.WriteLine("You are the only one left");
                    break;
                }

            }

        }
        public void Legend()
        {
            Console.WriteLine("P = Player\nG = Grunt\nC = Chaser\nR = Runner\nB = Boss");
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
            Console.WriteLine();
            Console.WriteLine("\n");
            Console.WriteLine("Current Objectives: ");
            List<string> CurrentObjective = new List<string>();
            CurrentObjective.Add("Collect as many coins as possible");
            CurrentObjective.Add("Defeat all Enemies(G)(C)(R)");
            foreach(string objective in CurrentObjective) 
            {
                Console.WriteLine(objective);
            }
        }
        //public void WriteAchievment(string name,string Description)
        //{
        //    Console.WriteLine("Achievments");
            
        //    playerAchievements.Add(name);
        //    playerAchievements.Add(Description);
        //    foreach(string achievement in playerAchievements)
        //    {
        //        Console.WriteLine(achievement);
        //    }
        //}
    }
}