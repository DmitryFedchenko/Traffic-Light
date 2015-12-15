using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traffic_Light.Modules
{
    public class CrossroadsMode
    {
        public ModeTypes CurrentMode { get; set; }
        private DayTimeMode dayTimeMode;
        private NightMode nightMode;
        private StopMode stopMode;
        private CrossroadsController crossroadsController;

        public CrossroadsMode(CrossroadsController crossroadsController)
        {

            dayTimeMode = new DayTimeMode();
            nightMode = new NightMode();
            stopMode = new StopMode();
            this.crossroadsController = crossroadsController;
        }

        public void ChangeState(ModeTypes mode)
        {
            if (mode == ModeTypes.Daytime)
                DayMode();

            if (mode == ModeTypes.Night)
                NightMode();

            if (mode == ModeTypes.Stop)
                StopMode();
        }

        public void DayMode()
        {
            CurrentMode = ModeTypes.Daytime;
            foreach (var someState in dayTimeMode.states)
            {
                if (CurrentMode == ModeTypes.Daytime)
                    crossroadsController.SetCrossroadsState(someState);

            }
            ChangeState(CurrentMode);
        }

       
        public void NightMode()
        {
            CurrentMode = ModeTypes.Night;
            foreach (var someState in nightMode.states)
            {
                if (CurrentMode == ModeTypes.Night)
                    crossroadsController.SetCrossroadsState(someState);
            }
            ChangeState(CurrentMode);
        }

        public void StopMode()
        {
            CurrentMode = ModeTypes.Stop;
            foreach (var someState in stopMode.states)
            {
                if (CurrentMode == ModeTypes.Stop)
                    crossroadsController.SetCrossroadsState(someState);
                
            }
            ChangeState(CurrentMode);
        }

      

    }
}
