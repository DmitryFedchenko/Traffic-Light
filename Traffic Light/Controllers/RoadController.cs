using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Traffic_Light.Modules;

namespace Traffic_Light
{
    public  class RoadController
    {
       
        protected Crossroads Crossroads;

        public List<TrafficLight> autoTrLights = new List<TrafficLight>();

        public List<TrafficLight> pedTrLights = new List<TrafficLight>();

       

        public void AddCarTrLight(int lampTopX, int lampTopY, int lampMiddleX, int lampMiddleY, int lampBottomX, int lampBottomY)
        {
            var trLight = new CarTrLight(lampTopX, lampTopY, lampMiddleX, lampMiddleY, lampBottomX, lampBottomY);
            autoTrLights.Add(trLight);
            Crossroads.allAutoTrLights.Add(trLight);
        }



        public void AddPedTLight(int lampTopX, int lampTopY, int lampBottomX, int lampBottomY)
        {
            var trLight = new PedTrLight(lampTopX, lampTopY, lampBottomX, lampBottomY);
            pedTrLights.Add(trLight);
            Crossroads.allPedTrLights.Add(trLight);
        }

    


        public void AutoMobTrLightWork(bool message, int redTime, int redAndYellowTime, int greenTime, int blinkGreenNumber, int blinkGreenPeriod, int yellowTime)
        {
            if (message)
            {

            Crossroads.SwithSignal(autoTrLights,SignalColorEnum.Red, 1000, true);
            Crossroads.SwithSignal(autoTrLights, SignalColorEnum.RedAndYellow, redAndYellowTime, true);
            Crossroads.SwithSignal(autoTrLights, SignalColorEnum.Green, greenTime, true);
            Crossroads.BlinkSignal(autoTrLights, SignalColorEnum.Green, blinkGreenNumber, blinkGreenPeriod);
            Crossroads.SwithSignal(autoTrLights, SignalColorEnum.Yellow, yellowTime, true);
            Crossroads.SwithSignal(autoTrLights, SignalColorEnum.Red, 0, false);
           }
            
        }

        public void PedMobTrLightWork(int redTime, int greenTime, int blinkGreenNumber, int blinkGreenPeriod)
        {
            Crossroads.SwithSignal(pedTrLights, SignalColorEnum.Red, 1000, true);
            Crossroads.SwithSignal(pedTrLights, SignalColorEnum.Green, greenTime, true);
            Crossroads.BlinkSignal(pedTrLights, SignalColorEnum.Green, blinkGreenNumber, blinkGreenPeriod);
            Crossroads.SwithSignal(pedTrLights, SignalColorEnum.Red, 0, false);
        }


        public RoadController(Crossroads controller)
        {
            Crossroads = controller;
        }

       
    }

}


