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
        public int maxHealth;
        public int shield;
        public int maxShield;
        public bool IsAlive = true;
        public HealthSys( int health, int shield)
        {
            health = maxHealth;
            shield = maxShield;
        }
        public void Heal( int Heal)
        {
            health += Heal;
            if(health > 5) 
            {
                health = 5;
            }
        }
        public void TakeDamage(int damage)
        {
            if(shield > 0)
            {
                shield -= damage;
            }
            else if(shield <= 0)
            {
                shield = 0;
                health -= damage;
                if(health <= 0)
                {
                    health = 0;
                    IsAlive = false;
                }
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
