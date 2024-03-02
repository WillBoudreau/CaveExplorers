using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG_OOP_WillB
{
    internal class Grunt:Enemy
    {
        Random rnd;
        public Grunt( int x, int y, EnemType enemType):base(x, y, enemType)
        {
            enemType = EnemType.Grunt;
        }
        public override void Move(Player player, List<Enemy> enemies)
        {
            int Move = rnd.Next(1, 5);
            int dx = 0,
                dy = 0;
            switch (Move)
            {
                case 1:

                    dy = -1;
                    break;
                case 2:

                    dx = -1;
                    break;
                case 3:

                    dy = 1;
                    break;
                case 4:

                    dx = 1;
                    break;
            }
            POS(dx, dy, player, enemies);
        }
    }
}
