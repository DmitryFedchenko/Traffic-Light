using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading;


namespace TrafficLightClassDiagram
{
    public class TrafficLightController : ITrafficLightControl
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

            if (typeTrafficLight == "pedestrianTrafficLight")
                TrafficLights.Add(new PedestrianTrafficLight(id, typeTrafficLight));

        }

        private void SwithMode()
        {
            switch (ModeSelectUser)
            {
                case "DayTime":
                    ControllerStateList = new ControllerMode().DayTime;
                    CurrentMode = ModeSelectUser;
                    break;

                case "Night":
                    ControllerStateList = new ControllerMode().NightTime;
                    CurrentMode = ModeSelectUser;
                    break;

                case "Stop":
                    ControllerStateList = new ControllerMode().Stop;
                    CurrentMode = ModeSelectUser;
                    break;
               
                default:
                    return;
            }

        }

       
        private void SetState(object obj)
        {
           
            Console.WriteLine("State " + CurrentStateNumber + "\n");

            // Set current state to all road A  traffic light 
            foreach (var carTrafficlight in TrafficLights.FindAll(x => x.TrafficLightType == "RoadATrafficLight"))
                carTrafficlight.SetSignal(ControllerStateList[CurrentStateNumber].RoadASignals);

            // Set current state to all road B traffic lights   
            foreach (var carTrafficlight in TrafficLights.FindAll(x => x.TrafficLightType == "RoadBTrafficLight"))
                carTrafficlight.SetSignal(ControllerStateList[CurrentStateNumber].RoadBSignals);

            // Set current state to all pedestrian traffic lights   
            foreach (var pedestrianTrafficLight in TrafficLights.FindAll(x => x.TrafficLightType == "pedestrianTrafficLight"))
                pedestrianTrafficLight.SetSignal(ControllerStateList[CurrentStateNumber].PedestrianTrafficLightSignals);

            ChangeStateTimer.Change(ControllerStateList[CurrentStateNumber].TimeWait,0);
            CurrentStateNumber++;

            Console.WriteLine(" \n");

            // Check to opportunity of next iterate states in this mode
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