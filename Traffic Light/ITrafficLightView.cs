using System.Collections.Generic;
using Traffic_Light.Model;

namespace Traffic_Light.Console
{
    public interface ITrafficLightView
    {
        TrafficLightType TrafficLightType { get; set; }
        void ChangeSignal(bool redLamp, bool greeenLamp);
        void ChangeSignal(bool redLamp, bool yellowLamp, bool greeenLamp);

    }
}