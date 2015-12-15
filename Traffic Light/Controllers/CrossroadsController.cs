using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using Traffic_Light.Modules;

namespace Traffic_Light
{
    public class CrossroadsController
    {
        public event DrowEventHandler drawEvenet;
        public CrossroadsMode Mode { get; set; }
        protected Crossroads crossroads;
       
        
        public CrossroadsController(Crossroads crossroads)
        {
            this.crossroads = crossroads;
            Mode = new CrossroadsMode(this);
            
        }


      
        public void SetCrossroadsState(CrossroadsState crossroadsState)
        {
          
            bool blinkSignalRoadA = SwithSignal(ParticipantTypes.TrafficLightRoadA, crossroadsState.TrafficLigthRoadA);
            bool blinkSignalRoadB = SwithSignal(ParticipantTypes.TrafficLightRoadB, crossroadsState.TrafficLightRoadB);
            bool blinkSignalPedestrianTrafficLight = SwithSignal(ParticipantTypes.PedestrianTrafficLight, crossroadsState.PedestrianTrafficLight);

            if (blinkSignalPedestrianTrafficLight || blinkSignalRoadA || blinkSignalPedestrianTrafficLight)
            {
                BlinkSignalTrafficLight(blinkSignalRoadA, blinkSignalRoadB, blinkSignalPedestrianTrafficLight, 3, 500);
                return;
            }
       
            Thread.Sleep(crossroadsState.Time);
        }


         public void DrawTarfficLights()
        {
            if (drawEvenet != null)
            {
                drawEvenet.Invoke();
            }
        }

       

        public bool SwithSignal(ParticipantTypes participant, SignalTypes signal)
        {
            
            bool blink = false;
            switch (signal)
            {
                case SignalTypes.BlinkGreen:
                    signal = SignalTypes.Green;
                    blink = true;
                    break;

                case SignalTypes.BlinkYellow:
                    signal = SignalTypes.Yellow;
                    blink = true;
                    break;
            }

            SetSiganlTrafficLight(participant, signal);
            
            return blink;

        }

        public void SetSiganlTrafficLight(ParticipantTypes participant, SignalTypes signal)
        {
            ResetSignal(participant);
            foreach (var trafficLights in crossroads.TrafficLights)
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

        public void BlinkSignalTrafficLight(bool roadA,bool roadB, bool pedestriantrafficlight, int quantity, int period)
        {
            SignalTypes tempSignalRoadA = crossroads.TrafficLights[ParticipantTypes.TrafficLightRoadA][1].currentSignal;
            SignalTypes tempSignalRoadB = crossroads.TrafficLights[ParticipantTypes.TrafficLightRoadB][1].currentSignal;
            SignalTypes tempSignalPedestrian= crossroads.TrafficLights[ParticipantTypes.PedestrianTrafficLight][1].currentSignal;

            for (int i = 0; i < quantity; i++)
            {

                Thread.Sleep(period);
                if (roadA)
                    SetSiganlTrafficLight(ParticipantTypes.TrafficLightRoadA, tempSignalRoadA);
                if (roadB)
                    SetSiganlTrafficLight(ParticipantTypes.TrafficLightRoadB, tempSignalRoadB);
                if (pedestriantrafficlight)
                    SetSiganlTrafficLight(ParticipantTypes.PedestrianTrafficLight, tempSignalPedestrian);
              

                Thread.Sleep(period);
                if (roadA)
                    ResetSignal(ParticipantTypes.TrafficLightRoadA);
                if (roadB)
                    ResetSignal(ParticipantTypes.TrafficLightRoadB);
                if (pedestriantrafficlight)
                    ResetSignal(ParticipantTypes.PedestrianTrafficLight);

              
            }
       }

        public void ResetSignal(ParticipantTypes participant)
        {
            foreach (var trafficLights in crossroads.TrafficLights)
            {

                if (trafficLights.Key == participant)
                {
                    foreach (var trafficLight in trafficLights.Value)
                    {
                        trafficLight.SwitchSignal(SignalTypes.Black);
                    }

                }
            }
            DrawTarfficLights();
        }
        
    }
}
