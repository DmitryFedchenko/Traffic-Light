using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traffic_Light.Modules
{
   public class StopMode : Mode
    {
      
       public List<CrossroadsState> states;
        public void AddState()
        {
            states.Add(new CrossroadsState(SignalTypes.Black, SignalTypes.Black, SignalTypes.Black, 0));
        }

        public StopMode( )
        {
            
            states = new List<CrossroadsState>();
            AddState();
        }
    }
}
