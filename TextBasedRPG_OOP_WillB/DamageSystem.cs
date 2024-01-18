using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG_OOP_WillB
{
    internal class DamageSystem:HealthSystem
    {
        public DamageSystem() 
        {
            PlayerVals pos = new PlayerVals();
            EnemyVals enemy = new EnemyVals();
            if (pos.Playerturn)
            {
                if(pos.x == enemy.x && pos.y == enemy.y)
                {
                    
                }
            }
        }
    }
}
