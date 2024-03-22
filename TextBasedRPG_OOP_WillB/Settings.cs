﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG_OOP_WillB
{
    internal class Settings
    {
        //Player Variables
        public int PlayerMaxhp = 3;
        public int PlayerMinhp = 0;
        public int PlayerMaxShield = 3;
        public int PlayerMinShield = 0;
        public int PlayerAttack = 3;

        //Grunt Variables
        public  int GruntMaxhp = 1;
        public  int GruntMinhp = 0;
        public  int GruntAttack = 1;

        //Runner Variables
        public int RunnerMaxhp = 3;
        public int RunnerMinhp = 0;
        public int RunnerAttack = 3;

        //Chaser Variables
        public int ChaserMaxhp = 2;
        public int ChaserMinhp = 0;
        public int ChaserAttack = 2;

        //Boss Variables
        public int BossMaxhp = 4;
        public int BossMinhp = 0;
        public int BossMaxShield = 2;
        public int BossMinShield = 0;
        public int BossAttack = 3;
        public Settings() 
        {

        }

    }
}
