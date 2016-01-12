using Traffic_Lights.Model.Models;

namespace Traffic_Light.Console
{
    class Program
    {
        static void Main(string[] args)
        {
     
         Crossroads crossroads = new Crossroads();;
         CrossroadsView crossroadsView = new CrossroadsView();
         MainPresenter presenter = new MainPresenter(crossroads, crossroadsView);
            crossroadsView.DrawCrossroads();
            crossroads.ManagerCrossroads.StartWorkTraffiLights();
            crossroadsView.ControlPanel();




        }
        
    }
}
