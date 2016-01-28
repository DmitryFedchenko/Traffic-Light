using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Traffic_Light.Model
{
    public abstract class TrafficLight
    {
      
        protected  Timer BlinkSignalTimer;
        public abstract event EventHandler ChangeSignal;
        public int Id { get; set; }
        public string TrafficLightType { get; set; }

        public void SetState(TrafficLightControllerState trafficLightState)
        {            
                if (BlinkSignalTimer != null)
                    BlinkSignalTimer.Dispose();

                switch (TrafficLightType)
                {
                    case "RoadATrafficLight":
                        SetSignal(trafficLightState.RoadASignal);
                        break;

                    case "RoadBTrafficLight":
                        SetSignal(trafficLightState.RoadBSignal);
                        break;

                    case "PedestrianTrafficLight":
                        SetSignal(trafficLightState.PedestrianTrafficLightSignal);
                        break;

                    default:
                        break;
                }
            }

        protected abstract void SetSignal(SignalType signal);

        protected abstract void BlinkSignal(object signal);
       
      
    }
}