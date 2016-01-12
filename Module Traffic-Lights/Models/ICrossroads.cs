using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traffic_Light.Model;


namespace Traffic_Lights.Model.Models
{
    public interface ICrossroads
    {
        event EventHandler TrafficLightChange;
        void ChangeSelectedCrossroadsState(string state);
        void AddTrafficLight(string participan, int trafficLightId, int lampCount);
        string CrossroadsStateSelected { get; set; }
        ITrafficLight CurrentChangedTraffiLight { get; set; }
    }
}
