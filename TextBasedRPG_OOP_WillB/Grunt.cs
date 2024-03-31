using System;
using System.Collections.Generic;

namespace TextBasedRPG_OOP_WillB
{
    internal class Grunt : Enemy
    {
        Random rnd;
        Player player;
        Map map;
        public Grunt(char enemAvatar,int x, int y, int damage, int shield, int hp, Player player)
        {
            healthSys = new HealthSystem(hp, shield);
            map = new Map();
            rnd = new Random();
            enemyAvatar = 'G';
            enemyAvatar = enemAvatar;
            healthSys = new HealthSystem(hp, shield);
            this.x = x;
            this.y = y;
        }
        public override void Move(Player player)
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

                    dx = 1;
                    break;
                case 3:

                    dy = 1;
                    break;
                case 4:

                    dx = -1;
                    break;
            }
            if(isAttacked == true)
            {
                dy = 0;
                dx = 0;
            }
            base.POS(dx, dy, player);
        }
        public override void Attack(Player player)
        {
            if (this.x == player.x && this.y == player.y)
            {
                player.healthSys.TakeDamage(settings.GruntAttack);
                this.x -= x;
                this.y -= y;
            }
        }
        public override void DisplayEnemy()
        {
                Console.SetCursorPosition(this.x, this.y);
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write(enemyAvatar);
                Console.ResetColor();
        }

    }
}