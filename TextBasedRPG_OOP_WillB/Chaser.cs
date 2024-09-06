using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG_OOP_WillB
{
    internal class Chaser : Enemy
    {
        public int Damage { get; set; } 
        public Chaser(char enemAvatar, int x, int y, int damage, int shield, int hp)
        {
            healthSys = new HealthSystem(hp, shield);
            enemyAvatar = 'C';
            enemyAvatar = enemAvatar;
            this.x = x;
            this.y = y;
            name = "Chaser";
            Damage = damage;

        }
        //Chaser moves towards player
        public override void Move(Player player,Map map)
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
            if (map.IsTileValid(dx, dy) == '.')
            {
                x += dx;
                y += dy;
            }
            else if(isAttacked == true)
            {
                dx = 0;
                dy = 0;
            }
            base.POS(dx, dy, player,map);
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
                if(this.x < 0 || this.y < 0)
                {
                    this.x = 0;
                    this.y = 0;
                }
                Console.SetCursorPosition(this.x, this.y);
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write(enemyAvatar);
                Console.ResetColor();
            }
            else
            {
                this.x = 0;
                this.y = 0;
            }
        }
    }
}
