using System;
using System.Threading;

namespace Traffic_Light.Model
{
    public abstract class TrafficLight
    {
        protected  Timer BlinkSignalTimer;
        public abstract event EventHandler ChangeState;
        public TrafficLightType TrafficLightType { get; set; }

        public void SetState(TrafficLightControllerState trafficLightState)
        {            
                if (BlinkSignalTimer != null)
                    BlinkSignalTimer.Dispose();

                switch (TrafficLightType)
                {
                    case TrafficLightType.RoadATrafficLight:
                        SetSignal(trafficLightState.RoadAState);
                        break;

                    case TrafficLightType.RoadBTrafficLight:
                        SetSignal(trafficLightState.RoadBState);
                        break;

                    case TrafficLightType.PedestrianTrafficLight:
                        SetSignal(trafficLightState.PedestrianTrafficLightState);
                        break;

                    default:
                        break;
                }
            }

        protected abstract void SetSignal(LampState signal);

        protected abstract void BlinkSignal(object signal);
        }


        public enum TrafficLightType {
          RoadATrafficLight, RoadBTrafficLight, PedestrianTrafficLight
        }
}