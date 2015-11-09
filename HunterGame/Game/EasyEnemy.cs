using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HunterGame
{
    //Easy Enemy sub class inherits from our 'Enemy' prototype interface
    public class EasyEnemy : Enemy
    {
        //Here we throw the cloneable exception
        public object Clone()
        {
            throw new NotImplementedException();
        }

        //The main
        public EasyEnemy()
        {
            Console.Write("This is the Easy Enemy Class....\n");
        }

        //Impportant piece. This is the bit of code that calls the super (aka 'base' in C#)
        //Of the ICloneable to return the cloned object.
        public Enemy CloneCopy()
        {
            EasyEnemy EnemyObject = null;

            try
            {
                EnemyObject = (EasyEnemy) base.MemberwiseClone();
            }
            catch 
            {

                Console.Write("We have a problem");
            }

            Console.Write("Just went through clone copy");

            return EnemyObject;


        }
    }
}
