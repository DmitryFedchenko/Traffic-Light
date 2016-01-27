using System;
using System.Collections.Generic;
using System.Linq;

namespace TrafficLightClassDiagram
{
    public interface ITrafficLightController
    {
       
       void AddTrafficlight(TrafficLight trafficLight);
        List<TrafficLight> TrafficLights { get;}
        void SwithMode(string mode);


    }
}