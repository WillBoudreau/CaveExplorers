using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG_OOP_WillB
{
    internal class Dialogue
    {
        public string name;
        public string dialogue;
        public List<string> message;
        public Dialogue(string name, string dialogue)
        {
            this.name = name;
            this.dialogue = dialogue;
        }
        public void Talk()
        {
           NextSentence();
        }
        public void NextSentence()
        {
            message = new List<string>();
            message.Add(dialogue);
            for (int i = 0; i < message.Count; i++)
            {
                Console.Clear();
                Console.WriteLine(name + " says: " + message[i]);
                Console.ReadKey();
            }
        }
    }
}
