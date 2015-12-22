using System;
using System.Timers;

namespace Traffic_Light.Modules
{
   public class UserTimer
    {
        public Timer timer;

        private static int i = 0;
      
        public void Wait(int interval)
        {
            interval = interval > 0 ? interval : 1;
            timer.Interval = interval;
            timer.Start();
            while (i < 1)
            {

            }
            i = 0;
            timer.Stop();
         
        }

        public UserTimer()
        {
            
            timer = new Timer();
            timer.Elapsed += (Object source, ElapsedEventArgs e) => { ++i; };
            timer.AutoReset = true;
            timer.Enabled = true;
        }


    }
}
