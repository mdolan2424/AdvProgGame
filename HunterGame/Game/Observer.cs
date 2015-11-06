using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HunterGame
{
    abstract class Observer
    {
        protected Observable subject;
        public abstract void update();
    }
}
