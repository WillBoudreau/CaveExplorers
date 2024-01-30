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
    internal class HealthSys
    {
        public int health = 5;
        HealthVals healthVals = new HealthVals();
        public void SetHealth()
        {
            healthVals.enemyhp = health;
            healthVals.playerhp = health;
        }
        public void GetHealth(int health)
        {
            return health;
        }
        public void Heal(int hp)
        {
            health += hp;
        }
        public void TakeDamage(int damage)
        {
            health -= damage;
        }
    }
}
