using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrafficLightClassDiagram;

namespace TrafficLights
{
    public class CarTrafficLight : TrafficLight
    {
        public string Name { get; set; }

        int Id { get; set; }
        public CarTrafficLight(int id)
        {
            Id = id;
        }


        public bool GreenLamp { get; set; }
        public bool YellowLamp { get; set; }
        public bool RedLamp { get; set; }

        public override void ChangeSignalLamp(string signal)
        {
            switch (signal)
            {
                case "Green":
                    GreenLamp = true;
                    break;
            }

        }
    }
}