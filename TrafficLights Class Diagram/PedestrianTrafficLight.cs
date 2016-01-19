using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TrafficLightClassDiagram;

namespace TrafficLights
{
    public class PedestrianTrafficLight : TrafficLight
    {

        public PedestrianTrafficLight(int id)
        {
            Id = id;
        }
        
        public bool GreenLamp { get; set; }
         public bool RedLamp { get; set; }

        public override event EventHandler ChangeSignal;

        public override void ChangeSignalLamp(string signal)
        {
            if (BlinkSignalTimer != null)
                BlinkSignalTimer.Dispose();

            GreenLamp = false;
            RedLamp = false;

            switch (signal)
            {
                case "Green":
                    GreenLamp = true;

                    break;
                case "Red":
                    RedLamp = true;
                    break;
            
                case "BlinkGreen":
                    BlinkSignalTimer = new Timer(BlinkSignal,"Green", 0, 500);
                    break;
                                   

            }
            Console.WriteLine("             Pedestrian " + signal);

            if (ChangeSignal != null)
            ChangeSignal(this, EventArgs.Empty);

        }

        protected override void BlinkSignal(object obj)
        {
            if ("Green" == (string)obj)
                GreenLamp = GreenLamp ? false : true;


            if (ChangeSignal != null)
                ChangeSignal(this, EventArgs.Empty);

            Console.WriteLine("             Blink pedestrian " + GreenLamp);
        }
    }
}