using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HunterGame
{
    abstract class Observable
    {
        protected List<Observer> observerList;

        
        public abstract void notify();
        public void register(Observer obs)
        {
            observerList.Add(obs);
        }
        public void unregister(Observer obs)
        {
            observerList.Remove(obs);
        }
    }
}
