using System;
using System.Collections.Generic;
using System.Drawing;
using Traffic_Light.Model;
using Traffic_Lights__WindowsForms.Properties;

namespace Traffic_Lights__WindowsForms
{
   public abstract class TrafficLightView
    {
        public TrafficLightType TrafficLightType { get; set; }
        protected Image[] images;
        public Image CurrentImage; 
        public int X { get; set; }
        public int Y { get; set; }
        public virtual void ChangeSignal(bool redLamp, bool yellowLamp, bool greeenLamp){}
        public virtual void ChangeSignal(bool redLamp, bool greeenLamp){}

    }

}
