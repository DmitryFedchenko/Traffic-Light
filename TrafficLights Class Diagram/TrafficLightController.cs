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

        private List<TrafficLightControllerState> ListStatesController; 
        private AutoResetEvent AutoResetEventTimer = new AutoResetEvent(false);

        public string CurrentMode { get; set; } = "DayTime";
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
            switch (CurrentMode)
            {
                case "DayTime":
                    ListStatesController = new DayTimeMode().ListStates;
                    IterateControllerStates();
                    break;
                case "Night":
                    ListStatesController = new NightMode().ListStates;
                    IterateControllerStates();
                    break;

                default:
                    break;
            }

        }

        private void IterateControllerStates()
        {

            for (int currentStateNumber = 0; currentStateNumber < ListStatesController.Count; currentStateNumber++)
            {
                ChangeStateTimer = new Timer(new TimerCallback(SetState), currentStateNumber, RunTimeState, -1);

                // stop main thread
                AutoResetEventTimer.WaitOne();
                ChangeStateTimer.Dispose();
            }

            SwithMode();
        }

        private void SetState(object obj)
        {

            int currentStateNumber = (int)obj;

            Console.WriteLine("State " + currentStateNumber + "\n" );
            foreach (var carTrafficlight in CarTrafficlights)
            {
                if(carTrafficlight.Id == 0)
                    carTrafficlight.ChangeSignalLamp(ListStatesController[currentStateNumber].TrafficLightRoadA);


                if (carTrafficlight.Id == 1)
                    carTrafficlight.ChangeSignalLamp(ListStatesController[currentStateNumber].TrafficLightRoadB);
            }
                
            foreach (var pedestrianTrafficlight in PedestrianTrafficlights)
                pedestrianTrafficlight.ChangeSignalLamp(ListStatesController[currentStateNumber].PedestrianTrafficlight);

            
            RunTimeState = ListStatesController[currentStateNumber].TimeWait;

            
            Console.WriteLine( " \n");

            
            //To start main thread
             AutoResetEventTimer.Set();

        }

        public void StartWork()
        {
            SwithMode();
                     
        }
        
    }
}