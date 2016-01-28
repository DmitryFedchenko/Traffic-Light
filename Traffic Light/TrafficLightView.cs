using System;
using System.Collections.Generic;


namespace Traffic_Light.Console
{
    public class TrafficLightView : ITrafficLightView
    {
        public int Id { get; set; }
        public string TrafficLightType { get; set; }
        public Dictionary<LampType, LampCordinate> LampCoordinates { get; set; }

        public void SetSignal(int x, int y, ConsoleColor color)
        {
            System.Console.ForegroundColor = color;
            System.Console.SetCursorPosition(x, y);
            System.Console.Write("*");
            System.Console.CursorVisible = false;

        }

        public void ResetSiganl(int x, int y)
        {
            System.Console.ResetColor();
            System.Console.SetCursorPosition(x, y);
            System.Console.Write("0");

        }

        public void RepresentSignal(LampType lamp, ConsoleColor color, bool signal)
        {

                int lampX = LampCoordinates[lamp].X;
                int lampY = LampCoordinates[lamp].Y;

            if (signal)
                    SetSignal(lampX, lampY, color);
                else
                    ResetSiganl(lampX, lampY);
            
        }

        public void ChangeSignal(bool redLamp, bool yellowLamp, bool greeenLamp)
        {
            RepresentSignal(LampType.Red, ConsoleColor.Red,redLamp);
            RepresentSignal(LampType.Yellow, ConsoleColor.Yellow, yellowLamp);
            RepresentSignal(LampType.Green, ConsoleColor.Green, greeenLamp);
        }

        public void ChangeSignal(bool redLamp, bool greeenLamp)
        {
            RepresentSignal(LampType.Red,ConsoleColor.Red, redLamp);
            RepresentSignal(LampType.Green, ConsoleColor.Green, greeenLamp);
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