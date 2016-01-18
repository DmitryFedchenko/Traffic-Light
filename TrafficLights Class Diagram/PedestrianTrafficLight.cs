using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrafficLights
{
    public class PedestrianTrafficLight : TrafficLightClassDiagram.TrafficLight
    {
    
        public int RedLamp
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public int GreenLamp
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }
        public PedestrianTrafficLight(int id)
        {
            Id = id;
        }

        public override void ChangeSignalLamp(string signal)
        {
            throw new NotImplementedException();
        }
    }
}