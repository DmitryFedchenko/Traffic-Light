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
        Logger log = LogManager.GetCurrentClassLogger();

        public override event EventHandler ChangeState;
     
        public bool RedLamp { get; set; }
        public bool GreenLamp { get; set; }

        protected override void SetSignal(LampState signal) {

            log.Trace(signal.ToString());

            RedLamp = false;
            GreenLamp = false;

            switch (signal) {
                case LampState.BlinkGreen:
                    BlinkSignalTimer = new Timer(BlinkSignal, LampState.Green, 0, 500);
                    break;

                case LampState.BlinkYellow:
                    BlinkSignalTimer = new Timer(BlinkSignal, LampState.Yellow, 0, 500);
                    break;
                case LampState.Green:
                    GreenLamp = true;
                    break;

                case LampState.Red:
                    RedLamp = true;
                    break;
            }
            if (ChangeState != null)
                    ChangeState(this, EventArgs.Empty);
           
        }

        protected override void BlinkSignal(object signal)
        {
            log.Trace(GreenLamp.ToString());
            if (LampState.Green == (LampState)signal)
             GreenLamp = GreenLamp ? false: true;
            
            if (ChangeState != null)
                ChangeState(this, EventArgs.Empty);
        }
        public PedestrianTrafficLight(int id, string trafficLightType)
        {
            this.TrafficLightType = trafficLightType;
            Id = id;           
        }

    }
}