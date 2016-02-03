using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using Traffic_Light.Model;

namespace Traffic_Light.Model
{
    public class PedestrianTrafficLight : TrafficLight
    {
        Logger Log = LogManager.GetCurrentClassLogger();
     
        public bool RedLamp { get; set; }
        public bool GreenLamp { get; set; }

        protected override void SetLampState(LampState signal) {

            Log.Trace("Traffic Light type:{0} Lamp state :{1}", this.TrafficLightType, signal);

            RedLamp = false;
            GreenLamp = false;

            switch (signal) {
                case LampState.BlinkGreen:
                    BlinkSignalTimer = new Timer(BlinkSignal, LampState.Green, 0, 500);
                    return;
               
                case LampState.Green:
                    GreenLamp = true;
                    break;

                case LampState.Red:
                    RedLamp = true;
                    break;
            }
            OnStateChanged(this, EventArgs.Empty);

        }

        protected override void BlinkSignal(object signal)
        {
            if (LampState.Green == (LampState)signal)
                GreenLamp = GreenLamp ? false: true;

            Log.Trace("Traffic light type: {0} ; Green lamp state: {1}; ", this.TrafficLightType, GreenLamp);
            OnStateChanged(this, EventArgs.Empty);
        }
        public PedestrianTrafficLight(TrafficLightType trafficLightType)
        {
            this.TrafficLightType = trafficLightType;
        }

    }
}