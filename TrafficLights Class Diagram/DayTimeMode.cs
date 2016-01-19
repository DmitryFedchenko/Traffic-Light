using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrafficLights;

namespace TrafficLightClassDiagram
{
    public class DayTimeMode : ControllerMode
    {
        public DayTimeMode()
        {
            this.States = new List<TrafficLightControllerState>();
            this.States.Add(new TrafficLightControllerState("Green","Red","Red",3000));
            this.States.Add(new TrafficLightControllerState("BlinkGreen", "Red", "Red", 2000));
            this.States.Add(new TrafficLightControllerState("Yellow", "RedAndellow", "Red", 1000));
            this.States.Add(new TrafficLightControllerState("Red", "Green", "Red", 3000));
            this.States.Add(new TrafficLightControllerState("Red", "BlinkGreen", "Red", 2000));
            this.States.Add(new TrafficLightControllerState("Red", "Yellow", "Red", 1000));
            this.States.Add(new TrafficLightControllerState("Red", "Red", "Green", 3000));
            this.States.Add(new TrafficLightControllerState("Red", "Red", "BlinkGreen", 2000));
            this.States.Add(new TrafficLightControllerState("RedAndYellow", "Red", "Red", 1000));

        }
        
    }
}