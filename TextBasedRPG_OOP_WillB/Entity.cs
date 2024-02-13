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
        public CombatManager CombatMan;
        public int x;
        public int y;
        public int damage;
        public Entity()
        {
            this.CombatMan = new CombatManager();
            this.map = new Map();
            this.healthSys = new HealthSys();
        }
       
    }
}