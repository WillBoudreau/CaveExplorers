using System.Collections.Generic;
using System.IO;

namespace TextBasedRPG_OOP_WillB
{
    internal class Achievements
    {
        List<EnemyManager> enemyManager = new List<EnemyManager>();
        List<ItemManager> itemManager = new List<ItemManager>();
        Player player;
        HUD hud;
        Map map;
        public Achievements(Player player, List<EnemyManager> enemyManager, List<ItemManager> itemManager, Map map)
        {
            this.hud = new HUD(player, enemyManager, map);
            player = new Player(itemManager, map,enemyManager);
            this.player = player;
            this.enemyManager = enemyManager;
            this.itemManager = itemManager;
            this.map = map;
            AchievementCheck();
        }
        public void AchievementCheck()
        {
            if (File.Exists(@"Achievements.txt"))
            {
                string[] achievements = File.ReadAllLines(@"Achievements.txt");
                foreach (string achievement in achievements)
                {
                    if (achievement == "First Time")
                    {
                        FirstTime();
                    }
                    else if (achievement == "First Blood")
                    {
                        KillCount();
                    }
                    else if (achievement == "Killing Spree")
                    {
                        KillCount();
                    }
                    else if (achievement == "Massacre")
                    {
                        KillCount();
                    }
                }
            }
            else
            {
                FirstTime();
            }
        }
        void FirstTime()
        {
            hud.WriteAchievment("First Time", "You have played the game for the first time");
            File.WriteAllText(@"Achievements.txt", "First Time");
        }
        void KillCount()
        {
            if (player.killCount == 1)
            {
                hud.WriteAchievment("First Blood", "You have killed your first enemy");
            }
            if (player.killCount == 10)
            {
                hud.WriteAchievment("Killing Spree", "You have killed 10 enemies");
            }
            if (player.killCount == 50)
            {
                hud.WriteAchievment("Massacre", "You have killed 50 enemies");
            }
            File.WriteAllText(@"Achievements.txt", "First Blood");
        }
        //void passivist()
        //{
        //    if (player.stopwatch.Elapsed{10})
        //    {
        //        hud.WriteAchievment("Passivist", "You have not killed any enemies for 10 seconds");
        //    }
        //}
    }
}
