using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading;
using TrafficLitht;

namespace TrafficLightClassDiagram
{
    public class TrafficLightController : ITrafficLightControl
    {
        public List<CarTrafficLight> CarTrafficlights { get; } 
        public List<PedestrianTrafficLight> PedestrianTrafficlights { get; }
        private Timer ChangeStateTimer;
        private int CurrentStateNumber;
        private List<TrafficLightControllerState> ListStatesController; 
       
        public string ModeSelectUser { get; set; }

        private string CurrentMode;

        public void AddTrafficlight(int id, string typeTrafficLight)
        {
            bool isCarTrafficLight = typeTrafficLight == "CarTrafficLight";           
            if (isCarTrafficLight)
                CarTrafficlights.Add(new CarTrafficLight(id));


            bool isPedestrintrafficLight = typeTrafficLight == "PedestrianTrafficLight";
            if (isPedestrintrafficLight)
                    PedestrianTrafficlights.Add(new PedestrianTrafficLight(id));
                 
        }
        
       
      
        private void SwithMode()
        {
            switch (ModeSelectUser)
            {
                case "DayTime":
                    ListStatesController = new DayTimeMode().ListStates;
                    CurrentMode = ModeSelectUser;
                    break;

                case "Night":
                    ListStatesController = new NightMode().ListStates;
                    CurrentMode = ModeSelectUser;
                    break;

                case "Stop":
                    ListStatesController = new StopMode().ListStates;
                    CurrentMode = ModeSelectUser;
                    break;
               
                default:
                    return;
            }

        }

       
        private void SetState(object obj)
        {
           
            Console.WriteLine("State " + CurrentStateNumber + "\n");
           
            // Set current state to all car traffic light 
            foreach (var carTrafficlight in CarTrafficlights)
            {
                if(carTrafficlight.Id == 0)
                    carTrafficlight.ChangeSignalLamp(ListStatesController[CurrentStateNumber].TrafficLightRoadA);
                                
                if (carTrafficlight.Id == 1)
                    carTrafficlight.ChangeSignalLamp(ListStatesController[CurrentStateNumber].TrafficLightRoadB);
            }

            // Set current state to all pedestrian traffic lights   
            foreach (var pedestrianTrafficlight in PedestrianTrafficlights)
                 pedestrianTrafficlight.ChangeSignalLamp(ListStatesController[CurrentStateNumber].PedestrianTrafficlight);

            ChangeStateTimer.Change(ListStatesController[CurrentStateNumber].TimeWait,0);
            CurrentStateNumber++;

            Console.WriteLine(" \n");

            // Check to opportunity of next iterate states in this mode
            bool existIndexState = CurrentStateNumber < ListStatesController.Count;
            bool validMode = ModeSelectUser == CurrentMode;

            if (!validMode || !existIndexState)
            {
                CurrentStateNumber = 0;
                SwithMode();
            }
                
           
        }

        public void StartWork()
        {
            SwithMode();

            if (ListStatesController != null)
            ChangeStateTimer = new Timer(SetState, null, 0, -1);
                               
        }
        public TrafficLightController()
        {
            CarTrafficlights  = new List<CarTrafficLight>();
            PedestrianTrafficlights = new List<PedestrianTrafficLight>();
            ModeSelectUser = "DayTime";
        }
    }
}