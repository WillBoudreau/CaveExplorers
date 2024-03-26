using System;
using System.Collections.Generic;

namespace TextBasedRPG_OOP_WillB
{
    internal class Grunt : EnemyManager
    {
        Random rnd;
        List<EnemyManager> enemy;
        Player player;
        MusicManager sound;
        public Grunt(int x, int y, EnemType enemType, int damage, int shield, int hp, Player player, List<ItemManager> items) : base(x, y, enemType, damage, shield, hp, player, items)
        {
            rnd = new Random();
            sound = new MusicManager();
            enemType = EnemType.Grunt;
            damage = settings.GruntAttack;
            hp = settings.GruntMaxhp;
            enemyAvatar = 'G';
            name = "Grunt";
            Move(player, enemy, items);
        }
        public override void Move(Player player, List<EnemyManager> enemies, List<ItemManager> items)
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
            base.POS(dx, dy, player, enemies, items);
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
        public override void DisplayEnemy(Player player)
        {
            if (healthSys.IsAlive)
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