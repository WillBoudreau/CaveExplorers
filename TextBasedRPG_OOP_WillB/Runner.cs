using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG_OOP_WillB
{
    internal class Runner:EnemyManager
    {
        Settings settings;
        public Runner( int x, int y, EnemType enemType, int damage, int shield, int hp): base(x, y, enemType, damage, shield, hp)
        {
            enemType = EnemType.Runner;
            damage = settings.RunnerAttack;
            hp = settings.RunnerMaxhp;
        }

        public override void Move(Player player, List<EnemyManager> enemies)
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
