using System.Collections.Generic;
using Traffic_Lights.Model.Constants;

namespace Traffic_Light.Console
{
    public interface ITrafficLightView
    {
        int Id { get; set; }
        string Participan { get; set; }
        List<LampCordinate> LampCoordinates { get; set; }
        int LampCount { get; }
        

    }
}