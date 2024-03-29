namespace TextBasedRPG_OOP_WillB
{
    internal abstract class Enemy
    {
        public Settings settings;
        public HealthSystem healthSys;
        public char enemyAvatar { get; }
        public string name { get; }
        public int x { get; set; }
        public int y { get; set; }

        public abstract void Move(Player player);

        public abstract void Attack(Player player);

        public abstract void DisplayEnemy();

        public void POS(int dx, int dy, Player player)
        {
            if (x == player.x && y == player.y)
            {
                player.healthSys.TakeDamage(settings.GruntAttack);
                this.x -= x;
                this.y -= y;
            }
        }
    }
}
