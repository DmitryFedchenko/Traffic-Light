using System.Collections.Generic;
using System;
using Traffic_Lights.Model.Constants;


namespace Traffic_Lights.Model.Models
{
    public interface ITrafficLight
    {
        int Id { get; set; }
        string Participan { get; }
         List<Lamp> Lamps { get; }
         event EventHandler ChangeTrafficLightSignal;
         void SwitchSignal(Dictionary<int, string> lampStates, int blinkPeriod);
         void ResetAllSignal();

    }
}