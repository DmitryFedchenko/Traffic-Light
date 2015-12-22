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
     
         Crossroads crossroads = new Crossroads();;
         CrossroadsController Controller = new CrossroadsController(crossroads);
         CrossroadsView crossroadsView = new CrossroadsView(crossroads, Controller);

            crossroadsView.DrawCrossroads();


            Controller.Mode.ChangeMode(ModeTypes.Daytime);
            Console.ReadLine();


        }
        
    }
}
