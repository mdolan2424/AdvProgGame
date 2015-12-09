using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HunterGame
{
    /// <summary>
    /// Parent difficulty state to store attributes that depend on the difficulty
    /// </summary>
    public abstract class DifficultyState
    {
        //create attributes necessary for all states
        protected float enemySpeed;
        protected int maxEnemies;
        protected int enemyScreenPts;
        protected int enemyKillWorth;
    
        //getters for all attributes
        public float EnemySpeed
        {
            get { return enemySpeed; }
        }
        public int MaxEnemies
        {
            get { return maxEnemies; }
        }
        public int EnemyScreenPts
        {
            get { return enemyScreenPts; }
        }
        public int EnemyKillWorth
        {
            get { return enemyKillWorth; }
        }
    }

}
