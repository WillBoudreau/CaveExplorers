using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG_OOP_WillB
{
    internal class Chaser:EnemyManager
    {
        public int StartX = 5;
        public int StartY = 5;
        Settings settings;
        public Chaser(int x, int y, EnemType enemType, int damage, int shield, int hp): base(x, y, enemType, damage, shield, hp)
        {
            this.x = x;
            this.y = y;
            damage = settings.ChaserAttack;
            hp = settings.ChaserMaxhp;
            enemType = EnemType.Chaser;
        }
        public override void Move(Player player, List<EnemyManager> enemies)
        {
            int dx = player.x - x;
            int dy = player.y - y;
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
