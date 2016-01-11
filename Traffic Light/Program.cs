using Traffic_Lights.Model.Models;

namespace Traffic_Light.Console
{
    class Program
    {
        static void Main(string[] args)
        {
     
         CrossroadsModel crossroads = new CrossroadsModel();;
         CrossroadsView crossroadsView = new CrossroadsView();
         MainPresenter presenter = new MainPresenter(crossroads, crossroadsView);
            crossroadsView.DrawCrossroads();
            crossroads.ManagerCrossroads.StartWork();
            crossroadsView.ControlPanel();




        }
        
    }
}
