using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using TrafficLightClassDiagram;

namespace TrafficLightClassDiagram
{
    public class PedestrianTrafficLight : TrafficLight
    {
        public override event EventHandler ChangeSignal;

        public override void SetSignal(Dictionary<SignalsType, bool> signals)
        {
            if (BlinkSignalTimer != null)
                BlinkSignalTimer.Dispose();


            Lamps[Lamp.GreenLamp] = signals[SignalsType.Green];           
            Lamps[Lamp.RedLamp] = signals[SignalsType.Red];

            if (signals[SignalsType.BlinkGreen])
                BlinkSignalTimer = new Timer(BlinkSignal, Lamp.GreenLamp, 0, 500);


         //   foreach (var item in signals.Where(x => x.Value == true))
           //     Console.WriteLine("                 {0}   {1}    {2}", Id, this.TrafficLightType, item.Key);

            if (ChangeSignal != null)
                ChangeSignal(this, EventArgs.Empty);

        }


        protected override void BlinkSignal(object obj)
        {
            if (Lamp.GreenLamp == (Lamp)obj)
                Lamps[Lamp.GreenLamp] = Lamps[Lamp.GreenLamp] ? false : true;

            if (ChangeSignal != null)
                ChangeSignal(this, EventArgs.Empty);

          //  Console.WriteLine("                                          Blink " + Id + " " + Lamp.GreenLamp);
        }

        public PedestrianTrafficLight(int id, string trafficlightType)
        {
            this.TrafficLightType = trafficlightType;
            Id = id;
            this.Lamps = new Dictionary<Lamp, bool> { };

            Lamps.Add(Lamp.GreenLamp, false);
            Lamps.Add(Lamp.RedLamp, false);
        }

    }
}