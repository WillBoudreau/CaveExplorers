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
        List<EnemyManager> enemies;
        public Runner( int x, int y, EnemType enemType, int damage, int shield, int hp,Player player, List<ItemManager> items): base(x, y, enemType, damage, shield, hp, player, items)
        {
            enemType = EnemType.Runner;
            damage = settings.RunnerAttack;
            hp = settings.RunnerMaxhp;
            enemyAvatar = 'R';
            Move(player, enemies);
        }

        public override void Move(Player player, List<EnemyManager> enemies)
        {
            int dx = player.x - x;
            int dy = player.y - y;
            if (Math.Abs(dx) < Math.Abs(dy))
            {
                dx = Math.Sign(dx);
                dy = 0;
            }
            else
            {
                dx = 0;
                dy = Math.Sign(dy);
            }
            base.POS(dx, dy, player, enemies);
        }
        public override void Attack(Player player, List<EnemyManager> enemies)
        {
            if (this.x == player.x && this.y == player.y)
            {
                player.healthSys.TakeDamage(settings.RunnerAttack);
                this.x -= x;
                this.y -= y;
            }
        }
        public override void DisplayEnemy(Player player)
        {
            if (healthSys.IsAlive)
            {
                Console.SetCursorPosition(this.x, this.y);
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(enemyAvatar);
                Console.ResetColor();
            }
            else
            {
                player.killCount++;
                this.x = 0;
                this.y = 0;
            }
        }
    }
}
