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
        public int normalHealth;
        public int maxHealth;
        public int normalShield;
        public int maxShield;
        public bool IsAlive = true;
        public HealthSys( int maxHealth, int maxShield)
        {
            normalHealth = maxHealth;
            normalShield = maxShield;
        }
        public void Heal( int Heal)
        {
            normalHealth += Heal;
            if (normalHealth > 5) 
            {
                normalHealth = 5;
            }
        }
        public void TakeDamage(int damage)
        {
            if (normalShield > 0)
            {
                normalShield -= damage;
                if (normalShield <= 0)
                {
                    normalShield = 0;
                }
            }
            else if (normalShield <= 0)
            {
                normalShield = 0;
                normalHealth -= damage;
                if(normalHealth <= 0)
                {
                    normalHealth = 0;
                    IsAlive = false;
                }
            }
        }
        public void ShieldUp( int ShieldUp)
        {
            normalShield += ShieldUp;
            if(normalShield > 5)
            {
                normalShield = 5;
            }
        }
    }
}
