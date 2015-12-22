using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traffic_Light.Modules
{
  public  class DayTimeMode
    {
      public List<CrossroadsState> states;

        public void AddState()
        {
            states.Add(new CrossroadsState(SignalTypes.Green, SignalTypes.Red, SignalTypes.Red, 3000));

            states.Add(new CrossroadsState(SignalTypes.BlinkGreen, SignalTypes.Red, SignalTypes.Red, 500,2));

            states.Add(new CrossroadsState(SignalTypes.Yellow, SignalTypes.RedAndYellow, SignalTypes.Red, 1000));

            states.Add(new CrossroadsState(SignalTypes.Red, SignalTypes.Green, SignalTypes.Red, 3000));

            states.Add(new CrossroadsState(SignalTypes.Red, SignalTypes.BlinkGreen, SignalTypes.Red, 500,2));

            states.Add(new CrossroadsState(SignalTypes.Red, SignalTypes.Yellow, SignalTypes.Red, 1000));

            states.Add(new CrossroadsState(SignalTypes.Red, SignalTypes.Red, SignalTypes.Green, 3000));

            states.Add(new CrossroadsState(SignalTypes.Red, SignalTypes.Red, SignalTypes.BlinkGreen, 500,2));

            states.Add(new CrossroadsState(SignalTypes.RedAndYellow, SignalTypes.Red, SignalTypes.Red, 2000));
        }
        public DayTimeMode()
        {
            states = new List<CrossroadsState>();
            AddState();
        }
    }
}
