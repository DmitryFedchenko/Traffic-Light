using System;
using System.Collections.Generic;
using System.Linq;

namespace TrafficLightClassDiagram
{
    public interface ITrafficLightControl
    {

        List<TrafficLight> TrafficLights { get;}
        string ModeSelectUser { get; set; }
      
    }
}