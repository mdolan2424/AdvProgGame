using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;


namespace HunterGame.Game.Items
{

    //this class managers items generated from the item factory.
    //it is responsible for drawing and/or calling the item draw method
    //it is responsible for recognizing when the item was shot and reporting when the game can generate the item to the player.
    class ItemManager
    {
        List<IItem> itemList;
        
        IItem spawnedItem;
        ItemFactory factory;
        
        private Vector2 position;
        private int nextX;
        private int nextY;

        const int maxPosX = 1080;
        const int maxPosY = 600;

        Random rand;
        public ItemManager()
        {
            itemList = new List<IItem>();
            rand = new Random();
            nextX = 1;
            nextY = 1;
            //default spawn point
            position = new Vector2(-1000,-1000);
            factory = new ItemFactory();
        }
       
        //get a random item
        public void createRandomItem()
        {
            
            //static for now.
            spawnedItem = factory.getItem(rand.Next(1,4));
            position = new Vector2(rand.Next(11, 1049), rand.Next(11, 579));
            itemList.Add(spawnedItem);
        }

        public void destroyItem()
        {
            //set defaults
            spawnedItem = null;

        }
        public IItem getItem()
        {
            //use item based on full or empty attributes
            return spawnedItem;
        }

      
        
        public string reportItemType()
        {
            return spawnedItem.name;
        }


        public void changePosition()
        {
            
            
            if (position.X > 1050 || position.X < 10)
            {
                nextX = nextX * -1;
            }

            if (position.Y > 580 || position.Y < 10)
            {
                nextY = nextY * -1;
            }
            
            position.X += nextX;
            position.Y += nextY;
            
            //check if out of bounds.
        }

        public Vector2 getPosition()
        {
            return position;
        }
        
        public string getImage()
        {
            return spawnedItem.image;
        }

        
    }
}
