using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading;


namespace TrafficLightClassDiagram
{
    public class TrafficLightController : ITrafficLightController
    {
        public List<TrafficLight> TrafficLights { get; }
        public List<TrafficLightControllerState> ControllerStateList;
        private Timer ChangeStateTimer;
        private int CurrentStateNumber;
        
       
        public string ModeSelectUser { get; set; }

        private string CurrentMode;

        public void AddTrafficlight(int id, string typeTrafficLight)
        {
            if ((typeTrafficLight == "RoadATrafficLight") || (typeTrafficLight == "RoadBTrafficLight"))
                TrafficLights.Add(new CarTrafficLight(id,typeTrafficLight));

            if (typeTrafficLight == "PedestrianTrafficLight")
                TrafficLights.Add(new PedestrianTrafficLight(id, typeTrafficLight));

        }

        public void SwithMode(string mode)
        {
            if (CurrentMode == mode)
                return;

            CurrentStateNumber = 0;           
            switch (CurrentMode)
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
          //  Console.WriteLine("State   " + CurrentStateNumber +" \n");
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