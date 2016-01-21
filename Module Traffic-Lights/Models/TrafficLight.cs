using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TrafficLitht
{
    public abstract class TrafficLight
    {
        
        protected  Timer BlinkSignalTimer;
                    
        public abstract event EventHandler ChangeSignal;

        public int Id { get; set; }

        public abstract void ChangeSignalLamp(string signal);

        protected abstract void BlinkSignal(object obj);
       
      
    }
}