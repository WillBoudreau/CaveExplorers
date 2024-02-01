using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG_OOP_WillB
{
    internal class ShowHUD
    {
        HealthSys health = new HealthSys();
        PlayerVals player = new PlayerVals();
        EntityVals entity1 = new EntityVals();
        public ShowHUD(string entity, int health, int damage) 
        {
            health = this.health.playerhp;
            entity = entity1.name;
            damage = this.health.Attack;
        }
    }
}
