using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HunterGame
{
    public class EasyState:DifficultyState
    {
        public EasyState()
        {
            //set attributes for easy state
            enemyScreenPts = 3;
            enemySpeed = 1;
            maxEnemies = 3;
            enemyKillWorth = 5;
        }
    }
}
