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
        Map map = new Map();
        public HealthSys healthSys;
        public int x;
        public int y;
        public Entity() 
        {
            this.healthSys = new HealthSys();
        }
        public void POS(int x, int y)
        {
            this.x += x;
            this.y += y;
            Combat(x,y);
            switch (map.IsTileValid(this.x, this.y))
            {
                case '.':
                    break;
                case '#':
                    this.x -= x;
                    this.y -= y;
                    break;
                case '+':
                    healthSys.TakeDamage(1);
                    break;
                case 'H':
                    healthSys.Heal(1);
                    break;
            }
        }
        public void Combat( int x, int y)
        {
            this.x += y;
            this.y += y;
            if
        }
    }
}
