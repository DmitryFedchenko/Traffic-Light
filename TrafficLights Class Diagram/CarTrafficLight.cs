using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public override void ChangeSignalLamp(string signal)
        {
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
                    BlinkSignal();
                    break;
            }

        }
    }
}