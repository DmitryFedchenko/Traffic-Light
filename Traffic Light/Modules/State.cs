using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Traffic_Light
{
    public abstract class State
    {
        protected CrossroadsController controller;
        public abstract void Work();

        internal void ChangeMode(WorkModeEnum stateDay)
        {
            if (stateDay == WorkModeEnum.Daytime)
            {
               
                controller.State = new CrossroadsDay(controller);
               
            }
            else if (stateDay == WorkModeEnum.Night)
            {
                
                controller.State = new CrossroadsNight(controller);
                
            }
            else
            {
                controller.State = new CrossroadsStop(controller);
                
                

            }
            
        }

        protected State(CrossroadsController controller)
        {
            this.controller = controller;
        }
    }
}
