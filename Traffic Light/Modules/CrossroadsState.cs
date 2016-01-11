using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traffic_Light.Modules
{
  public  class CrossroadsState
    {
        public SignalTypes SignalTrafficLightRoadA { get; set; }
        public SignalTypes  SignalTrafficLightRoadB { get; set; }
        public SignalTypes SignalPedestrianTrafficLight { get; set; }
        
        public int Time { get; set; }
        public int Period { get; set; }

      public CrossroadsState(SignalTypes signalTrafficLightRoadA, SignalTypes signalTrafficLightRoadB, SignalTypes signalPedestrianTrafficLight, int time)
        {

            SignalTrafficLightRoadA = signalTrafficLightRoadA;
            SignalTrafficLightRoadB = signalTrafficLightRoadB;
            SignalPedestrianTrafficLight = signalPedestrianTrafficLight;
            Time = time;
            
        }

      public CrossroadsState(SignalTypes signalTrafficLightRoadA, SignalTypes signalTrafficLightRoadB, SignalTypes signalPedestrianTrafficLight, int time, int period)
      {

            SignalTrafficLightRoadA = signalTrafficLightRoadA;
            SignalTrafficLightRoadB = signalTrafficLightRoadB;
            SignalPedestrianTrafficLight = signalPedestrianTrafficLight;
            Time = time;
         
            Period = period;

      }
    }
}
