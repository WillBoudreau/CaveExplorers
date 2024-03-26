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
        public enum NPCType
        {
            Villager,
        }
        public int x;
        public int y;
        public char npcAvatar;
        public string npcName;
        public int npcHealth;
        public int npcDamage;
        public int npcLevel;
        public bool isAlive = true;
        public NPCType npctype;
        public List<string> message = new List<string>();
        public NPCManager(Settings settings,Player player, Map map)
        {
            x = 0;
            y = 0;
            npcAvatar = ' ';
            npcName = " ";
        }
        public NPCManager(char npcAvatar, int x, int y, string npcName,NPCType npctype, List<string> message)
        {
            this.npcAvatar = npcAvatar;
            this.x = x;
            this.y = y;
            this.npcName = npcName;
            this.npctype = npctype;
            this.message = message;
        }
        public virtual void Update(Map map)
        {
            DisplayNPC(map);
        }
        public static List<NPCManager> GenerateNPCS(int numVillagers, Map map)
        {
            List<NPCManager> npcManagers = new List<NPCManager>();
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

                        npcManagers.Add(new Villager('V', x, y, "Villager", NPCType.Villager,message));
                        map.UpdateMapTile(x,y, 'V');
                        ValidSpawn = true;
                    }
                }
            }
            return npcManagers;
        }
        public virtual void Talk(string name)
        {
            List<string> message = new List<string> 
            {
                            "Traveler!",
                            "You have arrived just in time!",
                            "The village is in danger!",
                            "We are under attack by the Cave Legion!",
                            "Please help us!" 
            };
            npcName = name;
            Console.Clear();
            int currentIndex = 0;

            while (true)
            {
                Console.WriteLine(npcName + " says: " + message[currentIndex]);
                Console.WriteLine("Press Enter to continue");
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.Enter)
                {
                    currentIndex++;
                    Console.Clear();
                    if (currentIndex >= message.Count)
                    {
                        break;
                    }
                    else if(currentIndex == message.Count)
                    {
                        message.Add("Please hurry!");
                    }
                }
            }
        }
        public virtual void DisplayNPC(Map map)
        {
            Console.SetCursorPosition(x, y);
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(npcAvatar);
        }
    }
}
