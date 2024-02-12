using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG_OOP_WillB
{
    struct EntityVals
    {
        
    }
    internal class Entity
    {
        public Map map;
        public HealthSys healthSys;
        public int x;
        public int y;
        public Entity() 
        {
            this.map = new Map();
            this.healthSys = new HealthSys();
        }
    }
}
