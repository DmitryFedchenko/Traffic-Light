using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrafficLitht;

namespace TrafficLitht
{
    public class NightMode : ControllerMode
    {
        public NightMode()
        {
            this.ListStates.Add(new TrafficLightControllerState("Gray", "Gray", "BlinkYellow", 1000));
          
        }
    }
}