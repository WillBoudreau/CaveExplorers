using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG_OOP_WillB
{
    struct EntityVals
    {
        public string name;
    }
    internal class Entity
    {
        public HealthSys healthSys;
        public int x;
        public int y;
        public Entity() 
        {
            healthSys = new HealthSys();
        }
    }
}
