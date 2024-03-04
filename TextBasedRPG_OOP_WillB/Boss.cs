using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG_OOP_WillB
{
    internal class Boss:Enemy
    {
        public Boss(int x, int y,EnemType enemType, int damage, int shield, int hp):base(x, y, enemType, damage, shield, hp) 
        {
            enemType = EnemType.Boss;
        }
        public override void Move(Player player, List<Enemy> enemies)
        {
            int distanceToplayer = Math.Abs(player.x - x) + Math.Abs(player.y - y);

            if (distanceToplayer <= 5)
            {
                Move(player, enemies);

            }
        }
    }
}
