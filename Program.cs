using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traffic_Light.Modules;

namespace Traffic_Light
{
    class Program
    {
       
        static void Main(string[] args)
        {
            AutomobileTrafficLight trafficLight = new AutomobileTrafficLight(19,9,19,10,19,11);
            Draw drawDesk = new Draw(trafficLight);
            drawDesk.CrossroadsWork();
            Console.ReadLine();

            /*AutomobileTrafficLight trafficLight = new AutomobileTrafficLight();
            trafficLight.Work(); */
        }
    }
}
