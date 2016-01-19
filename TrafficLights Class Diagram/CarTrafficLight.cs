using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TrafficLightClassDiagram;

namespace TrafficLights
{
    public class CarTrafficLight : TrafficLight
    {

        
        public CarTrafficLight(int id)
        {
           Id = id;
        }

        public bool GreenLamp { get; set; }
        public bool YellowLamp { get; set; }
        public bool RedLamp { get; set; }

        public override event EventHandler ChangeSignal;

        public override void ChangeSignalLamp(string signal)
        {
            if (BlinkSignalTimer != null)
                BlinkSignalTimer.Dispose();

            GreenLamp = false;
            YellowLamp = false;
            RedLamp = false;

            switch (signal)
            {
                case "Green":
                    GreenLamp = true;
                    break;
                case "Red":
                    GreenLamp = true;
                    break;
                case "Yellow":
                    GreenLamp = true;
                    break;
                case "RedAndYellow":
                    RedLamp = true;
                    YellowLamp = true;
                    break;
                case "BlinkGreen":
                    BlinkSignalTimer = new Timer(BlinkSignal, "BlinkGreen", 0, 500);                          
                    break;
                case "BlinkYellow":
                    BlinkSignalTimer = new Timer(BlinkSignal, "Yellow", 0, 500);
                    break;
            }
            Console.WriteLine(Id +" "+signal);
            if(ChangeSignal != null)
            ChangeSignal(this,EventArgs.Empty);

        }

        protected override void BlinkSignal(object obj)
        {
            if ("Yellow" == (string)obj)
                YellowLamp = GreenLamp ? false : true;

            if ("Green" == (string)obj)
                GreenLamp = GreenLamp ? false : true;
                        
            if(ChangeSignal != null)
            ChangeSignal(this, EventArgs.Empty);

            Console.WriteLine("Blink "+ Id +" " + GreenLamp);
        }

      
    }
}