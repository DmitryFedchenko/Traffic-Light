using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using TrafficLightClassDiagram;

namespace TrafficLightClassDiagram
{
    public class PedestrianTrafficLight : TrafficLight
    {
        object obj = new object();
        public override event EventHandler ChangeSignal;
        public bool RedLamp { get; set; }
       public bool GreenLamp { get; set; }

        protected override void SetSignal(SignalsType signal)
        {

            RedLamp = false;
            GreenLamp = false;

            switch (signal)
            {
                case SignalsType.BlinkGreen:
                    BlinkSignalTimer = new Timer(BlinkSignal, SignalsType.Green, 0, 500);
                    break;

                case SignalsType.BlinkYellow:
                    BlinkSignal(SignalsType.Yellow);
                    break;

                case SignalsType.Red:
                    RedLamp = true;
                    break;

                case SignalsType.Green:
                    GreenLamp = true;
                    break;

            }


            if (ChangeSignal != null)
                ChangeSignal(this, EventArgs.Empty);
 
        }

        protected override void BlinkSignal(object obj)
        {

            if (SignalsType.Green == (SignalsType)obj)
                GreenLamp = GreenLamp ? false : true;


            if (ChangeSignal != null)
                ChangeSignal(this, EventArgs.Empty);
            Console.WriteLine("          Blink " + Id + "   " + (SignalsType)obj );

        }

        public PedestrianTrafficLight(int id, string trafficlightType)
        {
            this.TrafficLightType = trafficlightType;
            Id = id;           
        }

    }
}