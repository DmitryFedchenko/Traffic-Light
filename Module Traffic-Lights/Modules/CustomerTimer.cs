using System;
using System.Timers;

namespace Traffic_Light.Modules
{
   public class CustomerTimer
    {
        public Timer timer;

        private static int i = 0;
      
        public void Wait(int interval)
        {
            timer.Interval = interval;

            timer.Start();
            while (i < 1)
            {

            }
            i = 0;
            timer.Stop();
         
        }

        public CustomerTimer()
        {
            
            timer = new Timer();
            timer.Elapsed += (Object source, ElapsedEventArgs e) => { ++i; };
            timer.AutoReset = true;
            timer.Enabled = true;
        }


    }
}
