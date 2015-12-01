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

            else if(item == 2)
            {
                return new PowerUp();
            }

            else if(item == 3)
            {
                return new Weapon();
            }
            else if (item == 4)
            {
                return new BadPowerUp();
            }
            
            return null;
        }

    }
}
