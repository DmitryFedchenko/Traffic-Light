using Traffic_Lights.Model.Constants;

namespace Traffic_Lights.Model.Models
{
  public  class CrossroadsStateModel
    {
         
        public SignalTypes SignalTrafficLightRoadA { get; set; }
        public SignalTypes SignalTrafficLightRoadB { get; set; }
        public SignalTypes SignalPedestrianTrafficLight { get; set; }
        public int Time { get; set; } = 0;
        public int Period { get; set; } = 0;


      public CrossroadsStateModel(SignalTypes signalTrafficLightRoadA, SignalTypes signalTrafficLightRoadB, SignalTypes signalPedestrianTrafficLight, int time)
        {

            SignalTrafficLightRoadA = signalTrafficLightRoadA;
            SignalTrafficLightRoadB = signalTrafficLightRoadB;
            SignalPedestrianTrafficLight = signalPedestrianTrafficLight;
            Time = time;
            
        }

      public CrossroadsStateModel(SignalTypes signalTrafficLightRoadA, SignalTypes signalTrafficLightRoadB, SignalTypes signalPedestrianTrafficLight, int time, int period) 
            :this(signalTrafficLightRoadA, signalTrafficLightRoadB, signalPedestrianTrafficLight, time)
      {
            Period = period;
      }
    }
}
