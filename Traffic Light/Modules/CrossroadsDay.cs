using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Traffic_Light.Modules;

namespace Traffic_Light
{
    public class CrossroadsDay : State
    {
        public override void Work()
        {
            
            controller.SwithSignal(controller.allPedTrLights, SignalColorEnum.Red, 0, false);
            controller.SwithSignal(controller.allAutoTrLights,SignalColorEnum.Red, 0,false);
            controller.tLightRoadB.AutoMobTrLightWork(true, redTime: 5000, redAndYellowTime: 1500, greenTime: 3000, blinkGreenNumber: 2, blinkGreenPeriod: 500, yellowTime: 2000);
            controller.tLightRoadA.AutoMobTrLightWork(true, redTime: 5000, redAndYellowTime: 1500, greenTime: 3000, blinkGreenNumber: 2, blinkGreenPeriod: 500, yellowTime: 2000);
            controller.AllPedTrLightWork(redTime: 1000, greenTime: 3000, blinkGreenNumber: 4, blinkGreenPeriod: 500);

        }


        
        public CrossroadsDay(CrossroadsController controller) 
            : base(controller)
        {
          
        }
    }
}