using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG_OOP_WillB
{
    internal class Generation
    {
        List<ItemManager> Items;
        List<Enemy> Enemies;
        List<NPCManager> NPCs;
        Settings settings;
        Map map;
        Player player;
        public Generation()
        {
            Items = new List<ItemManager>();
            Enemies = new List<Enemy>();
            NPCs = new List<NPCManager>();
            settings = new Settings();
            map = new Map();
            player = new Player(map);
        }
        public void Init()
        {
            generateLevel(0);
            //Enemies.AddRange(EnemyManager.GenerateEnemies(settings.numGrunt, settings.numChaser, settings.numRunner, settings.numBoss, map, player, Items, settings));
            //Items.AddRange(ItemManager.GenerateItems(settings.numCoins, settings.numHealth, settings.numShield, settings.numDamage, map));
        }
        //public void Update()
        //{
        //    foreach (var enemy in Enemies)
        //    {
        //        enemy.Update(player,Enemies,Items);
        //    }
        //}
        //public void Draw()
        //{
        //    foreach (var enemy in Enemies)
        //    {
        //        enemy.Draw(player,Enemies,Items);
        //    }
        //}
        public void generateLevel(int level)
        {
            switch(level)
            {
                case 0:
                    //Enemies.AddRange( EnemyManager.GenerateEnemies(settings.numGrunt, settings.numChaser, settings.numRunner, settings.numBoss, map, player, Items, settings));
                    break;
                case 1:
                    break;
            }
        }
        void ClearLists()
        {
            Enemies.Clear();
            Items.Clear();
            NPCs.Clear();
        }
    }
}
