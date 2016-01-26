using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TrafficLightClassDiagram
{
    class Program
    {
        static void Main(string[] args)
        {
            TrafficLightController controller = new TrafficLightController();

            controller.AddTrafficlight(0, "RoadATrafficLight");
            controller.AddTrafficlight(1, "RoadBTrafficLight");
            controller.AddTrafficlight(2, "PedestrianTrafficLight");

            char n  = 's';
            controller.StartWork();
            while ( n != 'n') {
                 n = Console.ReadKey().KeyChar;
            }
            
        }
    }
}
