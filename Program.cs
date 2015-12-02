using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Traffic_Light.Modules;

namespace Traffic_Light
{
    class Program
    {
        static void Main(string[] args)
        {
            AutoTrafficLight autoTrafficLight =new AutoTrafficLight();
            autoTrafficLight.Work();
            Console.ReadKey();
        }
    }
}
