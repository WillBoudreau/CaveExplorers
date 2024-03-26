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
        List<EnemyManager> Enemies;
        List<NPCManager> NPCs;
        Settings settings;
        Map map;
        Player player;
        public Generation()
        {
            map = new Map();
            Items = new List<ItemManager>();
            Enemies = new List<EnemyManager>();
            NPCs = new List<NPCManager>();
            settings = new Settings();
            player = new Player(Items,map);
        }
        public void Init()
        {
            Enemies.AddRange(EnemyManager.GenerateEnemies(settings.numGrunt, settings.numChaser, settings.numRunner, settings.numBoss, map, player, Items, settings));
            Items.AddRange(ItemManager.GenerateItems(settings.numCoins, settings.numHealth, settings.numShield, settings.numDamage, map));
            NPCs = NPCManager.GenerateNPCS(settings.numVillager, map);
            Enemies.AddRange(Enemies);
            Items.AddRange(Items);
            NPCs.AddRange(NPCs);
        }
        public void Update()
        {
            foreach (var enemy in Enemies)
            {
                enemy.Update(player,Enemies,Items);
            }
            foreach (var item in Items)
            {
                item.Update(map);
            }
            foreach (var npc in NPCs)
            {
                npc.Update(map);
            }
        }
    }
}
