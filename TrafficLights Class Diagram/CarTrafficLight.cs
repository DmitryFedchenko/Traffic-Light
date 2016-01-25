using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TrafficLightClassDiagram;

namespace TrafficLightClassDiagram
{
    public class CarTrafficLight : TrafficLight
    {
        public override event EventHandler ChangeSignal;

        public override void SetSignal(Dictionary<SignalsType,bool> signals)
        {
            if (BlinkSignalTimer != null)
                BlinkSignalTimer.Dispose();

    
            Lamps[Lamp.GreenLamp] = signals[SignalsType.Green];
            Lamps[Lamp.YellowLamp] = signals[SignalsType.Yellow];
            Lamps[Lamp.RedLamp] = signals[SignalsType.Red];

            if(signals[SignalsType.BlinkGreen])
                BlinkSignalTimer = new Timer(BlinkSignal, Lamp.GreenLamp, 0, 500);

            if (signals[SignalsType.BlinkYellow])
                BlinkSignalTimer = new Timer(BlinkSignal, Lamp.YellowLamp, 0, 500);

            foreach (var item in signals.Where(x => x.Value == true))
                Console.WriteLine("{0}   {1}    {2}" , Id,this.TrafficLightType,item.Key);

            if (ChangeSignal != null)
                ChangeSignal(this, EventArgs.Empty);

        }


        protected override void BlinkSignal(object obj)
        {
            if (Lamp.YellowLamp == (Lamp)obj)
            {
                Lamps[Lamp.YellowLamp] = Lamps[Lamp.YellowLamp] ? false : true;
                Console.WriteLine("Blink " + Id +   "    Yellow") ;
            }
            if (Lamp.GreenLamp == (Lamp)obj)
            {
                Lamps[Lamp.GreenLamp] = Lamps[Lamp.GreenLamp] ? false : true;
                Console.WriteLine("Blink " + Id + "    Green!");
            }
            if (ChangeSignal != null)
                ChangeSignal(this, EventArgs.Empty);

           
        }

        public CarTrafficLight(int id, string trafficlightType)
        {
            this.TrafficLightType = trafficlightType;
            Id = id;
            this.Lamps = new Dictionary<Lamp, bool> { };

            Lamps.Add(Lamp.GreenLamp, false);
            Lamps.Add(Lamp.YellowLamp, false);
            Lamps.Add(Lamp.RedLamp, false);
        }

    }

    public enum Lamp
    {
        GreenLamp, YellowLamp, RedLamp
    }
}


