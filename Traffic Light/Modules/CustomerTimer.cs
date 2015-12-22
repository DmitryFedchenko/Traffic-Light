using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Traffic_Light.Modules
{
   public class CustomerTimer
    {
        public System.Timers.Timer aTimer;

        private static int k = 0;
        private static int p = 10;


        public void CostomizeTimer(int interval, ElapsedEventHandler functon, int count)
        {
            aTimer.Interval = interval;
            aTimer.Elapsed += functon;
            aTimer.Start();
            p = count;
            while (k < p)
            {

            }
            k = 0;
            aTimer.Stop();
            aTimer.Elapsed -= functon;

        }




        public void Blink(object sender, ElapsedEventArgs e)
        {


        }

        public CustomerTimer()
        {
            // Create a timer with a two second interval.
            aTimer = new System.Timers.Timer(1000);
            // Hook up the Elapsed event for the timer. 

            aTimer.Elapsed += (Object source, ElapsedEventArgs e) => { ++k; };
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }


    }
}
