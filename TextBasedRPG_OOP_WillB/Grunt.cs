using System;
using System.Collections.Generic;

namespace TextBasedRPG_OOP_WillB
{
    internal class Grunt : Enemy
    {
        Random rnd;
        public Grunt(char enemAvatar,int x, int y, int damage, int shield, int hp)
        {
            healthSys = new HealthSystem(hp, shield);
            rnd = new Random();
            this.x = x;
            this.y = y;
            name = "Grunt";
            this.enemyAvatar = enemAvatar;
        }
        public override void Move(Player player,Map map)
        {
            int Move = rnd.Next(1, 5);
            int dx = 0,
                dy = 0;
            switch (Move)
            {
                case 1:
                    dx = 0;
                    dy = 1;
                    break;
                case 2:
                    dy = 0;
                    dx = -1;
                    break;
                case 3:
                    dx = 0;
                    dy = -1;
                    break;
                case 4:
                    dy = 0;
                    dx = 1;
                    break;
                case 5:
                    dx = 0;
                    dy = 0;
                    break;
            }
            if(isAttacked == true)
            {
                dy = 0;
                dx = 0;
            }
            base.POS(dx, dy, player,map);
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
            if(healthSys.IsAlive)
            {
                Console.SetCursorPosition(this.x, this.y);
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
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