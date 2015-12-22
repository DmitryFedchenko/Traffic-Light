using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Traffic_Light.Modules;

namespace Traffic_Light
{
    public class PedestrianTrafficLight : TrafficLight
    {

        //Signals that can be in pedestrian traffic-lights
       private readonly SignalTypes[] _defaultSignals = { SignalTypes.Red, SignalTypes.Green, SignalTypes.Black };

       
        public PedestrianTrafficLight( int lampTopX, int lampTopY, int lampBottomX, int lampBottomY)
        {
            posittionTrLight = new Dictionary<PositionTypes, int>
            {
                {PositionTypes.LampTopX, lampTopX},
                {PositionTypes.LampTopY, lampTopY},
                {PositionTypes.LampBottomX, lampBottomX},
                {PositionTypes.LampBottomY, lampBottomY}
            };
        }

        public override void SwitchSignal(SignalTypes signal)
        {
            switch (signal)
            {
                case SignalTypes.Black:
                    currentSignal = _defaultSignals[2];
                    break;

                case SignalTypes.Red:
                    currentSignal = _defaultSignals[0];
                    break;

                case SignalTypes.Green:
                    currentSignal = _defaultSignals[1];
                    break;
            }

        }
    }
}