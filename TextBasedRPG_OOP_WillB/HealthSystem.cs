using System;
using System.Collections.Generic;
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
        public int enemyhp;
        public int playerhp;
        public int health = 5;
        HealthVals healthVals = new HealthVals();
        public void SetHealth()
        {
            enemyhp = health;
            playerhp = health;
        }
        public int GetHealth(int health)
        {
            this.health = health;
            return health;
        }
        public void Heal(int hp)
        {
            health += hp;
        }
        public void TakeDamage(int damage)
        {
            playerhp -= damage;
        }
    }
}
