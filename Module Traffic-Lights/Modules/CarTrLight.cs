using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Traffic_Light.Modules;

namespace Traffic_Light
{
    public class CarTrLight : TrafficLight
    {
        SignalTypes[] signals = { SignalTypes.Red,SignalTypes.RedAndYellow, SignalTypes.Yellow,  SignalTypes.Green, SignalTypes.Black };

        public CarTrLight(int lampTopX, int lampTopY, int lampMiddleX, int lampMiddleY, int lampBottomX, int lampBottomY)
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
                    currentSignal = signals[4];
                    break;

                case SignalTypes.Red:
                    currentSignal = signals[0];
                    break;

                case SignalTypes.Green:
                    currentSignal = signals[3];
                    break;

                case SignalTypes.Yellow:
                    currentSignal = signals[2];
                    break;

                case SignalTypes.RedAndYellow:
                    currentSignal = signals[1];
                    break;
            }
        }
    }
}