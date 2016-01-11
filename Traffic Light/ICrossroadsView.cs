using System;
using System.Collections.Generic;

namespace Traffic_Light.Console
{
    public interface ICrossroadsView
    {
        List<ITrafficLightView> ViewTraffiLIghts { get; set; }
        void LightSignal(int TraffiLightId, int lampId, string colorSiganl, bool light);
        string UserSelectedState { get; set; }
        void InitTrafficLight();
        event EventHandler AddTraffilight;
        event EventHandler ChangedState;
    }
}