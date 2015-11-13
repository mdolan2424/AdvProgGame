using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HunterGame
{
    public abstract class DifficultyState
    {
        protected int enemySpeed;
        protected int maxEnemies;
        protected int enemyScreenTime;
    
        public int EnemySpeed
        {
            get { return enemySpeed; }
        }
        public int MaxEnemies
        {
            get { return maxEnemies; }
        }
        public int EnemyScreenTime
        {
            get { return enemyScreenTime; }
        }
    }

}
