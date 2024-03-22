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
        List<EnemyManager> enemies;
        public Chaser(int x, int y, EnemType enemType, int damage, int shield, int hp, Player player,List<ItemManager>items): base(x, y, enemType, damage, shield,hp,player,items)
        {
            enemType = EnemType.Chaser;
            damage = settings.ChaserAttack;
            hp = settings.ChaserMaxhp;
           enemyAvatar = 'C';
           Move(player, enemies);
        }
        public override void Move(Player player, List<EnemyManager> enemies)
        {
            IsAttacked = false;
            int dx = player.x - x;
            int dy = player.y - y;
            if(IsAttacked == true)
            {
                dx = 0;
                dy = 0;
            }
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
            base.POS(dx, dy, player, enemies);
        }
        public override void Attack(Player player, List<EnemyManager> enemies)
        {
            if (x == player.x && y == player.y)
            {
                player.healthSys.TakeDamage(settings.ChaserAttack);
                this.x -= x;
                this.y -= y;
            }
        }
        public override void DisplayEnemy()
        {
            if(healthSys.IsAlive)
            {
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
