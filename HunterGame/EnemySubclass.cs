using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HunterGame
{
    //Easy Enemy sub class inherits from our 'Enemy' prototype interface
    public class EnemySubclass : Enemy
    {
        //Basic attributes. speed, icon
        int speed;
        String icon;
        //Difficulty
        String Difficulty;
        //Starting position
        int StartX;
        int StartY;
        //window size
        int WindowX;
        int WindowY;
        //Destination
        float[] destination = new float[2];
        



        //Here we throw the cloneable exception
        public object Clone()
        {
            throw new NotImplementedException();
        }

        //The main
        public EnemySubclass(int WindowX, int WindowY, String Difficulty)
        {
            //Set our difficulty and window size
            this.Difficulty = Difficulty;
            this.WindowX = WindowX;
            this.WindowY = WindowY;

            Console.Write("This is the Easy Enemy Class....\n");
        }
        //Basic getters
        public int[] getStartPos()
        {
            int[] returnA = new int[2];
            returnA[0] = this.StartX;
            returnA[1] = this.StartY;

            return returnA;
        }

        public float[] getDestination()
        {
            return destination;
        }
        

        //Method for reset of the destination
        public float[] resetDestination()
        {
            Random Ran = new Random();
            float RanDestX = Ran.Next(this.WindowX);
            float RanDestY = Ran.Next(this.WindowY);
            //Store start and end in array for return
            float[] returnArray = new float[2];
            returnArray[0] = RanDestX;
            returnArray[1] = RanDestY;
            //set our local destination variable
            this.destination = returnArray;

            return returnArray;

        }

        //Method for setting all the appropriate settings based on difficulty setting
        public void setDifficultyAttribs()
        {
            //Generate random starting position for the enemy
            Random Ran = new Random();
            this.StartX = Ran.Next(this.WindowX); //We do this to make sure it starts off screen.
            this.StartY = Ran.Next(this.WindowY);

            //set destination
            this.destination[0] = Ran.Next(this.WindowX);
            this.destination[1] = Ran.Next(this.WindowY);


            if (Difficulty.Equals("Easy"))
            {
                speed = 100;
            }
            else if (Difficulty.Equals("Medium"))
            {
                speed = 150;
            }
            else
            {
                speed = 200;
            }


        }

        //Impportant piece. This is the bit of code that calls the super (aka 'base' in C#)
        //Of the ICloneable to return the cloned object.
        public Enemy CloneCopy()
        {
            EnemySubclass EnemyObject = null;

            try
            {
                EnemyObject = (EnemySubclass)base.MemberwiseClone();
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
