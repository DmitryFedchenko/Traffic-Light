
using System.Collections.Generic;


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
