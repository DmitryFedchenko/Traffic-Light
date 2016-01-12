using System;
using System.Collections.Generic;
using System.Timers;

using Timer = System.Timers.Timer;

namespace Traffic_Lights.Model.Models
{
    

    public class TrafficLightModel : ITrafficLight
    {
       
        public int Id { get; set; }
        public List<Lamp> Lamps { get;}
        private List<int> BlinkIdLamps;
         

        private Timer timer;
        public string Participan { get;}

        public event EventHandler ChangeTrafficLightSignal;
        public  int BlinkPeriod { get; set; }
        
        public TrafficLightModel(string participan, int id, int lampCount)
        {
            BlinkIdLamps = new List<int>();
            Lamps = new List<Lamp>();
            Id = id;
            Participan = participan;
            AddLamps(lampCount);
        }

        
        private void BlinkSignal(Object source, ElapsedEventArgs e)
        {
             
                for (int i = 0; i < BlinkIdLamps.Count; i++)
                {
                       Lamps[BlinkIdLamps[i]].Light = Lamps[BlinkIdLamps[i]].Light == false ? true : false;
                }
                     

                 if (ChangeTrafficLightSignal != null)
                    ChangeTrafficLightSignal(this, EventArgs.Empty);
             
        }

        public void AddLamps(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Lamps.Add(new Lamp(i));
            }
        }

        private void ResetTimer()
        {
            BlinkIdLamps.Clear();
            timer.Stop();
            timer.Dispose();
            
        }
        
        public void SwitchSignal(Dictionary<int, string> lampStates, int blinkPeriod)
        {
            if (timer != null)
               ResetTimer();
                             

            if (Lamps.Count > lampStates.Count)
                  foreach (var tempLamp in lampStates)
                {
                    Lamps[tempLamp.Key].Signal = tempLamp.Value;
                    Lamps[tempLamp.Key].Light = true;
                }
                   
            

            if (blinkPeriod > 0)
            {
                for (int i = 0; i < Lamps.Count; i++)
                    if (Lamps[i].Light)
                        BlinkIdLamps.Add(Lamps[i].Id);

                BlinkPeriod = blinkPeriod;
                Blink();
            }
            else 
            if (ChangeTrafficLightSignal != null)
                ChangeTrafficLightSignal(this, EventArgs.Empty);
        }

        public void ResetAllSignal()
        {
            foreach (var lamp in Lamps)
                   lamp.Light = false;
            
        }

        protected void Blink()
        {
                timer = new Timer();
                timer.Elapsed += BlinkSignal;
                timer.Enabled = true;
                timer.AutoReset = true;
                timer.Interval = BlinkPeriod;
               
        }

     
    }

 
   
}