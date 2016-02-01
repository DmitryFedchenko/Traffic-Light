using System;
using System.Collections.Generic;
using Traffic_Light.Model;

namespace Traffic_Light.Console
{
    public interface ICrossroadsView
    {
        TrafficLightView RoadATrafficLight { get; set; }
        TrafficLightView RoadBTrafficLight { get; set; }
        TrafficLightView PedestrianTrafficLight { get; set; }

        TrafficLightModeType UserSelectedState { get; set; }
       
        event EventHandler UserChangeMode;
    }
}