using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HunterGame
{
    public class MediumState:DifficultyState
    {
        public MediumState()
        {
            enemyScreenTime = 10;
            enemySpeed = 2;
            maxEnemies = 3;
        }
    }
}
