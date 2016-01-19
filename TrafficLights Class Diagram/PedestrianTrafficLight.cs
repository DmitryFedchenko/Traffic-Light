using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using TrafficLightClassDiagram;

namespace TrafficLights
{
    public class PedestrianTrafficLight : TrafficLight
    {

        public int RedLamp { get; set; }


        public int GreenLamp { get; set; }

        public PedestrianTrafficLight(int id)
        {
            Id = id;
        }

        public override void ChangeSignalLamp(string signal)
        {
            this.BlinkSignalTimer = new Timer();
        }
    }
}