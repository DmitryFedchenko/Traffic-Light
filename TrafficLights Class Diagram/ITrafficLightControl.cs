﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrafficLitht;

namespace TrafficLightClassDiagram
{
    public interface ITrafficLightControl
    {
        List<CarTrafficLight> CarTrafficlights { get; }
        List<PedestrianTrafficLight> PedestrianTrafficlights { get; }
        string ModeSelectUser { get; set; }
      
    }
}