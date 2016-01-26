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
        object obj = new object();
        public override event EventHandler ChangeSignal;
        public override Dictionary<LampType, bool> Lamps { get; set; }

        protected override void SetSignal(Dictionary<SignalsType, bool> signals)
        { 
            if (BlinkSignalTimer != null)
                BlinkSignalTimer.Dispose();
            
            Lamps[LampType.GreenLamp] = signals[SignalsType.Green];           
            Lamps[LampType.RedLamp] = signals[SignalsType.Red];

            if (signals[SignalsType.BlinkGreen])
                BlinkSignalTimer = new Timer(BlinkSignal, LampType.GreenLamp, 0, 1000);

                           
                if (ChangeSignal != null)
                    ChangeSignal(this, EventArgs.Empty);

            //foreach (var item in signals.Where(x => x.Value == true))
            //        Console.WriteLine("               {0}   {1}    {2}", Id, this.TrafficLightType, item.Key);

        }


        protected override void BlinkSignal(object obj)
        {
            if (LampType.GreenLamp == (LampType)obj)
                Lamps[LampType.GreenLamp] = Lamps[LampType.GreenLamp] ? false : true;

            if (ChangeSignal != null)
                ChangeSignal(this, EventArgs.Empty);

      //      Console.WriteLine("                                  Blink " + Id + " " + Lamps[LampType.GreenLamp]);
        }

        public PedestrianTrafficLight(int id, string trafficlightType)
        {
            this.TrafficLightType = trafficlightType;
            Id = id;
            this.Lamps = new Dictionary<LampType, bool> { };

            Lamps.Add(LampType.GreenLamp, false);
            Lamps.Add(LampType.RedLamp, false);
        }

    }
}