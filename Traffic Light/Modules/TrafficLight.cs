using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traffic_Light.Modules
{
    public abstract class TrafficLight
     {

        public string LightKey { get; set; } = "*";

        public string DefualtLightKey { get; set; } = "0";

       
        public Dictionary<PositionTrLightEnum, int> posittionTrLight;
        

     }
}
