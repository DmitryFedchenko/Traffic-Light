using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrafficLights
{
    public interface ITrafficLightControl
    {
        event EventHandler ChangeControllerState;
        List<TrafficLights.TrafficLight> TrafficLights { get; set; }

        void SwithMode();
    }
}