using TrafficLightClassDiagram;


namespace Traffic_Light.Console
{
    class Program
    {
        static void Main(string[] args)
        {

            TrafficLightController trafficLightController = new TrafficLightController();;
         CrossroadsView crossroadsView = new CrossroadsView();
         MainPresenter presenter = new MainPresenter(trafficLightController, crossroadsView);
            crossroadsView.DrawCrossroads();
            trafficLightController.StartWork();
            crossroadsView.ControlPanel();




        }
        
    }
}
