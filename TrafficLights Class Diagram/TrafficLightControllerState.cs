using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrafficLightClassDiagram
{
    public class TrafficLightControllerState
    {
        public SignalsType RoadASignals { get; set; }
        public SignalsType RoadBSignals { get; set; }
        public SignalsType  PedestrianTrafficLightSignals { get; set; }

        public int TimeWait { get; set; }
      
        public TrafficLightControllerState(SignalsType roadASignals, SignalsType roadBSignals, SignalsType pedestrianTrafficLightSignals, int timeWait)
        {
            this.RoadASignals = roadASignals;
            this.RoadBSignals = roadBSignals;
            this.PedestrianTrafficLightSignals = pedestrianTrafficLightSignals;
            TimeWait = timeWait;
        }
    }
    public enum SignalsType
    {
        Green,Red, Yellow, RedAndYellow, BlinkGreen, BlinkYellow, Grey       
    }

   
}