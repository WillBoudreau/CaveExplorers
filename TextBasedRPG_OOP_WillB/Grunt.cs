using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG_OOP_WillB
{
    internal class Grunt:EnemyManager
    {
        Random rnd;
        Settings settings;
        List<EnemyManager> enemy;
        Player player;
        public Grunt( int x, int y, EnemType enemType, int damage, int shield, int hp):base(x, y, enemType,damage,shield, hp)
        {
            rnd = new Random();
            //enemType = EnemType.Grunt;
            //damage = settings.GruntAttack;
            //hp = settings.GruntMaxhp;
            enemyAvatar = 'G';
            Move(player, enemy);
        }
        public override void Move(Player player, List<EnemyManager> enemies)
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
        public override void Attack(Player player, List<EnemyManager> enemies)
        {
            if (this.x == player.x && this.y == player.y)
            {
                player.healthSys.TakeDamage(settings.GruntAttack);
                this.x -= x;
                this.y -= y;
            }
        }
    }
}