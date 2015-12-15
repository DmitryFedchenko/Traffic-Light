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


        SignalTypes[] signals = { SignalTypes.Red, SignalTypes.Green, SignalTypes.Black };

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
                    currentSignal = signals[2];
                    break;

                case SignalTypes.Red:
                    currentSignal = signals[0];
                    break;

                case SignalTypes.Green:
                    currentSignal = signals[1];
                    break;
            }

        }
    }
}