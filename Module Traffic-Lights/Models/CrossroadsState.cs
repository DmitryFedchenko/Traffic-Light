using Module_Traffic_Lights.Models;
using System.Collections.Generic;


namespace Traffic_Lights.Model.Models
{
  public  class CrossroadsState
    {
       public int Id { get; set; }

        public List<TrafficLightState> trafficLightStates;
        public void AddtrafficLightState( TrafficLightState trLightState)
        {
            trafficLightStates.Add(trLightState);
        }

        public int TimeWait { get; set; }
       
        public CrossroadsState()
        {
            trafficLightStates = new List< TrafficLightState > ();            
        }

        
    }

    
}
