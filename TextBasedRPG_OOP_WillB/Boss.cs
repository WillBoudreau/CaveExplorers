using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG_OOP_WillB
{
    internal class Boss : Enemy
    {
        private bool chase = false;
        private int chaseDist = 5;
        public int Damage { get; set; }
        public Boss(char enemAvatar, int x, int y, int damage, int shield, int hp)
        {
            healthSys = new HealthSystem(hp, shield);
            name = "Boss";
            this.y = y;
            this.x = x;
            Damage = damage;
            this.enemyAvatar = enemAvatar;
        }
        public override void Move(Player player,Map map)
        {
            int dist = Math.Abs(x - player.x) + Math.Abs(y - player.y);
            if (dist <= chaseDist)
            {
                if (player.x > x)
                {
                    x++;
                }
                else if (player.x < x)
                {
                    x--;
                }
                if (player.y > y)
                {
                    y++;
                }
                else if (player.y < y)
                {
                    y--;
                }
            }
            base.POS(x, y, player, map);
        }
        public override void Attack(Player player)
        {
            if (x == player.x && y == player.y)
            {
                player.healthSys.TakeDamage(Damage);
            }
        }
        public override void DisplayEnemy()
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
