using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Traffic_Light.Model
{

    public  class ControllerMode
    {
        public List<TrafficLightControllerState> DayTime { get; set; }
        public List<TrafficLightControllerState> NightTime { get; set; }
        public List<TrafficLightControllerState> Stop { get; set; }

        public void InitState() {
          
            this.DayTime.Add(new TrafficLightControllerState(SignalType.Green, SignalType.Red, SignalType.Red, 3000));
            this.DayTime.Add(new TrafficLightControllerState(SignalType.BlinkGreen, SignalType.Red, SignalType.Red, 2000));
            this.DayTime.Add(new TrafficLightControllerState(SignalType.Yellow, SignalType.RedAndYellow, SignalType.Red, 1000));
            this.DayTime.Add(new TrafficLightControllerState(SignalType.Red, SignalType.Green, SignalType.Red, 3000));
            this.DayTime.Add(new TrafficLightControllerState(SignalType.Red, SignalType.BlinkGreen, SignalType.Red, 2000));
            this.DayTime.Add(new TrafficLightControllerState(SignalType.Red, SignalType.Yellow, SignalType.Red, 1000));
            this.DayTime.Add(new TrafficLightControllerState(SignalType.Red, SignalType.Red, SignalType.Green, 3000));
            this.DayTime.Add(new TrafficLightControllerState(SignalType.Red, SignalType.Red, SignalType.BlinkGreen, 2000));
            this.DayTime.Add(new TrafficLightControllerState(SignalType.RedAndYellow, SignalType.Red, SignalType.Red, 1000));


            this.NightTime.Add(new TrafficLightControllerState(SignalType.BlinkYellow, SignalType.BlinkYellow, SignalType.Grey, 3000));


            this.Stop.Add(new TrafficLightControllerState(SignalType.Grey, SignalType.Grey, SignalType.Grey, 3000));
        }

        public ControllerMode()
        {
         
            DayTime = new List<TrafficLightControllerState>();
            NightTime = new List<TrafficLightControllerState>();
            Stop = new List<TrafficLightControllerState>();

            InitState();
        }

    }
  }