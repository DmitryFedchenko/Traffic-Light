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
        public List<CarTrafficLight> CarTrafficlights;
        public List<PedestrianTrafficLight> PedestrianTrafficlights;
        public Timer ChangeStateTimer;

        public List<TrafficLightControllerState> StateList; 

        public AutoResetEvent autoEvent = new AutoResetEvent(false);

        public string CurrentMode { get; set; }
        private int CurrentStateNumber;
        private int TimeWaite;
        
        public void AddTrafficlight(int id, string type)
        {
            switch (type)
            {
                case "CarTrafficLight":
                    CarTrafficlights.Add(new CarTrafficLight(id));
                    break;

                case "PedestrianTrafficLight":
                    PedestrianTrafficlights.Add(new PedestrianTrafficLight(id));
                    break;
                default:
                    break;
            }
        }
        public ControllerMode ControllerMode { get; set; }
       
               
        
        private void SwithMode()
        {
            switch (CurrentMode)
            {
                case "DayTime":
                    StateList = new DayTimeMode().States;
                    break;
                case "Night":
                    StateList = new NightMode().States;
                    break;

                default:
                    break;
            }

        }

        public void IterateControllerStates()
        {
            ChangeStateTimer = new Timer(SetState, autoEvent, 0,0);

            autoEvent.WaitOne(TimeWaite);
            if (CurrentStateNumber < StateList.Count)
                IterateControllerStates();

        }

        private void SetState(object obj)
        {
            foreach (var carTrafficlight in CarTrafficlights)
            {
                switch (carTrafficlight.Id)
                {
                    case 0:
                        carTrafficlight.ChangeSignalLamp(StateList[CurrentStateNumber].TrafficLightRoadA);
                        break;
                    case 1:
                        carTrafficlight.ChangeSignalLamp(StateList[CurrentStateNumber].TrafficLightRoadB);
                        break;
                   
                    default:
                        break;
                }
            }

            foreach (var pedestrianTrafficlight in PedestrianTrafficlights)
            {
                pedestrianTrafficlight.ChangeSignalLamp(StateList[CurrentStateNumber].PedestrianTrafficlight);
            }
        }

        public void StartWork()
        {
            IterateControllerStates();
            SwithMode();
        }
        public TrafficLightController()
        {
            


        }
    }
}