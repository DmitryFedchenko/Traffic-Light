using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Traffic_Light.Model
{

    public  class TrafficLightControllerStateTable
    {

        public Dictionary<TrafficLightModeType, List<TrafficLightControllerState>> ModesTable;
      
        public void InitModes() {

            ModesTable[TrafficLightModeType.DayTime].Add(new TrafficLightControllerState(LampState.Green, LampState.Red, LampState.Red, 3000));
            ModesTable[TrafficLightModeType.DayTime].Add(new TrafficLightControllerState(LampState.BlinkGreen, LampState.Red, LampState.Red, 2000));
            ModesTable[TrafficLightModeType.DayTime].Add(new TrafficLightControllerState(LampState.Yellow, LampState.RedAndYellow, LampState.Red, 1000));
            ModesTable[TrafficLightModeType.DayTime].Add(new TrafficLightControllerState(LampState.Red, LampState.Green, LampState.Red, 3000));
            ModesTable[TrafficLightModeType.DayTime].Add(new TrafficLightControllerState(LampState.Red, LampState.BlinkGreen, LampState.Red, 2000));
            ModesTable[TrafficLightModeType.DayTime].Add(new TrafficLightControllerState(LampState.Red, LampState.Yellow, LampState.Red, 1000));
            ModesTable[TrafficLightModeType.DayTime].Add(new TrafficLightControllerState(LampState.Red, LampState.Red, LampState.Green, 3000));
            ModesTable[TrafficLightModeType.DayTime].Add(new TrafficLightControllerState(LampState.Red, LampState.Red, LampState.BlinkGreen, 2000));
            ModesTable[TrafficLightModeType.DayTime].Add(new TrafficLightControllerState(LampState.RedAndYellow, LampState.Red, LampState.Red, 1000));


            ModesTable[TrafficLightModeType.Night].Add(new TrafficLightControllerState(LampState.BlinkYellow, LampState.BlinkYellow, LampState.Grey, 3000));


            ModesTable[TrafficLightModeType.Stop].Add(new TrafficLightControllerState(LampState.Grey, LampState.Grey, LampState.Grey, 3000));
        }

        public TrafficLightControllerStateTable()
        {
            ModesTable = new Dictionary<TrafficLightModeType, List<TrafficLightControllerState>>();
            ModesTable.Add(TrafficLightModeType.DayTime, new List<TrafficLightControllerState>());
            ModesTable.Add(TrafficLightModeType.Night, new List<TrafficLightControllerState>());
            ModesTable.Add(TrafficLightModeType.Stop, new List<TrafficLightControllerState>());
            
            InitModes();
        }

       
    }
}