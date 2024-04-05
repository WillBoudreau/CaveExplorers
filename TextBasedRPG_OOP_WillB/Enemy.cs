using System;

namespace TextBasedRPG_OOP_WillB
{
    internal abstract class Enemy:Entity
    {
        public bool isAttacked = false;
        public char enemyAvatar { get; set; }
        public string name { get; set; }
        public int x { get; set; }
        public int y { get; set; }

        public abstract void Move(Player player,Map map);

        public abstract void Attack(Player player);

        public abstract void DisplayEnemy();

        public void POS(int dx, int dy, Player player,Map map)
        {
            this.x += dx;
            this.y += dy;
            switch(map.IsTileValid(this.x,this.y))
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
                case'>':
                    this.x -= dx;
                    this.y -= dy;
                    break;
                case'<':
                    this.x -= dx;
                    this.y -= dy;
                    break;
            }
                if (this.x == player.x && this.y == player.y)
                {
                    Attack(player);
                    this.x -= dx;
                    this.y -= dy;
                }
        }
    }
}
