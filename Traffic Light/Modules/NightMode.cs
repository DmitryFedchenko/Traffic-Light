using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traffic_Light.Modules
{
   public class NightMode
    {
       public List<CrossroadsState> states;
        public void AddState()
        {
            states.Add(new CrossroadsState(SignalTypes.BlinkYellow, SignalTypes.BlinkYellow, SignalTypes.Black, 0));
        }
        public NightMode()
       {
           states= new List<CrossroadsState>();
            AddState();
       }
    }
}
