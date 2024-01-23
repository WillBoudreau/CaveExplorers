using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG_OOP_WillB
{
    struct HealthVals
    {
        public int enemyhp;
        public int playerhp;
    }
    internal class HealthSystem
    {
        public int health = 100;
        public HealthSystem(int health)
        {
            this.health = health;
        }

    }
}
