using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Timers;
using Traffic_Light.Modules;

namespace Traffic_Light
{
    public class CrossroadsController
    {
       


        public CrossroadsMode Mode { get; set; }
        protected Crossroads crossroads;
       
        
        public CrossroadsController(Crossroads crossroads)
        {
            this.crossroads = crossroads;
            Mode = new CrossroadsMode(this);
            
        }

       



        public void SetCrossroadsState(CrossroadsState crossroadsState)
        {

          crossroads.ChangeCurrentState(crossroadsState);
        
             
        }

 
    }
}
