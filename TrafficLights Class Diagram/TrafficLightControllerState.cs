using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrafficLightClassDiagram
{
    public class TrafficLightControllerState
    {
        public Dictionary<SignalsType, bool> RoadASignals { get; set; }
        public Dictionary<SignalsType, bool> RoadBSignals { get; set; }
        public Dictionary<SignalsType, bool> PedestrianTrafficLightSignals { get; set; }

        public int TimeWait { get; set; }
      

        public TrafficLightControllerState(Dictionary<SignalsType, bool> roadASignals, Dictionary<SignalsType, bool> roadBSignals, Dictionary<SignalsType, bool> pedestrianTrafficLightSignals, int timeWait)
        {
            this.RoadASignals = roadASignals;
            this.RoadBSignals = roadBSignals;
            this.PedestrianTrafficLightSignals = pedestrianTrafficLightSignals;
            TimeWait = timeWait;
        }
    }

    public enum SignalsType
    {
        Green,Red, Yellow, RedAndYellow, BlinkGreen, BlinkYellow       
    }

   
}