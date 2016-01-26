using System;
using System.Collections.Generic;
using System.Linq;

namespace TrafficLightClassDiagram
{
    public interface ITrafficLightController
    {
        void AddTrafficlight(int id, string typeTrafficLight);
        List<TrafficLight> TrafficLights { get;}
        void SwithMode(string mode);


    }
}