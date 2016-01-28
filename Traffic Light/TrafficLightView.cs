using System;
using System.Collections.Generic;


namespace Traffic_Light.Console
{
    public class TrafficLightView : ITrafficLightView
    {
        public int Id { get; set; }
        public string TrafficLightType { get; set; }
        public Dictionary<LampType, LampCordinate> LampCoordinates { get; set; }

        
        public void ChangeCollor(string redLamp, string yellowLamp, string greeenLamp)
        {

        }

        public TrafficLightView(string participan ,int topX, int topY, int middleX, int middleY)
        {
            TrafficLightType = participan;

            LampCoordinates = new Dictionary<LampType,LampCordinate>();
            LampCoordinates.Add(LampType.Red, new LampCordinate(topX, topY));
            LampCoordinates.Add(LampType.Green, new LampCordinate(middleX, middleY));

        }


        public TrafficLightView(string participan ,int lampTopX, int lampTopY, int lampMiddleX, int lampMiddleY, int lampBottomX, int lampBottomY)
            : this(participan,lampTopX, lampTopY, lampBottomX, lampBottomY)
        {
            LampCoordinates.Add(LampType.Yellow, new LampCordinate(lampMiddleX, lampMiddleY));
        }

        

    }

    public enum LampType
    {
        Green,Red,Yellow
    }


}