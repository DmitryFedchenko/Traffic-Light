using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Traffic_Light.Modules
{
    
   public class CrossroadsView
    {
        private Crossroads crossroads;
        
        
        public void DrawEventHandler()
        {
            
            foreach (var trafficLights in crossroads.TrafficLights)
            {
                foreach (var trafficLight in trafficLights.Value)
                {
                    DrowSignal(trafficLight);
                }
              

            }
        }


        public void DrowSignal(TrafficLight trafficLight)
        {
            int tempX = 0;
            int tempY = 0;

            switch (trafficLight.currentSignal)
            {
                case SignalTypes.Green:
                    tempX = trafficLight.posittionTrLight[PositionTypes.LampBottomX];
                    tempY = trafficLight.posittionTrLight[PositionTypes.LampBottomY];
                    SetSignal(tempX, tempY, ConsoleColor.Green);
                    return;


                case SignalTypes.Yellow:
                    tempX = trafficLight.posittionTrLight[PositionTypes.MiddleX];
                    tempY = trafficLight.posittionTrLight[PositionTypes.MiddleY];
                    SetSignal(tempX, tempY, ConsoleColor.Yellow);
                    return;


                case SignalTypes.Red:
                    tempX = trafficLight.posittionTrLight[PositionTypes.LampTopX];
                    tempY = trafficLight.posittionTrLight[PositionTypes.LampTopY];
                    SetSignal(tempX, tempY, ConsoleColor.Red);
                    return;

                case SignalTypes.RedAndYellow:
                    tempX = trafficLight.posittionTrLight[PositionTypes.LampTopX];
                    tempY = trafficLight.posittionTrLight[PositionTypes.LampTopY];
                    SetSignal(tempX, tempY, ConsoleColor.Red);

                    tempX = trafficLight.posittionTrLight[PositionTypes.MiddleX];
                    tempY = trafficLight.posittionTrLight[PositionTypes.MiddleY];
                    SetSignal(tempX, tempY, ConsoleColor.Yellow);
                    return;


                case SignalTypes.Black:
                    tempX = trafficLight.posittionTrLight[PositionTypes.LampTopX];
                    tempY = trafficLight.posittionTrLight[PositionTypes.LampTopY];
                    ResetSiganl(tempX, tempY);

                    if (trafficLight.posittionTrLight.ContainsKey(PositionTypes.MiddleX))
                    {
                        tempX = trafficLight.posittionTrLight[PositionTypes.MiddleX];
                        tempY = trafficLight.posittionTrLight[PositionTypes.MiddleY];
                        ResetSiganl(tempX, tempY);
                    }

                    tempX = trafficLight.posittionTrLight[PositionTypes.LampBottomX];
                    tempY = trafficLight.posittionTrLight[PositionTypes.LampBottomY];
                    ResetSiganl(tempX, tempY);
                    return;



            }
        
        }
        public void SetSignal(int x, int y,ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(x,y);
            Console.Write("*");
            Console.CursorVisible = false;
        }
        public void ResetSiganl(int x, int y)
        {
            
                Console.ResetColor();
                Console.SetCursorPosition(x, y);
                Console.Write("0");

        }

        public CrossroadsView(Crossroads crossroads , CrossroadsController crossroadsController)
        {
            this.crossroads = crossroads;
            crossroadsController.drawEvenet += DrawEventHandler;
           
        }

        public void DrawCrossroads()
        {
            Console.WriteLine("                                                               ");
            Console.WriteLine("                                                               ");
            Console.WriteLine("                  _  |               |  _                      ");
            Console.WriteLine("                 |0| |## ## ## ## ## | |0|                     ");
            Console.WriteLine("                 |0| |## ## ## ## ## | |0|                     ");
            Console.WriteLine("       _ _           |## ## ## ## ## |           _ _           ");
            Console.WriteLine("      |0|0|          |     _____     |          |0|0|          ");
            Console.WriteLine("      _______________|    |0|0|0|    |__________________       ");
            Console.WriteLine("       ######      _                    _      ######          ");
            Console.WriteLine("       ######     |0|                  |0|     ######          ");
            Console.WriteLine("       ######     |0|                  |0|     ######          ");
            Console.WriteLine("       ######     |0|      _____       |0|     ######          ");
            Console.WriteLine("      _______________     |0|0|0|     ___________________      ");
            Console.WriteLine("       _ _        _  |               |  _        _ _           ");
            Console.WriteLine("      |0|0|      |0| |## ## ## ## ## | |0|      |0|0|          ");
            Console.WriteLine("                 |0| |## ## ## ## ## | |0|                     ");
            Console.WriteLine("                     |## ## ## ## ## |                         ");
            Console.WriteLine("                     |               |                         ");
            Console.WriteLine("                     |               |                         ");
            Console.WriteLine("                     |               |                         ");
            Console.WriteLine(" \n\nTo select a mode of day, click on the: 'd',\n for night: 'n'\n and for the stop work: 's'.");
        }


        
    }
}
