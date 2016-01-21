using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrafficLightClassDiagram;

namespace TrafficLitht
{
    public class StopMode : ControllerMode
    {
        public StopMode()
        {
            this.ListStates.Add(new TrafficLightControllerState("Gray", "Gray", "Gray",2000));
        }
    }
}