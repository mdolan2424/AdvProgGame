using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace HunterGame.Game.Items
{
    public class LifePotion : IItem
    {
        private int worth;
        public string name
        {
            get; set;
        }

        string IItem.image








        {
            get
            {
                return this.image;
            }
        }

        int IItem.worth
        {
            get
            {
                return this.worth;
            }
        }

        private string image;
        public Texture2D texture;
        public Vector2 position;

        

        public LifePotion()
        {
            this.worth = 1;
            this.name = "Standard Life Potion";
            position = new Vector2(300, 400);
            image = "Graphics\\red-potion";

        }

        public string getImage()
        {
            return this.image;
        }
        public int apply()
        {
            return worth;
        }

        
    }
}
