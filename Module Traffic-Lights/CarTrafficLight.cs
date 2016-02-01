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
        Logger log = LogManager.GetCurrentClassLogger();
        

        public bool RedLamp { get; set; }
        public bool YellowLamp { get; set; }
        public bool GreenLamp { get; set; }

        protected override void SetSignal(LampState signal) {
            log.Trace(signal + "   " + this.TrafficLightType);

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
                log.Trace((LampState)signal + "   " + YellowLamp + " " + this.TrafficLightType);
            }


            if (LampState.Green == (LampState)signal)
            {
                GreenLamp = GreenLamp ? false : true;
                log.Trace((LampState)signal + "   " + GreenLamp + " " + this.TrafficLightType);
            }
            OnStateChanged(this, EventArgs.Empty);
        }

        public CarTrafficLight(TrafficLightType trafficLightType)
        {
            this.TrafficLightType = trafficLightType;
        }

    }
      
}


