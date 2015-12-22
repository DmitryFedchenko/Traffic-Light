using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Traffic_Light.Modules;

namespace Traffic_Light
{
    public class CarTrafficLight : TrafficLight
    {
        //Signals that can be in car traffic-lights
        readonly SignalTypes[] defaultSignals = { SignalTypes.Red,SignalTypes.RedAndYellow, SignalTypes.Yellow,  SignalTypes.Green, SignalTypes.Black };

        public CarTrafficLight(int lampTopX, int lampTopY, int lampMiddleX, int lampMiddleY, int lampBottomX, int lampBottomY)
        {
           posittionTrLight = new Dictionary<PositionTypes, int>();
            posittionTrLight.Add(PositionTypes.LampTopX, lampTopX);
            posittionTrLight.Add(PositionTypes.LampTopY, lampTopY);
            posittionTrLight.Add(PositionTypes.MiddleX, lampMiddleX);
            posittionTrLight.Add(PositionTypes.MiddleY, lampMiddleY);
            posittionTrLight.Add(PositionTypes.LampBottomX, lampBottomX);
            posittionTrLight.Add(PositionTypes.LampBottomY, lampBottomY);
        }

        public override void SwitchSignal(SignalTypes signal)
        {
            switch (signal)
            {
                case SignalTypes.Black:
                    currentSignal = defaultSignals[4];
                    break;

                case SignalTypes.Red:
                    currentSignal = defaultSignals[0];
                    break;

                case SignalTypes.Green:
                    currentSignal = defaultSignals[3];
                    break;

                case SignalTypes.Yellow:
                    currentSignal = defaultSignals[2];
                    break;

                case SignalTypes.RedAndYellow:
                    currentSignal = defaultSignals[1];
                    break;
            }
        }
    }
}