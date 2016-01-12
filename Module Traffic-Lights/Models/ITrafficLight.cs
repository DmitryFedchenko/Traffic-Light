using System.Collections.Generic;
using System;



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