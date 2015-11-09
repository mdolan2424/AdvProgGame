using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HunterGame
{
    //This is our 'Enemy' interface which is the meat of our prototype pattern.
    //It extends the 'ICloneable' interface which allows us to clone in C#.
    //This is where our different enemies will inherit from. We do this so
    //They will all have access to the 'CloneCopy()' Method. This method is
    //important in order to clone our sub classes.
    public interface Enemy : ICloneable
    {

        Enemy CloneCopy();

    }
}
