using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG_OOP_WillB
{
    internal class Entity
    {
        public HealthSys healthSys;
        public int x;
        public int y;
        public Entity() 
        {
            Console.WriteLine("Entity has spawned");
            healthSys = new HealthSys();
        }

    }
}
