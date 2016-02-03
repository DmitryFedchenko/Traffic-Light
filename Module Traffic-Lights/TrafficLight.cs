using System;
using System.Threading;

namespace Traffic_Light.Model
{
    public abstract class TrafficLight
    {
        protected  Timer BlinkSignalTimer;
        public event EventHandler StateChanged;
        public TrafficLightType TrafficLightType { get; set; }

        protected void OnStateChanged(object obj,EventArgs e) {
            if (StateChanged != null) 
            StateChanged(obj,e);
        }
        public void SetState(TrafficLightControllerState trafficLightState)
        {            
                if (BlinkSignalTimer != null)
                    BlinkSignalTimer.Dispose();

                switch (TrafficLightType)
                {
                    case TrafficLightType.RoadATrafficLight:
                        SetLampState(trafficLightState.RoadAState);
                        break;

                    case TrafficLightType.RoadBTrafficLight:
                        SetLampState(trafficLightState.RoadBState);
                        break;

                    case TrafficLightType.PedestrianTrafficLight:
                        SetLampState(trafficLightState.PedestrianTrafficLightState);
                        break;

                    default:
                        break;
                }
            }

        protected abstract void SetLampState(LampState signal);
        protected virtual void BlinkSignal(object signal) { }
       
 }


        public enum TrafficLightType {
          RoadATrafficLight, RoadBTrafficLight, PedestrianTrafficLight
        }
}