using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        //current item displayed on screen
        Texture2D texture;
        public Vector2 position;
        
        private int nextX;
        private int nextY;

        const int maxPosX = 1080;
        const int maxPosY = 600;

        public ItemManager()
        {
            itemList = new List<IItem>();
            
            nextX = 1;
            nextY = 1;
            //default spawn point
            position = new Vector2(300, 400);
            factory = new ItemFactory();
        }
        
        //get a random item
        public void createRandomItem()
        {
            
            //static for now.
            spawnedItem = factory.getItem(1);

            itemList.Add(spawnedItem);
        }

        public int useItem()
        {
            
            int worth = spawnedItem.worth;
            itemList.Remove(spawnedItem);
            //destroy item
            return worth;
        }

      
        
        public string reportItemType()
        {
            return spawnedItem.name;
        }


        public void changePosition(int x, int y)
        {
            Random rand = new Random();
            
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
