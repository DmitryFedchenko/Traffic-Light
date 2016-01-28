using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Traffic_Light.Model
{
    public class TrafficLightControllerState
    {
        public SignalType RoadASignal { get; set; }
        public SignalType RoadBSignal { get; set; }
        public SignalType  PedestrianTrafficLightSignal { get; set; }

        public int TimeWait { get; set; }
      
        public TrafficLightControllerState(SignalType roadASignal, SignalType roadBSignal, SignalType pedestrianTrafficLightSignal, int timeWait)
        {
            this.RoadASignal = roadASignal;
            this.RoadBSignal = roadBSignal;
            this.PedestrianTrafficLightSignal = pedestrianTrafficLightSignal;
            TimeWait = timeWait;
        }
    }
}