using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HunterGame
{
    public class SpawnerProto
    {
        //declare our incoming variables
        private int WindowX;
        private int WindowY;
        EnemySubclass Original;

        //constructor
        public SpawnerProto(int WindowX, int WindowY)
        {
            this.WindowX = WindowX;
            this.WindowY = WindowY;
            Original = new EnemySubclass(WindowX,WindowY);
        }

        

        //Important piece of our 'Prototype Header' class. This portion of the code is important. It calls the clone copy from
        //the 'Enemy' interface. Basically this is what calls the cloneable action of our prototype.
        public Enemy getEnemy(Enemy ClonedSource)
        {

            return ClonedSource.CloneCopy();

        }

        public EnemySubclass spawnEnemy(DifficultyState state)
        {
            //create our clone
            EnemySubclass EnemyClone = (EnemySubclass)getEnemy(Original);
            //Set the attribs each time we add to the initial area
            EnemyClone.setDifficultyAttribs(state.EnemySpeed, state.EnemyKillWorth, state.EnemyScreenPts);

            return EnemyClone;
        }

        //This is our class for returning our cloned enemy. May be changed in the future
        //To return a hashmap or dictionairy of a group of cloned classes.
        public Dictionary<int, EnemySubclass> getClonedEnemy(int count, DifficultyState state)
        {
            //Declare our class for cloning
            Original = new EnemySubclass(WindowX, WindowY);

            //declare our return dictionairy
            Dictionary<int, EnemySubclass> returnDict = new Dictionary<int, EnemySubclass>();

            //return a filled hash map
            //of the specified class (filled with 5 clones to start)
            for(int i = 0; i < count; i++)
            {   

                //Set the attribs each time we add to the initial area
                Original.setDifficultyAttribs(state.EnemySpeed,state.EnemyKillWorth,state.EnemyScreenPts);
                //create our clone
                EnemySubclass EnemyClone = (EnemySubclass)getEnemy(Original);             
                
                

                //add to dictionairy
                returnDict.Add(i, EnemyClone);
            }

            //return dictionairy full of 5 seperate enemies


            return returnDict;
        }

        //For testing purposes, We return the Original 'EnemyObject' that we used for cloning
        public EnemySubclass getOriginal()
        {
            return Original;
        }
    }
    
}
