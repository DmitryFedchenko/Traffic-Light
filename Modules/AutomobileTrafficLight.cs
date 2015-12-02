using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traffic_Light.Modules
{
    class AutomobileTrafficLight : ITrafficLight
    {
        private string lampTop;
        private string lampMiddle;
        private string lampBottom;

        public string LampTop
        {
            get { return lampTop; }
            private set { lampTop = value; }
        }

        public string LampMiddle
        {
            get { return lampMiddle; }
            private set { lampMiddle = value; }
        }

        public string LampBottom
        {
            get { return lampBottom; }
            private set { lampBottom = value; }
        }


        public void SwithSignal( SignalColors colorSignalColors, int timePause)
        {
            switch (colorSignalColors)
            {
                case SignalColors.Green:
                    LampBottom = "Green";
                    break;

                case SignalColors.Yellow:
                    LampMiddle = "Yellow";
                    break;

                case SignalColors.Red:
                    LampTop = "Red";
                    break;

                case SignalColors.RedAndYelow:
                    LampMiddle = "Yelow";
                    LampBottom = "Red";
                    break;
                
            }
        }


        public void Work()
        {
            while (true)
            {
                SwithSignal(SignalColors.Red,3000);
                SwithSignal(SignalColors.RedAndYelow,2000);
                SwithSignal(SignalColors.Green,3000 );
                BlinkSignal(SignalColors.Green, 2 , 500);
                SwithSignal(SignalColors.Yellow, 2000);
            }
        }



        public void BlinkSignal(SignalColors colorSignal, int quantity, int period)
        {
            for (int i = 0; i < quantity; i++)
            {
                SwithSignal(colorSignal, period);
            }
          
         }

       
    }
}
