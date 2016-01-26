using System.Collections.Generic;


namespace Traffic_Light.Console
{
    public class TrafficLightView : ITrafficLightView
    {
        public int Id { get; set; }
        public string TrafficLightType { get; set; }
        public List<LampCordinate> LampCoordinates { get; set; }

        public int LampCount
        {
            get { return LampCoordinates.Count; }
        }


        public TrafficLightView(string participan ,int topX, int topY, int middleX, int middleY)
        {
            TrafficLightType = participan;

            LampCoordinates = new List<LampCordinate>();
            LampCoordinates.Add(new LampCordinate(topX, topY));
            LampCoordinates.Add(new LampCordinate(middleX, middleY));

        }


        public TrafficLightView(string participan ,int lampTopX, int lampTopY, int lampMiddleX, int lampMiddleY, int lampBottomX, int lampBottomY)
            : this(participan,lampTopX, lampTopY, lampMiddleX, lampMiddleY)
        {
            LampCoordinates.Add(new LampCordinate(lampBottomX, lampBottomY));
        }

        

    }


    
}