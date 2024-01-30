using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG_OOP_WillB
{
    internal class DamageSystem
    {
        PlayerVals player = new PlayerVals();
        EnemyVals enemy = new EnemyVals();
        HealthVals health = new HealthVals();
        public DamageSystem()
        {
        }
        public void Combat(int x,int y)
        {
            {
                if (player.Playerturn == true)
                {
                    //if (player.x == enemy.x && player.y == enemy.y)
                    //{
                    //    Console.WriteLine();
                    //}
                }

            }
        }
    }
}
