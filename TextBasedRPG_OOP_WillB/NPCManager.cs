using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG_OOP_WillB
{
    internal class NPCManager
    {
        public int x;
        public int y;
        public char npcAvatar;
        public string npcName;
        public int npcHealth;
        public int npcDamage;
        public int npcLevel;
        public bool isAlive = true;
        public List<string> message = new List<string>();
        public List<NPC>NPCs { get; set; }
        public NPCManager(char npcAvatar, int x, int y, string npcName, List<string> message)
        {
            this.npcAvatar = npcAvatar;
            this.x = x;
            this.y = y;
            this.npcName = npcName;
            this.message = message;
        }
        public void DrawNPC()
        {
            foreach (NPC npc in NPCs)
            {
                npc.DisplayNPC();
            }
        }
        public void GenerateNPCS(List<NPC> NPCs, int numVillagers, Map map)
        {
            Random rnd = new Random();
            for (int i = 0; i < numVillagers; i++)
            {
                int x;
                int y;
                bool ValidSpawn = false;
                while (!ValidSpawn)
                {
                    x = rnd.Next(1, map.MapChar[0].Length);
                    y = rnd.Next(1, map.MapChar.Length);
                    if (map.MapChar[y][x] == 'N')
                    {
                        List<string> message = new List<string>{};

                        NPCs.Add(new Villager('V', x, y, "Villager",message));
                        map.UpdateMapTile(x,y, 'V');
                        ValidSpawn = true;
                    }
                }
            }
        }
    }
}
