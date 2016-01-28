using System;
using System.Collections.Generic;

namespace Traffic_Light.Console
{
    public interface ICrossroadsView
    {
        TrafficLightView RoadATrafficLight { get; set; }
        TrafficLightView RoadBTrafficLight { get; set; }
        TrafficLightView PedestrianTrafficLight { get; set; }

        string UserSelectedState { get; set; }
       
        event EventHandler UserChangeMode;
    }
}