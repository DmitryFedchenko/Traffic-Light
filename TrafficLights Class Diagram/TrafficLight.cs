using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TrafficLightClassDiagram
{
    public abstract class TrafficLight
    {
        
        protected Timer BlinkSignalTimer;
            
        public event EventHandler ChangeSignal;

        public int Id { get; set; }

        public abstract void ChangeSignalLamp(string signal);
        

        protected void BlinkSignal(string signal)
        {
            throw new System.NotImplementedException();
        }

      
    }
}