using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrafficLightClassDiagram
{
    public interface ITrafficLightControl
    {
        int TrafficLightDB { get; set; }
        int Mode { get; set; }
    }
}