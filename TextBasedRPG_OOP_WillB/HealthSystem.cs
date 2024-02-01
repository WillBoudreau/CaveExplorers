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
        public int enemyhp;
        public int playerhp;
        public int health;
        public int Attack;
        public HealthSys()
        {
            
        }
        public void SetHealth()
        {
            enemyhp = health;
            playerhp = health;
        }
        public int GetHealth(int health)
        {
            this.health = health;
            SetHealth();
            return health;
        }
        public int GetAttack(int attack)
        {
            this.Attack = attack;
            return attack;

        }
        public void SetAttack()
        {

        }
        public void Heal(int hp)
        {
            health += hp;
        }
        public void TakeDamage(int damage)
        { 
            playerhp -= damage;
            enemyhp -= damage;
            if(playerhp <= 0)
            {
                playerhp = 0;
            }
        }
    }
}
