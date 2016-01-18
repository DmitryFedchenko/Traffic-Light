using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrafficLights;

namespace TrafficLightClassDiagram
{
    public class DayTimeMode : ControllerMode
    {
        public DayTimeMode()
        {
            this.States.Add(new TrafficLightControllerState("Green","Red","Red",3000));
            this.States.Add(new TrafficLightControllerState("BlinkGreen", "Red", "Red", 2000));
            this.States.Add(new TrafficLightControllerState("Yellow", "RedAndellow", "Red", 1000));
            this.States.Add(new TrafficLightControllerState("Red", "Green", "Red", 3000));
            this.States.Add(new TrafficLightControllerState("Red", "BlinkGreen", "Red", 2000));
            this.States.Add(new TrafficLightControllerState("Red", "Yellow", "Red", 1000));
            this.States.Add(new TrafficLightControllerState("Red", "Red", "Green", 3000));
            this.States.Add(new TrafficLightControllerState("Red", "Red", "BlinkGreen", 2000));
            this.States.Add(new TrafficLightControllerState("RedAndYellow", "Red", "Red", 1000));


        }


        /*
             states.Add(new CrossroadsState(SignalTypes.Green, SignalTypes.Red, SignalTypes.Red, 3000));
 +
 +            states.Add(new CrossroadsState(SignalTypes.BlinkGreen, SignalTypes.Red, SignalTypes.Red, 2000));
 +
 +            states.Add(new CrossroadsState(SignalTypes.Yellow, SignalTypes.RedAndYellow, SignalTypes.Red, 1000));
 +
 +            states.Add(new CrossroadsState(SignalTypes.Red, SignalTypes.Green, SignalTypes.Red, 3000));
 +
 +            states.Add(new CrossroadsState(SignalTypes.Red, SignalTypes.BlinkGreen, SignalTypes.Red, 2000));
 +
 +            states.Add(new CrossroadsState(SignalTypes.Red, SignalTypes.Yellow, SignalTypes.Red, 1000));
 +
 +            states.Add(new CrossroadsState(SignalTypes.Red, SignalTypes.Red, SignalTypes.Green, 3000));
 +
 +            states.Add(new CrossroadsState(SignalTypes.Red, SignalTypes.Red, SignalTypes.BlinkGreen, 2000));
 +
 +            states.Add(new CrossroadsState(SignalTypes.RedAndYellow, SignalTypes.Red, SignalTypes.Red, 1000));
        */
    }
}