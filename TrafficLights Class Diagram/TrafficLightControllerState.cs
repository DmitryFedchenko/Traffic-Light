using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrafficLightClassDiagram
{
    public class TrafficLightControllerState
    {
        private SignalsType[] roadASignals;
        private SignalsType[] roadBSignals;
        private SignalsType[] pedestrianTrafficLightSignals;

        //public IEnumerator<SignalsType> TrafficLightRoadA { get; set; }
       

        //public IEnumerator<SignalsType> TrafficLightRoadB { get; set; }
        

        //public IEnumerator<SignalsType> PedestrianTrafficlight { get; set; }
        
        public int TimeWait { get; set; }
        //public TrafficLightControllerState(IEnumerator<bool> trafficLightRoadA, IEnumerator<bool> trafficLightRoadB, IEnumerator<bool> pedestrinaTrafficLight, int timeWait)
        //{
        //    TrafficLightRoadA = trafficLightRoadA;
        //    TrafficLightRoadB = trafficLightRoadB;
        //    this.PedestrianTrafficlight = pedestrinaTrafficLight;

        //}

        public TrafficLightControllerState(SignalsType[] roadASignals, SignalsType[] roadBSignals, SignalsType[] pedestrianTrafficLightSignals, int timeWait)
        {
            this.roadASignals = roadASignals;
            this.roadBSignals = roadBSignals;
            this.pedestrianTrafficLightSignals = pedestrianTrafficLightSignals;
            TimeWait = timeWait;
        }
    }

    public enum SignalsType
    {
        Red, Yellow, RedAndYellow, BlinkGreen, BlinkYellow       
    }

   
}