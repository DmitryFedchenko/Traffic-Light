using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using Traffic_Light.Modules;

namespace Traffic_Light
{
    public delegate void DrowEventHandler();
    public class Crossroads
    {
        
      
        public Dictionary<ParticipantTypes,List<TrafficLight>> TrafficLights = new Dictionary<ParticipantTypes, List<TrafficLight>>();

        public Crossroads()
        {
            TrafficLights.Add(ParticipantTypes.TrafficLightRoadA, new List<TrafficLight>());
            TrafficLights.Add(ParticipantTypes.TrafficLightRoadB, new List<TrafficLight>());
            TrafficLights.Add(ParticipantTypes.PedestrianTrafficLight, new List<TrafficLight>());
        }
      

        public void AddCarTrafficLight(ParticipantTypes participant, int lampTopX, int lampTopY, int lampMiddleX, int lampMiddleY, int lampBottomX, int lampBottomY)
        {
            var trLight = new CarTrLight(lampTopX, lampTopY, lampMiddleX, lampMiddleY, lampBottomX, lampBottomY);
            TrafficLights[participant].Add(trLight);
         
        }

        public void AddPedestrianTrafficLight(ParticipantTypes participant, int lampTopX, int lampTopY, int lampBottomX, int lampBottomY)
        {
            var trLight = new PedestrianTrafficLight(lampTopX, lampTopY, lampBottomX, lampBottomY);
            TrafficLights[participant].Add(trLight);

        }


       
        


    }
}