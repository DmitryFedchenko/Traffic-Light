using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrafficLitht;

namespace TrafficLitht
{
    public interface ITrafficLightController
    {
        List<CarTrafficLight> CarTrafficlights { get; }
        List<PedestrianTrafficLight> PedestrianTrafficlights { get; }
        string ModeSelectUser { get; set; }
        void AddTrafficlight(int id, string typeTrafficLight);


    }
}