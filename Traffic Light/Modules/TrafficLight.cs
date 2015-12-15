using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traffic_Light.Modules
{
    public abstract class TrafficLight
    {
       

        public SignalTypes currentSignal;

        public Dictionary<PositionTypes, int> posittionTrLight;
        public abstract void SwitchSignal(SignalTypes signal);


    }
}
