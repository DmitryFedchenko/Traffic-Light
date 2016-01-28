using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading;


namespace Traffic_Light.Model
{
    public class TrafficLightController : ITrafficLightController
    {
        private  List<TrafficLight> TrafficLights { get; }
        private List<TrafficLightControllerState> ControllerStateList;
        private Timer ChangeStateTimer;
        private int CurrentStateNumber;

        private string CurrentMode;

        public void AddTrafficlight(TrafficLight trafficLight)
        {
         TrafficLights.Add(trafficLight);
        }

        public void SwithMode(string mode)
        {
            if (CurrentMode == mode)
                return;

            CurrentStateNumber = 0;           
            switch (mode)
            {
                case "DayTime":
                    ControllerStateList = new ControllerMode().DayTime;
                    CurrentMode = mode;
                    break;

                case "Night":
                    ControllerStateList = new ControllerMode().NightTime;
                    CurrentMode = mode;
                    break;

                case "Stop":
                    ControllerStateList = new ControllerMode().Stop;
                    CurrentMode = mode;
                    break;
               
                default:
                    return;
            }

        }

       
        private void SetState(object obj)
        {
            // Set current state to all traffic lights   
            foreach (var trafficlight in TrafficLights)
                trafficlight.SetState(ControllerStateList[CurrentStateNumber]);
                   
            ChangeStateTimer.Change(ControllerStateList[CurrentStateNumber].TimeWait,0);
            CurrentStateNumber++;
                     
            // Check opportunity of next iterate states in this mode
            bool existIndexState = CurrentStateNumber < ControllerStateList.Count;
       
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
            ControllerStateList = new ControllerMode().DayTime;
        }
    }
}