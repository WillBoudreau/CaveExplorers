using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG_OOP_WillB
{
    internal class Game
    {
        Displaymap map = new Displaymap();
        Player player = new Player();
        Enemy enemy = new Enemy();
        PlayerVals playerVals = new PlayerVals();
        EnemyVals enemyVals = new EnemyVals();
        public Game() 
        {
            GameStart();
        }
        public void GameStart()
        {
            Console.WriteLine("Welcome to my Text Based RPG\nPress any key to begin");
            Console.ReadKey();

            while (player.healthSys.playerhp > 0)
            {
                map.MapArray();
                ShowHUD();
                Console.WriteLine(player.x + " " + player.y);
                Console.WriteLine(enemy.x + " " + enemy.y);
                player.DisplayPlayer();
                enemy.DisplayEnemy();
                player.PlayerPOSMove();
                enemy.EnemyPOSMove();
            }
            Console.Clear();
            Console.WriteLine("Game Over...Press any key to quit");
            Console.ReadKey();
        }
        public void StartUp()
        {
            player.healthSys.GetHealth(5);
            enemy.healthSys.GetHealth(5);
            player.healthSys.GetAttack(1);
            enemy.healthSys.GetAttack(1);
        }
        public void ShowHUD()
        {
            Console.WriteLine("\nPlayer Health: " + player.healthSys.playerhp + "| Player Attack: " + player.healthSys.Attack);
            Console.WriteLine("Enemy Health: " + enemy.healthSys.enemyhp + "| Enemy Attack: " + enemy.healthSys.Attack);
        }
        public void Combat(int x, int y)
        {
            if (playerVals.Playerturn)
            {
                if (Math.Abs(player.x - enemy.x) <= 1 && Math.Abs(player.y - enemy.y) <= 1)
                {
                    enemy.healthSys.TakeDamage(1);
                    if (enemy.healthSys.enemyhp <= 0)
                    {
                        enemy.x = 0;
                        enemy.y = 0;
                    }
                }
            }
            if (enemyVals.Enemyturn)
            {
                if (Math.Abs(enemy.x - player.x) <= 1 && Math.Abs(y - enemy.y) <= 1)
                {
                    enemy.healthSys.TakeDamage(1);
                    if (enemy.healthSys.enemyhp <= 0)
                    {
                        enemy.x = 0;
                        enemy.y = 0;

                    }
                }
            }
        }
    }
}
