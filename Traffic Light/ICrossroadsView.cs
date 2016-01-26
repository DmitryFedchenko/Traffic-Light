using System;
using System.Collections.Generic;

namespace Traffic_Light.Console
{
    public interface ICrossroadsView
    {
        List<ITrafficLightView> ViewTraffiLIghts { get; set; }
        void RepresentSignal(int TraffiLightId, int lampId, bool light);
      
        string UserSelectedState { get; set; }
        void InitTrafficLight();
        event EventHandler AddTraffilight;
        event EventHandler UserChangeMode;
    }
}