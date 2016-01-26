using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TrafficLightClassDiagram
{
    public abstract class TrafficLight
    {
        object obj = new object();
        protected  Timer BlinkSignalTimer;

        public abstract Dictionary<LampType, bool> Lamps { get; set; }

        public abstract event EventHandler ChangeSignal;

        public int Id { get; set; }
        public string TrafficLightType { get; set; }

        public void SetState(TrafficLightControllerState trafficLightState)
        {                      lock(obj) {


                if (BlinkSignalTimer != null)
                    BlinkSignalTimer.Dispose();

                switch (TrafficLightType)
                {
                    case "RoadATrafficLight":
                        SetSignal(trafficLightState.RoadASignals);
                        break;

                    case "RoadBTrafficLight":
                        SetSignal(trafficLightState.RoadBSignals);
                        break;

                    case "PedestrianTrafficLight":
                        SetSignal(trafficLightState.PedestrianTrafficLightSignals);
                        break;

                    default:
                        break;
                }

            }
               
            }

        protected abstract  void SetSignal(Dictionary<SignalsType, bool> signals);

        protected abstract void BlinkSignal(object obj);
       
      
    }
}