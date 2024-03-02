using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace TextBasedRPG_OOP_WillB
{
    internal class MusicManager
    {
        public string musicPath;
        public SoundPlayer soundplayer;
        public MusicManager()
        {
            soundplayer = new SoundPlayer();
        }
        public void PlayMusicLevel( int level)
        {
            switch(level)
            {
                case 0:
                    musicPath = AppDomain.CurrentDomain.BaseDirectory + "kingdom-of-fantasy-version-60s-10817.wav";
                    if (File.Exists(musicPath))
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
                    break;
                case 1:
                    musicPath = AppDomain.CurrentDomain.BaseDirectory + "kingdom-of-fantasy-version-60s-10817.wav";
                    if (File.Exists(musicPath))
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
                    break;

            }
        }
    }
}
