using System.Collections.Generic;


namespace Traffic_Light.Modules
{
    public class CrossroadsMode
    {
        private DayTimeMode dayTimeMode;
        private NightMode nightMode;
        private StopMode stopMode;
        private CrossroadsController crossroadsController;

        public ModeTypes CurrentMode { get; set; }
       
        public CrossroadsMode(CrossroadsController crossroadsController)
        {
            dayTimeMode = new DayTimeMode();
            nightMode = new NightMode();
            stopMode = new StopMode();

            this.crossroadsController = crossroadsController;
        }

        public void ChangeMode(ModeTypes mode)
        {
            CurrentMode = mode;

            if (mode == ModeTypes.Daytime)
                SetMode(ModeTypes.Daytime, dayTimeMode.states);

            if (mode == ModeTypes.Night)
                SetMode(ModeTypes.Night, nightMode.states);

            if (mode == ModeTypes.Stop)
                SetMode(ModeTypes.Stop, stopMode.states); 

        }

        public void SetMode(ModeTypes mode, List<CrossroadsState> modeList )
        {
            foreach (var crossroadsState in modeList)
            {
                if (CurrentMode == mode)
                    crossroadsController.SetCrossroadsState(crossroadsState);
            }
       
         
        }

      
    }
}
