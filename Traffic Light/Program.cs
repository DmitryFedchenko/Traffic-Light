using TrafficLitht;

namespace Traffic_Light.Console
{
    class Program
    {
        static void Main(string[] args)
        {
     
         TrafficLightController crossroads = new TrafficLightController();;
         CrossroadsView crossroadsView = new CrossroadsView();
         MainPresenter presenter = new MainPresenter(crossroads, crossroadsView);
            crossroadsView.DrawCrossroads();
            crossroads.StartWork();
            crossroadsView.ControlPanel();




        }
        
    }
}
