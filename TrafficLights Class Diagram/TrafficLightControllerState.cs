using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrafficLights
{
    public class TrafficLightControllerState
    {

        public string TrafficLightRoadA { get; set; }
       

        public string TrafficLightRoadB { get; set; }
        

        public string PedestrianTrafficlight { get; set; }
        
        public int TimeWait { get; set; }
        public TrafficLightControllerState(string trafficLightRoadA, string trafficLightRoadB, string pedestrinaTrafficLight, int timeWait)
        {
            TrafficLightRoadA = trafficLightRoadA;
            TrafficLightRoadB = trafficLightRoadB;
            this.PedestrianTrafficlight = pedestrinaTrafficLight;

            TimeWait = timeWait;
        }
        
    }

   
}