using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TrafficLightClassDiagram
{
    public abstract class TrafficLight
    {
        protected  Timer BlinkSignalTimer;

        public Dictionary<Lamp, bool> Lamps { get; set; }

        public abstract event EventHandler ChangeSignal;

        public int Id { get; set; }
        public string TrafficLightType { get; set; }

        public abstract void SetSignal(Dictionary<SignalsType, bool> signals);

        protected abstract void BlinkSignal(object obj);
       
      
    }
}