using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG_OOP_WillB
{
    internal class HealthSys
    {
        public int health;
        public int shield;
        public HealthSys()
        {
            health = 0;
        }
        public void Heal( int Heal)
        {
            health += Heal;
            if(health > 5) 
            {
                health = 5;
            }
        }
        public void ShieldUp( int ShieldUp)
        {
            shield += ShieldUp;
            if(shield > 5)
            {
                shield = 5;
            }
        }
    }
}
