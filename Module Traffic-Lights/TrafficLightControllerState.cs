using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Traffic_Light.Model
{
    public class TrafficLightControllerState
    {
        public LampState RoadASignal { get; set; }
        public LampState RoadBSignal { get; set; }
        public LampState  PedestrianTrafficLightSignal { get; set; }

        public int TimeWait { get; set; }
      
        public TrafficLightControllerState(LampState roadASignal, LampState roadBSignal, LampState pedestrianTrafficLightSignal, int timeWait)
        {
            this.RoadASignal = roadASignal;
            this.RoadBSignal = roadBSignal;
            this.PedestrianTrafficLightSignal = pedestrianTrafficLightSignal;
            TimeWait = timeWait;
        }
    }
}