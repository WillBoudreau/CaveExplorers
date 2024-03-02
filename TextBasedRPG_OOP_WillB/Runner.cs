using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG_OOP_WillB
{
    internal class Runner:Enemy
    {
        public Runner( int x, int y, EnemType enemType): base(x, y, enemType)
        {
            enemType = EnemType.Runner;
        }

        public override void Move(Player player, List<Enemy> enemies)
        {
            int dx = player.x + x;
            int dy = player.y + y;
            if (Math.Abs(dx) > Math.Abs(dy))
            {
                dx = Math.Sign(dx);
                dy = 0;
            }
            else
            {
                dx = 0;
                dy = Math.Sign(dy);
            }
            POS(dx, dy, player, enemies);
        }
    }
}
