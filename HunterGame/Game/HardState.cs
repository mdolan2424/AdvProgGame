using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HunterGame
{
    public class HardState:DifficultyState
    {
        public HardState()
        {   
            //set attributes for hard state
            enemyScreenPts = 1;
            enemySpeed =4;
            maxEnemies = 8;
            enemyKillWorth = 15;
        }
    }
}
