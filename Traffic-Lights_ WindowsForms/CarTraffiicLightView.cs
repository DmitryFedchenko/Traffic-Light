using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traffic_Lights__WindowsForms.Properties;

namespace Traffic_Lights__WindowsForms
{
    class CarTraffiicLightView: TrafficLightView
    {

        public override void ChangeSignal(bool redLamp, bool yellowLamp, bool greeenLamp)
        {
            if (redLamp)
                CurrentImage = images[0];

            if (yellowLamp)
                CurrentImage = images[2];

            if (redLamp && yellowLamp) ;
                CurrentImage = images[3];

            if (greeenLamp)
                CurrentImage = images[1];

        }
        public CarTraffiicLightView()
        {
            CurrentImage = Resources.CarTrafficLightRedSignal;

            images = new Image[] {
                Resources.CarTrafficLightRedSignal,
                Resources.CarTrafficLightGreenSignal,
                Resources.CarTrafficLightYellowSignal,
                Resources.CarTrafficLightRedAndYellowSignal
            };
        }
    }
}
