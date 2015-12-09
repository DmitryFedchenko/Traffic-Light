using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traffic_Light.Modules;

namespace Traffic_Light
{
    class CrossroadsStop : State
    {
        private bool resetSignals;
        public CrossroadsStop(CrossroadsController controller) : base(controller)
        {
        }

        public override void Work()
        {

            if (!resetSignals)
            {
                controller.SwithSignal(controller.allAutoTrLights, SignalColorEnum.Red, 0, true);
                controller.SwithSignal(controller.allPedTrLights, SignalColorEnum.Red, 0, true);
                resetSignals = true;
            }
        }
    }
}
