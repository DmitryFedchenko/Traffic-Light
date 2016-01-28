using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Traffic_Light.Model
{

    public  class TrafficLightControllerStateTables
    {
        public List<TrafficLightControllerState> DayTimeMode { get; set; }
        public List<TrafficLightControllerState> NightTimeMode { get; set; }
        public List<TrafficLightControllerState> StopMode { get; set; }

        public void InitState() {
          
            this.DayTimeMode.Add(new TrafficLightControllerState(LampState.Green, LampState.Red, LampState.Red, 3000));
            this.DayTimeMode.Add(new TrafficLightControllerState(LampState.BlinkGreen, LampState.Red, LampState.Red, 2000));
            this.DayTimeMode.Add(new TrafficLightControllerState(LampState.Yellow, LampState.RedAndYellow, LampState.Red, 1000));
            this.DayTimeMode.Add(new TrafficLightControllerState(LampState.Red, LampState.Green, LampState.Red, 3000));
            this.DayTimeMode.Add(new TrafficLightControllerState(LampState.Red, LampState.BlinkGreen, LampState.Red, 2000));
            this.DayTimeMode.Add(new TrafficLightControllerState(LampState.Red, LampState.Yellow, LampState.Red, 1000));
            this.DayTimeMode.Add(new TrafficLightControllerState(LampState.Red, LampState.Red, LampState.Green, 3000));
            this.DayTimeMode.Add(new TrafficLightControllerState(LampState.Red, LampState.Red, LampState.BlinkGreen, 2000));
            this.DayTimeMode.Add(new TrafficLightControllerState(LampState.RedAndYellow, LampState.Red, LampState.Red, 1000));


            this.NightTimeMode.Add(new TrafficLightControllerState(LampState.BlinkYellow, LampState.BlinkYellow, LampState.Grey, 3000));


            this.StopMode.Add(new TrafficLightControllerState(LampState.Grey, LampState.Grey, LampState.Grey, 3000));
        }

        public TrafficLightControllerStateTables()
        {
         
            DayTimeMode = new List<TrafficLightControllerState>();
            NightTimeMode = new List<TrafficLightControllerState>();
            StopMode = new List<TrafficLightControllerState>();

            InitState();
        }

    }
  }