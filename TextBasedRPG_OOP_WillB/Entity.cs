using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG_OOP_WillB
{
    internal class Entity
    {
        public Map map;
        public HealthSys healthSys;
        public CollectorManager CollectorMan;
        public ExpirenceManager ExpirenceMan;
        public int x;
        public int y;
        public int heal;
        public int damage;
        public int score;
        public int shieldUp;
        public Entity()
        {
            
            this.CollectorMan = new CollectorManager();
            this.map = new Map();
            this.ExpirenceMan = new ExpirenceManager();
        }
       
    }
}