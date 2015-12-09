using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using Traffic_Light.Modules;

namespace Traffic_Light
{
    public class CrossroadsController : Crossroads
    {
       
        public State State { get; set; }

        public RoadController tLightRoadA { get; set; }
        public RoadController tLightRoadB { get; set; }


        public CrossroadsController()
        {
            allAutoTrLights = new List<TrafficLight>();
            allPedTrLights = new List<TrafficLight>();
         

        }


       
        
        public override void SwithSignal(List<TrafficLight> trLights, SignalColorEnum colorEnumSignalColorEnumColorEnum, int timePause, bool resetSignal)
        {
           switch (colorEnumSignalColorEnumColorEnum)
            {

                case SignalColorEnum.Green:
                    Light(trLights, PositionTrLightEnum.BottomX, PositionTrLightEnum.BottomY, ConsoleColor.Green, timePause, resetSignal);
                    break;

                case SignalColorEnum.Yellow:
                    Light(trLights, PositionTrLightEnum.MiddleX, PositionTrLightEnum.MiddleY, ConsoleColor.Yellow, timePause, resetSignal);
                    break;

                case SignalColorEnum.Red:
                    Light(trLights, PositionTrLightEnum.TopX, PositionTrLightEnum.TopY, ConsoleColor.Red, timePause, resetSignal);
                    break;

                case SignalColorEnum.RedAndYellow:
                    Light(trLights, PositionTrLightEnum.TopX, PositionTrLightEnum.TopY, ConsoleColor.Red, 0, false);
                    Light(trLights, PositionTrLightEnum.MiddleX, PositionTrLightEnum.MiddleY, ConsoleColor.Yellow, timePause, true);
                    Light(trLights, PositionTrLightEnum.TopX, PositionTrLightEnum.TopY, ConsoleColor.Red, 0, true);

                    break;

            }


        }
        public override void BlinkSignal(List<TrafficLight> trLights, SignalColorEnum colorEnumSignal, int quantity, int period)
        {
            for (int i = 0; i < quantity + 1; i++)
            {
                SwithSignal(trLights, colorEnumSignal, period, true);
                Thread.Sleep(period);
            }

        }
        public void Light(List<TrafficLight> trafficLights, PositionTrLightEnum x, PositionTrLightEnum y, ConsoleColor color, int time, bool resetSignal)
        {

            try
            {

                foreach (var trafficLight in trafficLights)
                {
                    Console.ForegroundColor = color;
                    Console.SetCursorPosition(trafficLight.posittionTrLight[x], trafficLight.posittionTrLight[y]);
                    Console.Write(trafficLight.LightKey);
                    Console.CursorVisible = false;
                }



                Thread.Sleep(time);


                foreach (var trafficLight in trafficLights)
                {
                    Console.ResetColor();
                    if (resetSignal)
                    {
                        Console.SetCursorPosition(trafficLight.posittionTrLight[x], trafficLight.posittionTrLight[y]);
                        Console.Write(trafficLight.DefualtLightKey);

                    }
                }
            }

            catch
                (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }

        }


        public void Work()
        {
            while (true)
            {
                State.Work();
            }
            
          
        }

        public void AllPedTrLightWork(int redTime, int greenTime, int blinkGreenNumber, int blinkGreenPeriod)
        {

            SwithSignal(allPedTrLights, SignalColorEnum.Red, 1000, true);
            SwithSignal(allPedTrLights, SignalColorEnum.Green, greenTime, true);
            BlinkSignal(allPedTrLights, SignalColorEnum.Green, blinkGreenNumber, blinkGreenPeriod);
            SwithSignal(allPedTrLights, SignalColorEnum.Red, 0, false);
        }

        public void AllCarTrLightWork(bool message, int redTime, int redAndYellowTime, int greenTime, int blinkGreenNumber, int blinkGreenPeriod, int yellowTime)
        {
            if (message)
            {

                SwithSignal(allAutoTrLights, SignalColorEnum.Red, 1000, true);
                SwithSignal(allAutoTrLights, SignalColorEnum.RedAndYellow, redAndYellowTime, true);
                SwithSignal(allAutoTrLights, SignalColorEnum.Green, greenTime, true);
                BlinkSignal(allAutoTrLights, SignalColorEnum.Green, blinkGreenNumber, blinkGreenPeriod);
                SwithSignal(allAutoTrLights, SignalColorEnum.Yellow, yellowTime, true);
                SwithSignal(allAutoTrLights, SignalColorEnum.Red, 0, false);
                
            }

        }


    }
}