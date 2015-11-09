using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HunterGame
{
    public class SpawnerProto
    {
        //Define our sub classes
        EasyEnemy EnemyObject = new EasyEnemy();

        //Important piece of our 'Prototype Header' class. This portion of the code is important. It calls the clone copy from
        //the 'Enemy' interface. Basically this is what calls the cloneable action of our prototype.
        public Enemy getEnemy(Enemy ClonedSource)
        {

            return ClonedSource.CloneCopy();

        }

        //This is our class for returning our cloned enemy. May be changed in the future
        //To return a hashmap or dictionairy of a group of cloned classes.
        public EasyEnemy getClonedEnemy()
        {
            EasyEnemy EnemyClone = (EasyEnemy)getEnemy(EnemyObject);


            return EnemyClone;
        }

        //For testing purposes, We return the Original 'EnemyObject' that we used for cloning
        public EasyEnemy getOriginal()
        {
            return EnemyObject;
        }
    }
    
}
