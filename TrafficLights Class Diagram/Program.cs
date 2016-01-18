using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLightClassDiagram
{
    class Program
    {
        static void Main(string[] args)
        {
            TrafficLightController controller = new TrafficLightController();
            controller.IterateControllerStates();
           
        }
    }
}
