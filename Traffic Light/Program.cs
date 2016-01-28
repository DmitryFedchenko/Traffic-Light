
using NLog;
using Traffic_Light.Model;

namespace Traffic_Light.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            CrossroadsView crossroadsView = new CrossroadsView();
            TrafficLightController controller = new TrafficLightController(); 
            MainPresenter presenter = new MainPresenter(crossroadsView,controller);

            crossroadsView.DrawCrossroads();
            controller.StartWork();
            crossroadsView.ControlPanel();
                    


        }
        
    }
}
