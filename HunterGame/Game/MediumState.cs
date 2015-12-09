using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HunterGame
{
    public class MediumState:DifficultyState
    {
        //set the attributes for medium state
        public MediumState()
        {
            enemyScreenPts = 2;
            enemySpeed = 3F;
            maxEnemies = 3;
            enemyKillWorth = 10;
        }
    }
}
