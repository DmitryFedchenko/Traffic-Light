using System;
using System.Collections.Generic;
using System.Linq;

namespace Traffic_Light.Model
{
    public interface ITrafficLightController
    {
       
       void AddTrafficlight(TrafficLight trafficLight);
       void SwithMode(TrafficLightModeType mode);
       void StartWork();


    }
}