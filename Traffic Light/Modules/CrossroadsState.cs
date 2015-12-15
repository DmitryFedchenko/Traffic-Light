using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traffic_Light.Modules
{
  public  class CrossroadsState
    {
        public SignalTypes TrafficLigthRoadA { get; set; }
        public SignalTypes  TrafficLightRoadB { get; set; }
        public SignalTypes PedestrianTrafficLight { get; set; }

        public int Time { get; set; }

        public CrossroadsState(SignalTypes trafficLightRoadA, SignalTypes trafficLightRoadB, SignalTypes pedestrianTrafficLight, int time)
        {
            TrafficLigthRoadA = trafficLightRoadA;
            TrafficLightRoadB = trafficLightRoadB;
            PedestrianTrafficLight = pedestrianTrafficLight;
            Time = time;
        }
    }
}
