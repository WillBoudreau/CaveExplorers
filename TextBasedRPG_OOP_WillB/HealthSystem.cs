using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG_OOP_WillB
{
    struct HealthVals
    {
    }
    internal class HealthSys
    {
        HealthVals healthVals = new HealthVals();
        PlayerVals playerVals = new PlayerVals();
        Player player = new Player();
        Enemy enemy = new Enemy();
        public int enemyhp;
        public int playerhp;
        public int health;
        public int playerATK = 1;
        public int enemyATK;
        public int Attack;
        public HealthSys()
        {

        }
        public void SetHealth()
        {
            enemyhp = health;
            playerhp = health;
        }
        public int GetHealth(int health)
        {
            this.health = health;
            SetHealth();
            return health;
        }
        public int GetAttack(int attack)
        {
            this.Attack = attack;
            return attack;

        }
        public void Heal(int hp)
        {
            health += hp;
        }
        public void PlayerTakeDamage(int damage)
        {
            playerhp -= damage;
            if (playerhp <= 0)
            {
                playerhp = 0;
            }
        }
        public void EnemyTakeDamage(int damage)
        {
            enemyhp -= damage;
        }
        public void Combat(int x, int y)
        {
            if (playerVals.Playerturn == true)
            {
                if (player.x == enemy.x && player.y == enemy.y)
                {

                    enemy.healthSys.health -= player.healthSys.playerATK;
                    if (enemy.healthSys.enemyhp <= 0)
                    {
                        Console.Clear();
                        Console.ReadKey();
                    }

                }

            }


        }

    }
}
