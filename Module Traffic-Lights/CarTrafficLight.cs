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
        public override event EventHandler ChangeSignal;

        public bool RedLamp { get; set; }
        public bool YellowLamp { get; set; }
        public bool GreenLamp { get; set; }

        protected override void SetSignal(SignalType signal) {

            RedLamp = false;
            YellowLamp= false;
            GreenLamp = false;

            switch (signal) {
                case SignalType.BlinkGreen:
                    BlinkSignalTimer = new Timer(BlinkSignal, SignalType.Green, 0, 500);
                    break;

                case SignalType.BlinkYellow:
                    BlinkSignalTimer = new Timer(BlinkSignal, SignalType.Yellow, 0, 500);
                    break;

                case SignalType.Yellow:
                    YellowLamp =true;
                    break;

                case SignalType.Green:
                    GreenLamp = true;
                    break;

                case SignalType.Red:
                    RedLamp = true;
                    break;

                case SignalType.RedAndYellow:
                    RedLamp = true;
                    YellowLamp = true;
                    break;
            }
            if (ChangeSignal != null)
                    ChangeSignal(this, EventArgs.Empty);
           
        }

        protected override void BlinkSignal(object signal)
        {
            if (SignalType.Yellow == (SignalType)signal)
             YellowLamp = YellowLamp ?false: true;

            if (SignalType.Green == (SignalType)signal)
             GreenLamp = GreenLamp ? false: true;
            
            if (ChangeSignal != null)
                ChangeSignal(this, EventArgs.Empty);
        }

        public CarTrafficLight(int id, string trafficLightType)
        {
            this.TrafficLightType = trafficLightType;
            Id = id;
        }

    }
      
}


