using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace TrafficLightClassDiagram
{
    public abstract class TrafficLight
    {
        private int BlinkSignalTimer;
            
        public event EventHandler ChangeSignal;

        public int Id { get; set; }

        public void ChangeSignalLamp()
        {
            throw new System.NotImplementedException();
        }

        private void BlinkSignal()
        {
            throw new System.NotImplementedException();
        }

      
    }
}