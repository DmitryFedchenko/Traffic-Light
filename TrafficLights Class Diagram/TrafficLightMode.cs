using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrafficLightClassDiagram
{

    public  class ControllerMode
    {
      
        public List<TrafficLightControllerState> DayTime { get; set; }
        public List<TrafficLightControllerState> NightTime { get; set; }
        public List<TrafficLightControllerState> Stop { get; set; }

        public void AddStateDayTime(SignalsType roadATrafficLight, SignalsType roadBTrafficLight, SignalsType pedestrainTrafficLight, int timeWait)
        {
            Dictionary<SignalsType, bool> roadA = addSomeSignals();
            Dictionary<SignalsType, bool> roadB = addSomeSignals();
            Dictionary<SignalsType, bool> pedestrian = addSomeSignals();


            if (roadA.ContainsKey(roadATrafficLight))
                roadA[roadATrafficLight] = true;

            if (roadA.ContainsKey(roadBTrafficLight))
                roadB[roadBTrafficLight] = true;

            if (roadA.ContainsKey(pedestrainTrafficLight))
                pedestrian[pedestrainTrafficLight] = true;

            DayTime.Add( new TrafficLightControllerState(roadA, roadB, pedestrian, timeWait));

        }

        public Dictionary<SignalsType, bool> addSomeSignals() {

            Dictionary<SignalsType, bool> siganlStates = new Dictionary<SignalsType, bool>();
            siganlStates.Add(SignalsType.BlinkGreen, false);
            siganlStates.Add(SignalsType.Green, false);
            siganlStates.Add(SignalsType.Yellow, false);
            siganlStates.Add(SignalsType.BlinkYellow, false);
            siganlStates.Add(SignalsType.RedAndYellow, false);
            siganlStates.Add(SignalsType.Red, false);


            return siganlStates;
        }

        public void AddStateNightTime(SignalsType roadATrafficLight, SignalsType roadBTrafficLight, SignalsType pedestrainTrafficLight, int timeWait)
        {
            Dictionary<SignalsType, bool> roadA = addSomeSignals();
            Dictionary<SignalsType, bool> roadB = addSomeSignals();
            Dictionary<SignalsType, bool> pedestrian = addSomeSignals();

            if (roadA.ContainsKey(roadATrafficLight))
                roadA[roadATrafficLight] = true;

            if (roadB.ContainsKey(roadBTrafficLight))
                roadB[roadBTrafficLight] = true;

            if (pedestrian.ContainsKey(pedestrainTrafficLight))
                pedestrian[pedestrainTrafficLight] = true;

            NightTime.Add(new TrafficLightControllerState(roadA, roadB, pedestrian, timeWait));

        }
        public void AddStateStop(SignalsType roadATrafficLight, SignalsType roadBTrafficLight, SignalsType pedestrainTrafficLight, int timeWait)
        {
            Dictionary<SignalsType, bool> roadA = addSomeSignals();
            Dictionary<SignalsType, bool> roadB = addSomeSignals();
            Dictionary<SignalsType, bool> pedestrian = addSomeSignals();

            if (roadA.ContainsKey(roadATrafficLight))
                roadA[roadATrafficLight] = true;

            if (roadB.ContainsKey(roadBTrafficLight))
                roadB[roadBTrafficLight] = true;

            if (pedestrian.ContainsKey(pedestrainTrafficLight))
                pedestrian[pedestrainTrafficLight] = true;

            Stop.Add(new TrafficLightControllerState(roadA, roadB, pedestrian, timeWait));

        }


        public void InitState() {

            AddStateDayTime(SignalsType.Green, SignalsType.Red, SignalsType.Red,3000);
            AddStateDayTime(SignalsType.BlinkGreen, SignalsType.Red, SignalsType.Red, 2000);
            AddStateDayTime(SignalsType.Yellow, SignalsType.RedAndYellow, SignalsType.Red, 1000);
            AddStateDayTime(SignalsType.Red, SignalsType.Green, SignalsType.Red, 3000);
            AddStateDayTime(SignalsType.Red, SignalsType.BlinkGreen, SignalsType.Red, 2000);
            AddStateDayTime(SignalsType.Red, SignalsType.Yellow, SignalsType.Red, 1000);
            AddStateDayTime(SignalsType.Red, SignalsType.Red, SignalsType.Green, 3000);
            AddStateDayTime(SignalsType.Red, SignalsType.Red, SignalsType.BlinkGreen, 2000);
            AddStateDayTime(SignalsType.RedAndYellow, SignalsType.Red, SignalsType.Red, 1000);

        

        }

        public ControllerMode()
        {

             
         
            DayTime = new List<TrafficLightControllerState>();
            NightTime = new List<TrafficLightControllerState>();
            Stop = new List<TrafficLightControllerState>();

            InitState();
        }

    }
    public enum ModeType {
        DayTime, NightTime, Stop
    }
}