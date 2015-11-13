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
            enemyScreenTime = 5;
            enemySpeed = 5;
            maxEnemies = 8;
        }
    }
}
