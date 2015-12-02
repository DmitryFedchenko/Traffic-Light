using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Traffic_Light.Modules
{
    class AutomobileTrafficLight : ITrafficLight
    {
        public string LightKey { get; set; } = "*";

        public string DefualtLightKey { get; set; } = " ";

        public int[] possition = new int[6];

       

        public AutomobileTrafficLight(int lampTopX, int lampTopY, int lampMiddleX,int lampMiddleY, int lampBottomX, int lampBottomY)
        {
            possition[0] = lampTopX;
            possition[1] = lampTopY;
            possition[2] = lampMiddleX;
            possition[3] = lampMiddleY;
            possition[4] = lampBottomX;
            possition[5] = lampBottomY;
        }
       


        public void SwithSignal( SignalColors colorSignalColors, int timePause)
        {

            switch (colorSignalColors)
            {
                case SignalColors.Green:
                    Light(LightKey,possition[4],possition[5],ConsoleColor.Green, timePause,true);
                    break;

                case SignalColors.Yellow:
                    Light(LightKey, possition[2], possition[3], ConsoleColor.Yellow, timePause,true);
                    break;

                case SignalColors.Red:
                    Light(LightKey, possition[0], possition[1], ConsoleColor.Red, timePause,true);
                    break;

                case SignalColors.RedAndYelow:
                    Light(LightKey, possition[0], possition[1], ConsoleColor.Red, 0, false);
                    Light(LightKey, possition[2], possition[3], ConsoleColor.Yellow, timePause,true);
                    
                    break;
             }
            
        }

        public void Light(string key, int x, int y, ConsoleColor color, int time, bool setDefualtLight)
        {
             try
            {
                Console.ForegroundColor = color;
                Console.SetCursorPosition( x,  y);
                Console.Write(key);
                Thread.Sleep(time);
                Console.ResetColor();
                if (setDefualtLight)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write(DefualtLightKey);

                }
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        
    }
        public void Work()
        {
            while (true)
            {
                SwithSignal(SignalColors.Red,5000);
                SwithSignal(SignalColors.RedAndYelow,5000);
                SwithSignal(SignalColors.Green,5000 );
                BlinkSignal(SignalColors.Green, 10 , 500);
                SwithSignal(SignalColors.Yellow, 5000);
            }
        }



        public void BlinkSignal(SignalColors colorSignal, int quantity, int period)
        {
            for (int i = 0; i < quantity; i++)
            {
                SwithSignal(colorSignal, period);
                Thread.Sleep(period);
            }
          
         }

       
    }
}
