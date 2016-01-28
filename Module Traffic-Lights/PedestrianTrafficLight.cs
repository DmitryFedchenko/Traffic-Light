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
        
        public override event EventHandler ChangeSignal;
        public SignalType RedLamp { get; set; }
        public SignalType GreenLamp { get; set; }

        protected override void SetSignal(SignalType signal)
        {
            RedLamp = SignalType.Grey;
            GreenLamp = SignalType.Grey;

            switch (signal)
            {
                case SignalType.BlinkGreen:
                    BlinkSignalTimer = new Timer(BlinkSignal, SignalType.Green, 0, 500);
                    break;

                case SignalType.Red:
                    RedLamp = SignalType.Red;
                    break;

                case SignalType.Green:
                    GreenLamp = SignalType.Red;
                    break;
            }

            if (ChangeSignal != null)
                ChangeSignal(this, EventArgs.Empty);
 
        }

        protected override void BlinkSignal(object signal)
        {
            if (SignalType.Green == (SignalType)signal)
                GreenLamp = GreenLamp == SignalType.Green ? SignalType.Green: SignalType.Grey;

            if (ChangeSignal != null)
                ChangeSignal(this, EventArgs.Empty);
        }

        public PedestrianTrafficLight(int id, string trafficLightType)
        {
            this.TrafficLightType = trafficLightType;
            Id = id;           
        }

    }
}