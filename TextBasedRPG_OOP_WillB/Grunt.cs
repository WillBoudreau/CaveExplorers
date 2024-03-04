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
        Settings settings;
        public Grunt( int x, int y, EnemType enemType, int damage, int shield, int hp):base(x, y, enemType,damage,shield, hp)
        {
            enemType = EnemType.Grunt;
            damage = settings.GruntAttack;
            hp = settings.GruntMaxhp;
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
