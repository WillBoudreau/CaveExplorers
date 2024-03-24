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
        public override void Move(Player player, List<EnemyManager> enemies,List<ItemManager>items)
        {
            int distanceToplayer = Math.Abs(player.x - x) + Math.Abs(player.y - y);

            if (distanceToplayer <= 5)
            {
                Move(player, enemies, items);

            }
        }
        public override void Attack(Player player, List<EnemyManager> enemies)
        {
            if (x == player.x && y == player.y)
            {
                player.healthSys.TakeDamage(settings.BossAttack);
                this.x -= x;
                this.y -= y;
            }
        }
        public override void DisplayEnemy(Player player)
        {
            if (healthSys.IsAlive)
            {
                Console.SetCursorPosition(this.x, this.y);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(enemyAvatar);
            }
        }
    }
}
