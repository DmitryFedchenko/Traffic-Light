using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TrafficLightClassDiagram;

namespace TrafficLightClassDiagram
{
    public class CarTrafficLight : TrafficLight
    {
        object obj = new object();
        public override event EventHandler ChangeSignal;

        public bool RedLamp { get; set; }
        public bool YellowLamp { get; set; }
        public bool GreenLamp { get; set; }

        protected override void SetSignal(SignalsType signal) {

            RedLamp = false;
            YellowLamp= false;
            GreenLamp = false;

            switch (signal) {
                case SignalsType.BlinkGreen:
                    BlinkSignalTimer = new Timer(BlinkSignal, SignalsType.Green, 0, 500);
                    break;

                case SignalsType.BlinkYellow:
                    BlinkSignalTimer = new Timer(BlinkSignal, SignalsType.Yellow, 0, 500);
                    break;

                case SignalsType.Yellow:
                    YellowLamp = true;
                    break;

                case SignalsType.Green:
                    GreenLamp = true;
                    break;

                case SignalsType.Red:
                    RedLamp = true;
                    break;

                case SignalsType.RedAndYellow:
                    RedLamp = true;
                    YellowLamp = true;
                    break;
            }
              
            
            if (ChangeSignal != null)
                    ChangeSignal(this, EventArgs.Empty);
           
        }

        protected override void BlinkSignal(object obj)
        {
            if (SignalsType.Yellow == (SignalsType)obj)
             YellowLamp = YellowLamp ? false : true;

            if (SignalsType.Green == (SignalsType)obj)
             GreenLamp = GreenLamp? false : true;
            
            if (ChangeSignal != null)
                ChangeSignal(this, EventArgs.Empty);
           

        }

        public CarTrafficLight(int id, string trafficlightType)
        {
            this.TrafficLightType = trafficlightType;
            Id = id;
        }

    }
      
}


