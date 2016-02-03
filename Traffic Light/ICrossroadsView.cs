using System;
using System.Collections.Generic;
using Traffic_Light.Model;

namespace Traffic_Light.Console
{
    public interface ICrossroadsView
    {
        List<ITrafficLightView> ViewTrafficLights { get; }
        TrafficLightModeType UserSelectedState { get; set; }
        event EventHandler UserChangeMode;
    }
}