using NLog;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading;


namespace Traffic_Light.Model
{
    public class TrafficLightController : ITrafficLightController
    {
        readonly Logger Log = LogManager.GetCurrentClassLogger();

        private  List<TrafficLight> TrafficLights { get; }
        private TrafficLightControllerStateTables ControllerStateList;
        private Timer ChangeStateTimer;
        private int CurrentStateNumber;

        private TrafficLightModeType CurrentMode;

        public void AddTrafficlight(TrafficLight trafficLight)
        {
         TrafficLights.Add(trafficLight);
        }

        public void SwithMode(TrafficLightModeType mode)
        {
            Log.Trace(mode);
            if (CurrentMode == mode)
                return;

            if (ControllerStateList.ModesTable.ContainsKey(mode))
                CurrentMode = mode;

            CurrentStateNumber = 0;           
        }

       
        private void SetState(object obj)
        {
            Log.Trace("\n                                                   State № "+CurrentStateNumber+"\n");
            // Set current state to all traffic lights   
            foreach (var trafficlight in TrafficLights)
                trafficlight.SetState(ControllerStateList.ModesTable[CurrentMode][CurrentStateNumber]);
                   
            ChangeStateTimer.Change(ControllerStateList.ModesTable[CurrentMode][CurrentStateNumber].TimeWait,0);
            CurrentStateNumber++;
                     
            // Check opportunity of next iterate states in this mode
            bool existIndexState = CurrentStateNumber < ControllerStateList.ModesTable[CurrentMode].Count;
       
            if (!existIndexState)
                CurrentStateNumber = 0;
        }

        public void StartWork()
        {
            if (ControllerStateList != null)
            ChangeStateTimer = new Timer(SetState, null, 0, -1);
                                        
        }
        public TrafficLightController()
        {
            TrafficLights = new List<TrafficLight>();
            ControllerStateList = new TrafficLightControllerStateTables();
        }
    }
}