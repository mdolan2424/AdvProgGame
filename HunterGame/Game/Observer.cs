using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HunterGame
{
    public abstract class Observer
    {
        /// <summary>
        /// abstract class for observer
        /// </summary>
        protected Observable subject;
        public abstract void update();
    }
}
