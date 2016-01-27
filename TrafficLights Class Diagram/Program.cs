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

            CarTrafficLight RoadATrafficLight =new CarTrafficLight(0, "RoadATrafficLight");
            CarTrafficLight RoadBTrafficLight = new CarTrafficLight(0, "RoadBTrafficLight");
            PedestrianTrafficLight PedestrianTrafficLight = new PedestrianTrafficLight(0, "PedestrianTrafficLight");

            controller.AddTrafficlight(RoadATrafficLight);
            controller.AddTrafficlight(RoadBTrafficLight);
            controller.AddTrafficlight(PedestrianTrafficLight);

            controller.StartWork();
            
            controller.StartWork();

            while (true)
            {
                

                var key = System.Console.ReadKey(true);

                //start the state of Daytime
                if (key.Key.ToString() == "D")
                {
                    controller.SwithMode("Daytime");
                }
                //start the state of Nighttime
                if (key.Key.ToString() == "N")
                {
                    controller.SwithMode("Night");
                }
                //start the state of Stop
                if (key.Key.ToString() == "S")
                {
                    controller.SwithMode("Stop");
                }

                //exit from program
            }

        }
    }
}
