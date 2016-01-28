using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Traffic_Light.Model
{
    public class TrafficLightControllerState
    {
        public LampState RoadAState { get; set; }
        public LampState RoadBState { get; set; }
        public LampState  PedestrianTrafficLightState { get; set; }

        public int TimeWait { get; set; }
      
        public TrafficLightControllerState(LampState roadAState, LampState roadBState, LampState pedestrianTrafficLightState, int timeWait)
        {
            this.RoadAState = roadAState;
            this.RoadBState = roadBState;
            this.PedestrianTrafficLightState = pedestrianTrafficLightState;
            TimeWait = timeWait;
        }
    }
}