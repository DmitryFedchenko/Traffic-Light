using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Timers;
using Traffic_Light.Modules;
using Timer = System.Threading.Timer;


namespace Traffic_Light
{
   
    public delegate void DrowEventHandler();
    public class Crossroads
    {
        ParticipantTypes tempPaticipantBlink;
        CustomerTimer timer = new CustomerTimer();
        public event DrowEventHandler drawEvenet;
        public Dictionary<ParticipantTypes,List<TrafficLight>> TrafficLights = new Dictionary<ParticipantTypes, List<TrafficLight>>();
      
        public  void DrawTarfficLights()
        {
            if (drawEvenet != null)
            {
                drawEvenet.Invoke();
            }
        }


        
        public Crossroads()
        {
            TrafficLights.Add(ParticipantTypes.TrafficLightRoadA, new List<TrafficLight>());
            TrafficLights.Add(ParticipantTypes.TrafficLightRoadB, new List<TrafficLight>());
            TrafficLights.Add(ParticipantTypes.PedestrianTrafficLight, new List<TrafficLight>());
           
        }


        public void ChangeCurrentState(CrossroadsState crossroadsState)
        {
           if(SwithcSiganlTrafficLights(ParticipantTypes.TrafficLightRoadA, crossroadsState.SignalTrafficLightRoadA))
                BlinkSignal(ParticipantTypes.TrafficLightRoadA, crossroadsState.Time,crossroadsState.Period,crossroadsState.SignalTrafficLightRoadA);


            if(SwithcSiganlTrafficLights(ParticipantTypes.TrafficLightRoadA, crossroadsState.SignalTrafficLightRoadB))
                BlinkSignal(ParticipantTypes.TrafficLightRoadA, crossroadsState.Time, crossroadsState.Period, crossroadsState.SignalTrafficLightRoadA);

            if (SwithcSiganlTrafficLights(ParticipantTypes.PedestrianTrafficLight, crossroadsState.SignalPedestrianTrafficLight))
                BlinkSignal(ParticipantTypes.TrafficLightRoadA, crossroadsState.Time, crossroadsState.Period, crossroadsState.SignalTrafficLightRoadA);


       }

        public void BlinkSignal(ParticipantTypes participant, int time, int period, SignalTypes signal)
        {
            for (int i = 0; i < period; i++)
            {
                ResetSignal(tempPaticipantBlink);
                timer.CostomizeTimer(time, timer.Blink, 1);
                SetSiganl(participant, signal);
                timer.CostomizeTimer(time, timer.Blink, 1);

            }
        }


        public bool SwithcSiganlTrafficLights(ParticipantTypes participant, SignalTypes signal)
        {
            bool blink = false;
            switch (signal)
            {
                case SignalTypes.BlinkGreen:
                    blink = true;
                    break;

                case SignalTypes.BlinkYellow:
                    blink = true;
                    break;
            }
           
            ResetSignal(participant);
            SetSiganl(participant,signal);
            return blink;
        }

        public void SetSiganl(ParticipantTypes participant, SignalTypes signal)
        {
            foreach (var trafficLights in TrafficLights)
            {
                if (trafficLights.Key == participant)
                {
                    foreach (var trafficLight in trafficLights.Value)
                    {
                        trafficLight.SwitchSignal(signal);
                    }

                }

            }
            DrawTarfficLights();
        }
  

       

        
        public void ResetSignal(ParticipantTypes participant)
        {
           SetSiganl(participant,SignalTypes.Black);
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