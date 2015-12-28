using System.Collections.Generic;
using System.Timers;
using Traffic_Light.Model.Modes;
using Traffic_Lights.Model.Constants;
using Traffic_Lights.Model.Models;
using Traffic_Lights.Model.Modes;
using Timer = System.Timers.Timer;

namespace Traffic_Lights.Model.Controllers
{
    public class CrossroadsController
    {
        private Timer timer;
        public List<CrossroadsStateModel> States;

        public ModeTypes CurrentMode { get; set; }
        private int stateNumber  = 0;
     
    
        public CrossroadsMode Mode { get; set; }
        protected CrossroadsModel crossroadsModel;


        public void AddTrafficLight(ParticipanTypes participan, int lampTopX, int lampTopY, int lampMiddleX, int lampMiddleY, int lampBottomX, int lampBottomY)
        {
            bool absenceMidleLamp = (lampMiddleX == 0) || (lampMiddleY == 0);

            TrafficLightModel trLight;

            if (!absenceMidleLamp)
                trLight = new TrafficLightModel(lampTopX, lampTopY, lampMiddleX, lampMiddleY, lampBottomX, lampBottomY);
            else
                trLight = new TrafficLightModel(lampTopX, lampTopY, lampBottomX, lampBottomY);

            crossroadsModel.AddTrafficLight(participan, trLight);
        }

        public void SetCrossroadsState(object obj, ElapsedEventArgs args)
        {

            if (stateNumber < States.Count)
                {
                    crossroadsModel.ChangeCurrentState(States[stateNumber]);
                    int tempInterval = States[stateNumber].Time;
                    timer.Interval = tempInterval != 0 ? tempInterval : 1;
                    ++stateNumber;
                }
                else
                {
                    stateNumber = 0;
                    timer.Stop();
                    timer.Dispose();
                    Mode.StartWorkMode();
                }
         
            
        }


        public CrossroadsController(CrossroadsModel crossroadsModel)
        {
            this.crossroadsModel = crossroadsModel;
            Mode = new DayTimeMode(this);
         
        }

        public void Exit()
        {
            timer.Stop();
            timer.Dispose();
        }

        public void SetMode()
        {
                timer = new Timer();
                timer.AutoReset = true;
                timer.Enabled = true;
                timer.Elapsed += SetCrossroadsState;
                 
        }

       
    }
}
