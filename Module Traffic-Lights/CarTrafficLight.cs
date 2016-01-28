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
        object obj = new object();
        public override event EventHandler ChangeSignal;

        public SignalType RedLamp { get; set; }
        public SignalType YellowLamp { get; set; }
        public SignalType GreenLamp { get; set; }

        protected override void SetSignal(SignalType signal) {

            RedLamp = SignalType.Grey;
            YellowLamp= SignalType.Grey;
            GreenLamp = SignalType.Grey;

            switch (signal) {
                case SignalType.BlinkGreen:
                    BlinkSignalTimer = new Timer(BlinkSignal, SignalType.Green, 0, 500);
                    break;

                case SignalType.BlinkYellow:
                    BlinkSignalTimer = new Timer(BlinkSignal, SignalType.Yellow, 0, 500);
                    break;

                case SignalType.Yellow:
                    YellowLamp = SignalType.Yellow;
                    break;

                case SignalType.Green:
                    GreenLamp = SignalType.Yellow;
                    break;

                case SignalType.Red:
                    RedLamp = SignalType.Yellow;
                    break;

                case SignalType.RedAndYellow:
                    RedLamp = SignalType.Red;
                    YellowLamp = SignalType.Yellow;
                    break;
            }
            if (ChangeSignal != null)
                    ChangeSignal(this, EventArgs.Empty);
           
        }

        protected override void BlinkSignal(object signal)
        {
            if (SignalType.Yellow == (SignalType)signal)
             YellowLamp = YellowLamp == SignalType.Yellow ? SignalType.Grey: SignalType.Yellow;

            if (SignalType.Green == (SignalType)signal)
             GreenLamp = GreenLamp== SignalType.Green  ? SignalType.Grey: SignalType.Green;
            
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


