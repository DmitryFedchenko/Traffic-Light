using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traffic_Lights.Model.Constants;
using Traffic_Lights.Model.Models;

namespace Module_Traffic_Lights.Models
{
    public class TrafficLightState
    {
      
        public int BlinkPeriod { get; set;}
        public string Participan { get; set; }
        public Dictionary<int, string> lampSignals;
           
      
        public TrafficLightState()
        {
            lampSignals = new Dictionary<int, string>();

        }
        
    }
}
