using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG_OOP_WillB
{
    internal class ExpirenceManager
    {
        public int level;
        public int xp;
        int levelMaxXp;
        int MaxLevel;
        public ExpirenceManager()
        {
            level = 0;
            levelMaxXp = 100;
            xp = 0;
            MaxLevel = 10;
        }
        public void XpUp()
        {
            xp += 25;
            if(xp >= levelMaxXp)
            {
                LevelUp();
                levelMaxXp += 25;
            }
        }
        public void LevelUp()
        {
            level += 1;
            if(level >= MaxLevel)
            {
                level = MaxLevel;
            }
        }
    }
}
