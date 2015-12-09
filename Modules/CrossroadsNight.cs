using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Traffic_Light.Modules;

namespace Traffic_Light
{
    public class CrossroadsNight : State
    {
        public override void Work()
        {
              controller.SwithSignal(controller.allPedTrLights, SignalColorEnum.Red, 0, true);
              controller.SwithSignal(controller.allAutoTrLights, SignalColorEnum.Red, 0, true);
             controller.BlinkSignal(controller.allAutoTrLights, SignalColorEnum.Yellow, 2, 500);
            

        }

        public CrossroadsNight(CrossroadsController controller) 
            : base(controller)
        {
                  
        }
        
    }
}