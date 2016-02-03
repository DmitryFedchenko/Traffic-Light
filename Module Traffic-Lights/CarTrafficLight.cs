using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Traffic_Light.Model;

namespace Traffic_Light.Model
{
    public class CarTrafficLight : TrafficLight
    {
        private Logger Log = LogManager.GetCurrentClassLogger();

        public bool RedLamp { get; set; }
        public bool YellowLamp { get; set; }
        public bool GreenLamp { get; set; }

        protected override void SetLampState(LampState signal) {
            Log.Trace("Traffic Light type:{0} Lamp state :{1}",this.TrafficLightType,signal);

            RedLamp = false;
            YellowLamp= false;
            GreenLamp = false;

            switch (signal) {
                case LampState.BlinkGreen:
                    BlinkSignalTimer = new Timer(BlinkSignal, LampState.Green, 0, 500);
                    return;

                case LampState.BlinkYellow:
                    BlinkSignalTimer = new Timer(BlinkSignal, LampState.Yellow, 0, 500);
                    return;

                case LampState.Yellow:
                    YellowLamp =true;
                    break;

                case LampState.Green:
                    GreenLamp = true;
                    break;

                case LampState.Red:
                    RedLamp = true;
                    break;

                case LampState.RedAndYellow:
                    RedLamp = true;
                    YellowLamp = true;
                    break;
            }
            OnStateChanged(this,EventArgs.Empty);
           
        }

        protected override void BlinkSignal(object signal)
        {
            if (LampState.Yellow == (LampState)signal)
            {
                YellowLamp = YellowLamp ? false : true;
                Log.Trace("Traffic light type: {0} ; Yellow lamp state: {1}; ", this.TrafficLightType,YellowLamp);
            }


            if (LampState.Green == (LampState)signal)
            {
                GreenLamp = GreenLamp ? false : true;
                Log.Trace("Traffic light type: {0} ; Green lamp state: {1}; ", this.TrafficLightType, GreenLamp);
            }
            OnStateChanged(this, EventArgs.Empty);
        }

        public CarTrafficLight(TrafficLightType trafficLightType)
        {
            this.TrafficLightType = trafficLightType;
        }

    }
      
}


