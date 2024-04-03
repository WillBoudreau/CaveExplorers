using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TextBasedRPG_OOP_WillB
{
    internal class Villager:NPCManager
    {
        //public List<string> message = new List<string>();
        public Villager(char npcAvatar, int x, int y,string name, NPCType npctype,List<string>message) : base(npcAvatar, x, y,name,npctype,message)
        {
            this.message = message;
            npctype = NPCType.Villager;
            npcAvatar = 'V';
            this.x = x;
            this.y = y;
            this.npcName = name;
        }
        public override void Update(Map map)
        {
            DisplayNPC(map);
        }
        public override void Talk(string name)
        {
            Console.Clear();
            int currentIndex = 0;
            while (true)
            {
                Console.Clear();
                Console.WriteLine(npcName + "1");
                Console.WriteLine(message.Count);
                Console.WriteLine(currentIndex);
                Console.ReadKey();
                Console.WriteLine(npcName + " says: " + message[currentIndex]);
                Console.WriteLine("Press Enter to continue");
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.Enter)
                {
                    currentIndex++;
                    if (currentIndex >= message.Count)
                    {
                        break;
                    }
                }
            }
        }
        public override void DisplayNPC(Map map)
        {
            Console.SetCursorPosition(x, y);
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(npcAvatar);
            Console.ResetColor();
        }
        //public void NextSentence()
        //{
        //    message = new List<string>();
        //    message.Add(Dialogue);
        //    for (int i = 0; i < message.Count; i++)
        //    {
        //        Console.Clear();
        //        Console.WriteLine(npcName + " says: " + message[i]);
        //        Console.ReadKey();
        //    }
        }

    }
