using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traffic_Light.Modules
{
   public class StopMode 
    {
      
       public List<CrossroadsState> states;

       public StopMode()
       {
           states = new List<CrossroadsState>()
           {
               new CrossroadsState(SignalTypes.Black, SignalTypes.Black, SignalTypes.Black, 0)
           };

        }
    }
}
