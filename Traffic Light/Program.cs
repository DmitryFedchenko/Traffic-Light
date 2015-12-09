using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traffic_Light.Modules;
using Traffic_Light.Controllers;
namespace Traffic_Light
{
    class Program
    {
        static void Main(string[] args)
        {
            var controlCentr = new CenterControl();
            var desk  = new CrossroadsView();
            desk.View();
            controlCentr.StartWork();
        }
    }
}
