using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Media;
using System.IO;
using System.Data;

namespace TextBasedRPG_OOP_WillB
{

    internal class GameManager
    {
        private Stopwatch stopwatch = new Stopwatch();
        public SoundPlayer soundplayer;
        Map map;
        Player player;
        Enemy enemy;
        bool BossDead = false;
        List<Enemy> enemies;
        HUD hud;
        Generation generation;
        List<ItemManager> itemManager;
        MusicManager soundManager;
        //Achievements achievements;
        public GameManager()
        {
            map = new Map();
            player = new Player();
            soundplayer = new SoundPlayer();
            enemies = Enemy.GenerateEnenmies(5,2,2,1,map);
            hud = new HUD(player, enemies);
            Player.hud = hud;
            settings = new Settings();
            //achievements = new Achievements(player, enemies, itemManager);
        }
        public void PlayMusic(string musicPath)
        {
            if(File.Exists(musicPath))
            {
                soundplayer.SoundLocation = musicPath;
                soundplayer.Load();
                soundplayer.PlayLooping();
            }
            else
            {
                Console.Clear();
                Console.WriteLine(musicPath + "not found");
            }
        }
        void StarTimer()
        {
            stopwatch.Start();
        }
        void GenerateLlevel(int level)
        {
            if(level ==  1)
            {
                string musicPath = AppDomain.CurrentDomain.BaseDirectory + "kingdom-of-fantasy-version-60s-10817.wav";
                PlayMusic(musicPath);
                Console.CursorVisible = false;
                map.MapArray();
                map.ShowMap();
            }
        }
        public void StopTimer()
        {
            stopwatch.Stop();
            TimeSpan timeSpan = stopwatch.Elapsed;
            string EndTime = String.Format("{0:00}:{1:00}:{2:00}",timeSpan.TotalHours,timeSpan.TotalMinutes,timeSpan.TotalSeconds);
            Console.WriteLine("Level Completed in: " + EndTime );  
        }
        void Start()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Cave Explorers!");
            Console.WriteLine("---------------------------");
            Console.WriteLine("You goal adventurer is to defeat the Boss at the end of the level");
            Console.WriteLine("Make sure you collect pickups to boost your stats along the way");
            Console.WriteLine("---------------------------");
            Console.WriteLine("On you adventure you will find many enemies and they will attack you");
            Console.WriteLine("You can attack them by moving into them, but they can do the same and some may even try to escape!");
            Console.WriteLine("---------------------------");
            Console.WriteLine("Press any key to begin");
            Console.ReadKey(true);
            Console.Clear();
        }
        public void GameLoop()
        {
            StarTimer();
            Start();
            GenerateLlevel(1);
            while (player.healthSys.normalHealth > 0)
            {
                //generation.Update();
                player.Update(enemies,items,chaser,runner,grunt);
                hud.Update(enemies);
                enemyMan.Update(player, enemies, items);
            }
            void Draw()
            {
                enemyMan.Draw(player,enemies,items);
                //generation.Draw();
                player.Draw();
            }
            //Intro to game
            void Intro()
            {
                Console.Clear();
                Console.WriteLine("Welcome to Cave Explorers!");
                Console.WriteLine("---------------------------");
                Console.WriteLine("You goal adventurer is to defeat the Boss at the end of the level");
                Console.WriteLine("Make sure you collect pickups to boost your stats along the way");
                Console.WriteLine("---------------------------");
                Console.WriteLine("On you adventure you will find many enemies and they will attack you");
                Console.WriteLine("You can attack them by moving into them, but they can do the same and some may even try to escape!");
                Console.WriteLine("---------------------------");
                Console.WriteLine("Press any key to begin");
                Console.ReadKey(true);
                Console.Clear();
            }
            public void GameLoop()
            {
                GameInitialize();
                while (player.healthSys.normalHealth > 0)
                {
                    enemy.DisplayEnemy();
                    enemy.EnemyMove(player,enemies);
                    if(enemy.enemType == EnemType.Boss && enemy.healthSys.IsAlive == false)
                    {
                        BossDead = true;
                        Win();
                        break;
                    }
                }
            }
            //Game Over to game
            public void GameOver()
            {
                Console.Clear();
                Console.WriteLine("Game Over");
                Console.WriteLine("You where defeated by: ");
                Console.ReadKey();
            }
        }
        public void GameOver()
        {
            Console.Clear();
            Console.WriteLine("Game Over");
            Console.WriteLine("You where defeated by: ");
            Console.ReadKey();
        }
        public void Win()
        {
            Console.Clear();
            StopTimer();
            Console.WriteLine("You have defeated the boss! You win!");
            Console.WriteLine("Press any key to quit");
            Console.ReadKey();
        }
    }
}
