using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrafficLights;

namespace TrafficLightClassDiagram
{
    public class NightMode : ControllerMode
    {
        public NightMode()
        {
            this.States.Add(new TrafficLightControllerState("Gray", "Gray", "BlinkYellow", 1000));
          
        }
    }
}