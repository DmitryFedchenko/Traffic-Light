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
        public List<CarTrafficLight> CarTrafficlights { get; } = new List<CarTrafficLight>();
        public List<PedestrianTrafficLight> PedestrianTrafficlights { get; } = new List<PedestrianTrafficLight>();
        private Timer ChangeStateTimer;
        private ControllerMode ControllerMode { get; set; }

        private List<TrafficLightControllerState> ListStatesController; 
        private AutoResetEvent autoResetEvent = new AutoResetEvent(false);

        public string CurrentMode { get; set; } = "DayTime";
        private int CurrentStateNumber;
        private int TimeWaiteNextState;


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
            switch (CurrentMode)
            {
                case "DayTime":
                    ListStatesController = new DayTimeMode().States;
                    break;
                case "Night":
                    ListStatesController = new NightMode().States;
                    break;

                default:
                    break;
            }

        }

        private void IterateControllerStates()
        {
           
            ChangeStateTimer = new Timer(new TimerCallback(SetState), autoResetEvent, TimeWaiteNextState, -1);
           
            //To stop main thread
            autoResetEvent.WaitOne();
            ChangeStateTimer.Dispose();

            if (CurrentStateNumber < ListStatesController.Count)
                IterateControllerStates();
           
        }

        private void SetState(object obj)
        {
            Console.WriteLine("State " + CurrentStateNumber + "\n" );
            foreach (var carTrafficlight in CarTrafficlights)
            {
                if(carTrafficlight.Id == 0)
                    carTrafficlight.ChangeSignalLamp(ListStatesController[CurrentStateNumber].TrafficLightRoadA);


                if (carTrafficlight.Id == 1)
                    carTrafficlight.ChangeSignalLamp(ListStatesController[CurrentStateNumber].TrafficLightRoadB);
            }
                
            foreach (var pedestrianTrafficlight in PedestrianTrafficlights)
                pedestrianTrafficlight.ChangeSignalLamp(ListStatesController[CurrentStateNumber].PedestrianTrafficlight);

            var  autoEvent = (AutoResetEvent)obj;

            TimeWaiteNextState = ListStatesController[CurrentStateNumber].TimeWait;

            CurrentStateNumber++;
            Console.WriteLine( " \n");
            
            //To start main thread
            autoEvent.Set();

        }

        public void StartWork()
        {
            SwithMode();
            IterateControllerStates();
            
        }
        
    }
}