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
        object obj = new object();

        public override Dictionary<LampType, bool> Lamps { get; set; }
        

        public override event EventHandler ChangeSignal;
       
        protected override void SetSignal(Dictionary<SignalsType, bool> signals) {
         
             
            Lamps[LampType.GreenLamp] = signals[SignalsType.Green];
                Lamps[LampType.YellowLamp] = signals[SignalsType.Yellow];
                Lamps[LampType.RedLamp] = signals[SignalsType.Red];

                if (signals[SignalsType.BlinkGreen] && BlinkSignalTimer == null)
                    BlinkSignalTimer = new Timer(BlinkSignal, LampType.GreenLamp, 0, 1000);

                if (signals[SignalsType.BlinkYellow] && BlinkSignalTimer == null)
                    BlinkSignalTimer = new Timer(BlinkSignal, LampType.YellowLamp, 0, 1000);
               if (ChangeSignal != null)
                    ChangeSignal(this, EventArgs.Empty);
            //foreach (var item in signals.Where(x => x.Value == true))
            //    Console.WriteLine("                 {0}   {1}    {2}", Id, this.TrafficLightType, item.Key);



        }

        protected override void BlinkSignal(object obj)
        {
            
            if (LampType.YellowLamp == (LampType)obj)
                Lamps[LampType.YellowLamp] = Lamps[LampType.YellowLamp] ? false : true;
               
         
            if (LampType.GreenLamp == (LampType)obj)           
                Lamps[LampType.GreenLamp] = Lamps[LampType.GreenLamp] ? false : true;
               
            
            if (ChangeSignal != null)
                ChangeSignal(this, EventArgs.Empty);
           // Console.WriteLine("          Blink " + Id +"   "+ (LampType)obj+ "   " + Lamps[(LampType)obj] );

        }

        public CarTrafficLight(int id, string trafficlightType)
        {
            this.TrafficLightType = trafficlightType;
            Id = id;
            this.Lamps = new Dictionary<LampType, bool> { };

            Lamps.Add(LampType.GreenLamp, false);
            Lamps.Add(LampType.YellowLamp, false);
            Lamps.Add(LampType.RedLamp, false);
        }

    }

    public enum LampType
    {
        GreenLamp = 1 , YellowLamp = 2, RedLamp = 0
    }
}


