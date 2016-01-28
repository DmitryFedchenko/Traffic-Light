using System.Collections.Generic;


namespace Traffic_Light.Console
{
    public interface ITrafficLightView
    {
        int Id { get; set; }
        string TrafficLightType { get; set; }
        Dictionary<LampType,LampCordinate> LampCoordinates { get; set; }

    }
}