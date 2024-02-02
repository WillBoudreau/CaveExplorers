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
        public ShowHUD(string entity, int health, int damage) 
        {
            health = this.health.playerhp;
            damage = this.health.Attack;
        }
    }
}
