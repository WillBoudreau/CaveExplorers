using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG_OOP_WillB
{
    internal class Boss:EnemyManager
    {
        public Boss(int x, int y,EnemType enemType, int damage, int shield, int hp,Player player, List<ItemManager>items):base(x, y, enemType, damage, shield, hp,player,items) 
        {
            enemType = EnemType.Boss;
            name = "Boss";
        }
        public override void Move(Player player, List<EnemyManager> enemies)
        {
            int distanceToplayer = Math.Abs(player.x - x) + Math.Abs(player.y - y);

            if (distanceToplayer <= 5)
            {
                Move(player, enemies);

            }
        }
    }
}
