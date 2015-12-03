using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Traffic_Light.Modules
{
    class TrafficLightManager
    {
     
        List<ITrafficLight> trafficLights = new List<ITrafficLight>();


        public void AddTrafficLiht( ITrafficLight traficLight) 
        {
            trafficLights.Add(traficLight);
        }

        
        public void SwithSignal( SignalColors colorSignalColors, int timePause)
        {
            
                switch (colorSignalColors)
                {
                    case SignalColors.Green:
                        Light(4, 5, ConsoleColor.Green, timePause, true);
                        break;

                    case SignalColors.Yellow:
                        Light(2, 3, ConsoleColor.Yellow, timePause, true);
                        break;

                    case SignalColors.Red:
                        Light(0, 1, ConsoleColor.Red, timePause, true);
                        break;

                    case SignalColors.RedAndYelow:
                        Light(0, 1, ConsoleColor.Red, 0, false);
                        Light(2, 3, ConsoleColor.Yellow, timePause, true);
                        Light(0, 1, ConsoleColor.Red, 0, true);

                        break;
                
            }
            

        }

        public void Light(int x, int y, ConsoleColor color, int time, bool setDefualtLight)
        {
           
            try
            {
                foreach (var trafficLight in trafficLights)
                {
                    Console.ForegroundColor = color;
                    Console.SetCursorPosition(trafficLight.Possition[x], trafficLight.Possition[y]);
                    Console.Write(trafficLight.LightKey);
                }

                Thread.Sleep(time);

                foreach (var trafficLight in trafficLights)
                {
                    Console.ResetColor();
                    if (setDefualtLight)
                    {
                        Console.SetCursorPosition(trafficLight.Possition[x], trafficLight.Possition[y]);
                        Console.Write(trafficLight.DefualtLightKey);

                    }
                }
                
                
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }

        }
        public void Work(int redTime, int redAndYellowTime, int greenTime, int blinkGreenNumber, int blinkGreenPeriod, int yellowTime)
        {
            while (true)
            {
                SwithSignal(SignalColors.Red, redTime);
                SwithSignal(SignalColors.RedAndYelow, redAndYellowTime);
                SwithSignal(SignalColors.Green, greenTime);
                BlinkSignal(SignalColors.Green, blinkGreenNumber, blinkGreenPeriod);
                SwithSignal(SignalColors.Yellow, yellowTime);

            }

        }



        public void BlinkSignal(SignalColors colorSignal, int quantity, int period)
        {
            for (int i = 0; i < quantity + 1; i++)
            {
                SwithSignal(colorSignal, period);
                Thread.Sleep(period);
            }

        }

    }
}
