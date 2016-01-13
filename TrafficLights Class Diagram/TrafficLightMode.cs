using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrafficLights
{
 
    public abstract class ControllerMode
    {
        public List<TrafficLightControllerState> States
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }
    }
}