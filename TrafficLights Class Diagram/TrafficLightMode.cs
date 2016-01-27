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

        public void InitState() {
          
            this.DayTime.Add(new TrafficLightControllerState(SignalsType.Green, SignalsType.Red, SignalsType.Red, 3000));
            this.DayTime.Add(new TrafficLightControllerState(SignalsType.BlinkGreen, SignalsType.Red, SignalsType.Red, 2000));
            this.DayTime.Add(new TrafficLightControllerState(SignalsType.Yellow, SignalsType.RedAndYellow, SignalsType.Red, 1000));
            this.DayTime.Add(new TrafficLightControllerState(SignalsType.Red, SignalsType.Green, SignalsType.Red, 3000));
            this.DayTime.Add(new TrafficLightControllerState(SignalsType.Red, SignalsType.BlinkGreen, SignalsType.Red, 2000));
            this.DayTime.Add(new TrafficLightControllerState(SignalsType.Red, SignalsType.Yellow, SignalsType.Red, 1000));
            this.DayTime.Add(new TrafficLightControllerState(SignalsType.Red, SignalsType.Red, SignalsType.Green, 3000));
            this.DayTime.Add(new TrafficLightControllerState(SignalsType.Red, SignalsType.Red, SignalsType.BlinkGreen, 2000));
            this.DayTime.Add(new TrafficLightControllerState(SignalsType.RedAndYellow, SignalsType.Red, SignalsType.Red, 1000));


            this.NightTime.Add(new TrafficLightControllerState(SignalsType.BlinkYellow, SignalsType.BlinkYellow, SignalsType.Grey, 3000));


            this.Stop.Add(new TrafficLightControllerState(SignalsType.Grey, SignalsType.Grey, SignalsType.Grey, 3000));
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
        DayTime = 0, NightTime = 1, Stop = 2
    }
}