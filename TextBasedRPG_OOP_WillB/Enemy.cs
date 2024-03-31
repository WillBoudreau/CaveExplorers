using System;

namespace TextBasedRPG_OOP_WillB
{
    internal abstract class Enemy:Entity
    {
        public Settings settings;
        Map map = new Map();
        HealthSystem healthSys;
        public bool isAttacked = false;
        public char enemyAvatar { get; set; }
        public string name { get; }
        public int x { get; set; }
        public int y { get; set; }

        public abstract void Move(Player player);

        public abstract void Attack(Player player);

        public abstract void DisplayEnemy();

        public void POS(int dx, int dy, Player player)
        {
            this.x += dx;
            this.y += dy;
            Console.WriteLine("EnemyX: " + x + "EnemyY: " + y);
            if(this.x == player.x && this.y == player.y)
            {
                this.x -= dx;
                this.y -= dy;
                Attack(player);
            }
            switch(map.IsTileValid(x,y))
            {
                case '.':
                    break;
                case'#':
                    this.x -= dx;
                    this.y -= dy;
                    break;
                case '+':
                    this.x -= dx;
                    this.y -= dy;
                    break;
            }
        }
    }
}
