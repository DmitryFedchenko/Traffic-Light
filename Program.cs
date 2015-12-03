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
            AutomobileTrafficLight trafficLight1 = new AutomobileTrafficLight(19,9,19,10,19,11);
            AutomobileTrafficLight trafficLight2 = new AutomobileTrafficLight(40, 9, 40, 10, 40, 11);

            AutomobileTrafficLight trafficLight3 = new AutomobileTrafficLight(27, 7, 28, 7, 29, 7);
            AutomobileTrafficLight trafficLight4 = new AutomobileTrafficLight(27, 12, 27, 12, 29, 12);


            TrafficLightManager trafficLightManager = new TrafficLightManager();
            TrafficLightManager trafficLightManager2 = new TrafficLightManager();

            trafficLightManager.AddTrafficLiht(trafficLight1);
            trafficLightManager.AddTrafficLiht(trafficLight2);

            trafficLightManager2.AddTrafficLiht(trafficLight3);
            trafficLightManager2.AddTrafficLiht(trafficLight4);

            Draw drawDesk = new Draw();

            drawDesk.AddManager(trafficLightManager);
            drawDesk.AddManager(trafficLightManager2);



            drawDesk.CrossroadsWork();

            Console.ReadLine();
           
            /*AutomobileTrafficLight trafficLight = new AutomobileTrafficLight();
            trafficLight.Work(); */
        }
    }
}
