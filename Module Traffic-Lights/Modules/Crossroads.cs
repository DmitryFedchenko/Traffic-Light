using System.Collections.Generic;
using Traffic_Light.Modules;


namespace Traffic_Light
{
   
    public delegate void EventHandler();
    public class Crossroads
    {
        private UserTimer timer;
        public event EventHandler RepresentCrossroadsSignal;
            
        //All traffic-lights on this crossroads
        public Dictionary<ParticipantTypes, List<TrafficLight>> TrafficLights { get; }

        private SignalTypes CurrentBlinkSignal { get; set; }
        public  void RepresentCrossroads()
        {
            if (RepresentCrossroadsSignal != null)
            {
                RepresentCrossroadsSignal.Invoke();
            }
        }


        
        public Crossroads()
        {
            timer = new UserTimer();

            TrafficLights = new Dictionary<ParticipantTypes, List<TrafficLight>>();
            TrafficLights.Add(ParticipantTypes.TrafficLightRoadA, new List<TrafficLight>());
            TrafficLights.Add(ParticipantTypes.TrafficLightRoadB, new List<TrafficLight>());
            TrafficLights.Add(ParticipantTypes.PedestrianTrafficLight, new List<TrafficLight>());
           
        }


        public void ChangeCurrentState(CrossroadsState crossroadsState)
        {
            bool blinkRoadA = SwithcSiganlTrafficLights(ParticipantTypes.TrafficLightRoadA, crossroadsState.SignalTrafficLightRoadA);
            bool blinkRoadB = SwithcSiganlTrafficLights(ParticipantTypes.TrafficLightRoadB, crossroadsState.SignalTrafficLightRoadB);
            bool blinkPedestrinTrafficLight = SwithcSiganlTrafficLights(ParticipantTypes.PedestrianTrafficLight,
                crossroadsState.SignalPedestrianTrafficLight);

            if (blinkPedestrinTrafficLight || blinkRoadA || blinkRoadB)
            {
                BlinkSignal(blinkRoadA, blinkRoadB, blinkPedestrinTrafficLight, crossroadsState.Time, crossroadsState.Period);
                return;
            }
           

           timer.Wait(crossroadsState.Time);
    
        }

        public void BlinkSignal(bool roadA, bool roadB, bool pedestrianTrafficLight, int time, int period)
        {
          
            for (int i = 0; i < period; i++)
            {
                if(roadA)
                    ResetSignal(ParticipantTypes.TrafficLightRoadA);
                if (roadB)
                    ResetSignal(ParticipantTypes.TrafficLightRoadB);
                if (pedestrianTrafficLight)
                    ResetSignal(ParticipantTypes.PedestrianTrafficLight);

                timer.Wait(time);

                if (roadA)
                    SetSiganl(ParticipantTypes.TrafficLightRoadA, CurrentBlinkSignal);
                if (roadB)
                    SetSiganl(ParticipantTypes.TrafficLightRoadB, CurrentBlinkSignal);
                if (pedestrianTrafficLight)
                    SetSiganl(ParticipantTypes.PedestrianTrafficLight, CurrentBlinkSignal);

                timer.Wait(time);

            }
        }


        public bool SwithcSiganlTrafficLights(ParticipantTypes participant, SignalTypes signal)
        {
            bool blink = false;
            switch (signal)
            {
                case SignalTypes.BlinkGreen:
                    signal = SignalTypes.Green;
                    CurrentBlinkSignal = signal;
                    blink = true;
                    break;

                case SignalTypes.BlinkYellow:
                    signal = SignalTypes.Yellow;
                    CurrentBlinkSignal = signal;
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
            RepresentCrossroads();
        }
  
        
        
        public void ResetSignal(ParticipantTypes participant)
        {
           SetSiganl(participant,SignalTypes.Black);
        }


        public void AddCarTrafficLight(ParticipantTypes participant, int lampTopX, int lampTopY, int lampMiddleX, int lampMiddleY, int lampBottomX, int lampBottomY)
        {
            var trLight = new CarTrafficLight(lampTopX, lampTopY, lampMiddleX, lampMiddleY, lampBottomX, lampBottomY);
            TrafficLights[participant].Add(trLight);

        }

        public void AddPedestrianTrafficLight(ParticipantTypes participant, int lampTopX, int lampTopY, int lampBottomX, int lampBottomY)
        {
            var trLight = new PedestrianTrafficLight(lampTopX, lampTopY, lampBottomX, lampBottomY);
            TrafficLights[participant].Add(trLight);

        }


    }
}