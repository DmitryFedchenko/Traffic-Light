using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrafficLightClassDiagram
{

    public abstract class ControllerMode
    {
        public List<TrafficLightControllerState> DayTime { get; set; }
        public List<TrafficLightControllerState> NightTime { get; set; }
        public List<TrafficLightControllerState> Stop { get; set; }

        public void AddState(ModeType type, bool[] roadASignals, bool[] roadBSignals, bool[] pedestrianTrafficLightSignals, int timeWait)
        {
            switch (type)
            {
                case ModeType.DayTime:
                    DayTime.Add(new TrafficLightControllerState(roadASignals, roadBSignals, pedestrianTrafficLightSignals, timeWait));
                    break;
                case ModeType.NightTime:

                    break;
                case ModeType.Stop:
                    break;
                default:
                    break;
            }

        }
        public ControllerMode()
        {
            
            DayTime = new List<TrafficLightControllerState>();
            NightTime = new List<TrafficLightControllerState>();
            Stop = new List<TrafficLightControllerState>();

        }

    }
    public enum ModeType {
        DayTime, NightTime, Stop
    }
}