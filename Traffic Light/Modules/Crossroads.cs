using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Traffic_Light.Modules;

namespace Traffic_Light
{
    public abstract class Crossroads
    {
        public List<TrafficLight> allAutoTrLights;
        public List<TrafficLight> allPedTrLights;

        public abstract void SwithSignal(List<TrafficLight> trLights, SignalColorEnum colorEnumSignalColorEnumColorEnum,
            int timePause, bool resetSignal);
        
        public abstract void BlinkSignal(List<TrafficLight> trLights, SignalColorEnum colorEnumSignal, int quantity,
            int period);

    }
}