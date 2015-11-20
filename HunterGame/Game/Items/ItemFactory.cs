using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace HunterGame.Game.Items
{
    public class ItemFactory
    {
        
        public ItemFactory()
        {

        }

        public IItem getItem(int item)
        {
           
            if (item == 1)
            {
                return new LifePotion();
            }
            
            return null;
        }

    }
}
