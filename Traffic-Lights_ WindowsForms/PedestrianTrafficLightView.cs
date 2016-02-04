using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Traffic_Lights__WindowsForms.Properties;

namespace Traffic_Lights__WindowsForms
{
    class PedestrianTrafficLightView : TrafficLightView
    {
        public override void ChangeSignal(bool redLamp, bool greeenLamp)
        {
            if (redLamp)
                CurrentImage = images[1];

            if (greeenLamp)
                CurrentImage = images[0];
        }
        public PedestrianTrafficLightView()
        {
            this.images = new Image[] {
                Resources.PedestrianTrafficLightGreenSignal,
                Resources.PedestrianTrafficLightRedSignal
            };
        }
    }
}