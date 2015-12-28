using System;
using System.Collections.Generic;
using System.Timers;
using Traffic_Lights.Model.Constants;
using Timer = System.Timers.Timer;

namespace Traffic_Lights.Model.Models
{
    public delegate void EventHandlerTrafficLight(TrafficLightModel e);

    public class TrafficLightModel
    {
        private object obj = new object();
        private SignalTypes blinkSignalTrafficLight = SignalTypes.Black;

        protected Timer timer;

        public volatile int Period;
        public int Time { get; set; }

        public SignalTypes currentSignal;
        public Dictionary<PositionTypes, int> posittionTrafficLight;
        public event EventHandlerTrafficLight RepresentCrossroadsSignal;
      
        


        public void RepresentCrossroads()
        {

            if (RepresentCrossroadsSignal != null)
            {
                RepresentCrossroadsSignal(this);
            }

        }




        public void BlinkSignal(Object source, ElapsedEventArgs e)
        {
            lock (obj)
            {
                if (blinkSignalTrafficLight == SignalTypes.Black)
                    blinkSignalTrafficLight = currentSignal;

                currentSignal = currentSignal == SignalTypes.Black ? blinkSignalTrafficLight : SignalTypes.Black;

                RepresentCrossroads();
            }

        }

        public void ResetTimer()
        {
            timer.Stop();
            timer.Dispose();
            blinkSignalTrafficLight = SignalTypes.Black;
        }

        public void SwitchSignal(SignalTypes signal)
        {

            if (timer != null)
               ResetTimer();

            switch (signal)
            {
                case SignalTypes.BlinkGreen:
                    currentSignal = SignalTypes.Green;
                    Blink();
                    break;

                case SignalTypes.BlinkYellow:
                    currentSignal = SignalTypes.Yellow;
                    Blink();
                    break;

                default:
                {
                  
                    currentSignal = signal;
                    RepresentCrossroads();
                    break;
                }
            }
        }

        protected void Blink()
        {
                timer = new Timer();
                timer.Elapsed += BlinkSignal;
                timer.Enabled = true;
                timer.AutoReset = true;
                timer.Interval = Period;
        }

      
        public TrafficLightModel(int lampTopX, int lampTopY, int lampBottomX, int lampBottomY)
        {
           posittionTrafficLight = new Dictionary<PositionTypes, int>();

            posittionTrafficLight.Add(PositionTypes.LampTopX, lampTopX);
            posittionTrafficLight.Add(PositionTypes.LampTopY, lampTopY);
            posittionTrafficLight.Add(PositionTypes.LampBottomX, lampBottomX);
            posittionTrafficLight.Add(PositionTypes.LampBottomY, lampBottomY);
        }


         public TrafficLightModel(int lampTopX, int lampTopY, int lampMiddleX, int lampMiddleY, int lampBottomX, int lampBottomY)
            :this(lampTopX, lampTopY,lampBottomX,lampBottomY)
        {
            posittionTrafficLight.Add(PositionTypes.MiddleX, lampMiddleX);
            posittionTrafficLight.Add(PositionTypes.MiddleY, lampMiddleY);
           
        }
    }
}