using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;


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
                SetMode(ModeTypes.Daytime, dayTimeMode.states);

            if (mode == ModeTypes.Night)
                SetMode(ModeTypes.Night, nightMode.states);

            if (mode == ModeTypes.Stop)
                SetMode(ModeTypes.Stop, stopMode.states); 

            CurrentMode = mode;
            ChangeState(CurrentMode);
        }

        public void SetMode(ModeTypes mode, List<CrossroadsState> modeList )
        {
            foreach (var crossroadsState in modeList)
            {
                if (CurrentMode == mode)
                    crossroadsController.SetCrossroadsState(crossroadsState);
            }
        
            
            ChangeState(CurrentMode);
        }

        

        public void SetModeEvent(Object source, ElapsedEventArgs e)
        {
            
          ChangeState(CurrentMode);
            
        }

    
    
    }
}
