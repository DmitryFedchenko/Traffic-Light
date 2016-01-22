using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TrafficLightClassDiagram
{
    public abstract class TrafficLight
    {
        public IEnumerable<bool> SignalStates;

        protected  Timer BlinkSignalTimer;
                    
        public abstract event EventHandler ChangeSignal;

        public int Id { get; set; }
        public string TrafficLightType { get; set; }

        public abstract void SetState(IEnumerator<SignalsType> signals);

        protected abstract void BlinkSignal(object obj);
       
      
    }
}