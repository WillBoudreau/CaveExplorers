﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG_OOP_WillB
{
    internal class Entity
    {
        public HealthSys healthSys;
        public Entity() 
        {
            healthSys = new HealthSys();
        }
    }
}