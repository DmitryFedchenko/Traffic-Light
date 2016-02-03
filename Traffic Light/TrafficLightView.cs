using NLog;
using System;
using System.Collections.Generic;
using Traffic_Light.Model;

namespace Traffic_Light.Console
{
    public class TrafficLightView : ITrafficLightView
    {
        Logger Log = LogManager.GetCurrentClassLogger();
        public int Id { get; set; }
        public TrafficLightType TrafficLightType { get; set; }
        public Dictionary<LampType, CoordinateLamp> LampCoordinates { get; set; }

        public void SetSignal(int x, int y, ConsoleColor color)
        {
            Log.Trace("Traffic light type : {0}; The current color of signal: {1}; ", TrafficLightType, color);
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




        public TrafficLightView(TrafficLightType participan ,int topX, int topY, int middleX, int middleY)
        {
            TrafficLightType = participan;
            LampCoordinates = new Dictionary<LampType,CoordinateLamp>();
            LampCoordinates.Add(LampType.Red, new CoordinateLamp(topX, topY));
            LampCoordinates.Add(LampType.Green, new CoordinateLamp(middleX, middleY));

        }


        public TrafficLightView(TrafficLightType participan, int lampTopX, int lampTopY, int lampMiddleX, int lampMiddleY, int lampBottomX, int lampBottomY)
            : this(participan,lampTopX, lampTopY, lampBottomX, lampBottomY)
        {
            LampCoordinates.Add(LampType.Yellow, new CoordinateLamp(lampMiddleX, lampMiddleY));
        }

        

    }

    public enum LampType
    {
        Green,Red,Yellow
    }


}