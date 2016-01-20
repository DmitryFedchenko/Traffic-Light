using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TrafficLights;

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

        private int RunTimeState;


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
                    IterateControllerStates();
                    
                    break;
                case "Night":
                    ListStatesController = new NightMode().ListStates;
                    CurrentMode = ModeSelectUser;
                    IterateControllerStates();
                    break;

                case "Stop":
                    ListStatesController = new StopMode().ListStates;
                    CurrentMode = ModeSelectUser;
                    IterateControllerStates();
                    break;

                default:
                    return;
            }

        }

        private void IterateControllerStates()
        {                      
                ChangeStateTimer = new Timer(new TimerCallback(SetState), null, RunTimeState, -1);
            Thread.CurrentThread.Join();
         
        }

        private void SetState(object obj)
        {
            Console.WriteLine("State " + CurrentStateNumber + "\n");
           
            // set state to all car traffic light 
            foreach (var carTrafficlight in CarTrafficlights)
            {
                if(carTrafficlight.Id == 0)
                    carTrafficlight.ChangeSignalLamp(ListStatesController[CurrentStateNumber].TrafficLightRoadA);
                                
                if (carTrafficlight.Id == 1)
                    carTrafficlight.ChangeSignalLamp(ListStatesController[CurrentStateNumber].TrafficLightRoadB);
            }
            
            // set state to all pedestrian traffic lights   
            foreach (var pedestrianTrafficlight in PedestrianTrafficlights)
                 pedestrianTrafficlight.ChangeSignalLamp(ListStatesController[CurrentStateNumber].PedestrianTrafficlight);

            RunTimeState = ListStatesController[CurrentStateNumber].TimeWait;

            Console.WriteLine( " \n");

            CurrentStateNumber++;
            ChangeStateTimer.Dispose();

            // Check to opportunity of next iterate states in this mode
            bool existIndexState = CurrentStateNumber < ListStatesController.Count;
            bool validMode = ModeSelectUser == CurrentMode; 

            if (validMode && existIndexState)
            IterateControllerStates();

            CurrentStateNumber = 0;
            SwithMode();
           
        }

        public void StartWork()
        {
            SwithMode();
                     
        }
        public TrafficLightController()
        {
            CarTrafficlights  = new List<CarTrafficLight>();
            PedestrianTrafficlights = new List<PedestrianTrafficLight>();
            ModeSelectUser = "DayTime";
        }
        
    }
}