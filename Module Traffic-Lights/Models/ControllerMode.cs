using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrafficLitht;

namespace TrafficLitht
{

    public abstract class ControllerMode
    {
        public List<TrafficLightControllerState> ListStates { get; set; }
      
    }
}