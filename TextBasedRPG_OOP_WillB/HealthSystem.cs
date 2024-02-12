using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG_OOP_WillB
{
    struct HealthVals
    {

    }
    internal class HealthSys
    {
        public int health;
        public HealthSys()
        {
            health = 0;
        }
        public void Heal( int Heal)
        {
            health += Heal;
        }
    }
}
