using System;
using System.Collections.Generic;

namespace TextBasedRPG_OOP_WillB
{
    internal class Grunt : Enemy
    {
        Random rnd;
        Player player;
        public Grunt(int x, int y, int damage, int shield, int hp, Player player)
        {
            rnd = new Random();
            healthSys = new HealthSystem(hp, shield);
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

                    dx = -1;
                    break;
                case 3:

                    dy = 1;
                    break;
                case 4:

                    dx = 1;
                    break;
            }
        }
        public override void Attack(Player player)
        {
            if (x == player.x && y == player.y)
            {
                player.healthSys.TakeDamage(settings.GruntAttack);
                this.x -= x;
                this.y -= y;
            }
        }
        public override void DisplayEnemy()
        {
            if (healthSys.IsAlive)
            {
                Console.SetCursorPosition(x, y);
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write('G');
                Console.ResetColor();
            }
            else
            {
                this.x = 0;
                this.y = 0;
            }
            return;
        }

    }
}