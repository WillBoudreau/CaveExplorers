using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG_OOP_WillB
{
    internal class DamageSystem
    {
        Player player = new Player();
        PlayerVals playerVals = new PlayerVals();
        HealthSys healthSys = new HealthSys();
        Enemy enemy = new Enemy();
        public DamageSystem()
        {
            this.player = new Player();
            this.playerVals = new PlayerVals();
            this.healthSys = new HealthSys();
            this.enemy = new Enemy();
        }
        public void Combat(int x, int y)
        {
            if(playerVals.Playerturn == true)
            {
                if ( player.x == enemy.x && player.y == enemy.y)
                {
                    healthSys.TakeDamage(healthSys.Attack);
                }//<-- During the players trun Enemy 1 takes damage
                if (player.x == enemy.x && player.y == enemy.y)
                {
                    player.x -= x;
                    player.y -= y;
                }//<-- Player cannot move on top of Enemy 1
            }
        }
    }
}
