using Traffic_Lights.Model.Controllers;
using Traffic_Lights.Model.Models;

namespace Traffic_Light.Console
{
    class Program
    {
        static void Main(string[] args)
        {
     
         CrossroadsModel crossroadsModel = new CrossroadsModel();;
         CrossroadsController Controller = new CrossroadsController(crossroadsModel);
         CrossroadsConsoleView crossroadsView = new CrossroadsConsoleView(crossroadsModel, Controller);

            crossroadsView.DrawCrossroads();
            Controller.Mode.StartWorkMode();
            
            crossroadsView.ControlPanel();
          
          

        }
        
    }
}
