
using NLog;
using Traffic_Light.Model;

namespace Traffic_Light.Console
{
    class Program
    {

        static void Main(string[] args)
        {
            Logger logger = LogManager.GetCurrentClassLogger();

            CrossroadsView crossroadsView = new CrossroadsView();

            crossroadsView.AddTrafficlight(new TrafficLightView(TrafficLightType.RoadATrafficLight, 19, 9, 19, 10, 19, 11));
            crossroadsView.AddTrafficlight(new TrafficLightView(TrafficLightType.RoadATrafficLight, 40, 9, 40, 10, 40, 11));

            crossroadsView.AddTrafficlight(new TrafficLightView(TrafficLightType.RoadBTrafficLight, 27, 7, 29, 7, 31, 7));
            crossroadsView.AddTrafficlight(new TrafficLightView(TrafficLightType.RoadBTrafficLight, 27, 12, 29, 12, 31, 12));

            crossroadsView.AddTrafficlight(new TrafficLightView(TrafficLightType.PedestrianTrafficLight, 18, 3, 18, 4));
            crossroadsView.AddTrafficlight(new TrafficLightView(TrafficLightType.PedestrianTrafficLight, 40, 3, 40, 4));
            crossroadsView.AddTrafficlight(new TrafficLightView(TrafficLightType.PedestrianTrafficLight, 18, 14, 18, 15));
            crossroadsView.AddTrafficlight(new TrafficLightView(TrafficLightType.PedestrianTrafficLight, 40, 14, 40, 15));

            crossroadsView.AddTrafficlight(new TrafficLightView(TrafficLightType.PedestrianTrafficLight, 7, 6, 9, 6));
            crossroadsView.AddTrafficlight(new TrafficLightView(TrafficLightType.PedestrianTrafficLight, 7, 14, 9, 14));
            crossroadsView.AddTrafficlight(new TrafficLightView(TrafficLightType.PedestrianTrafficLight, 49, 6, 51, 6));
            crossroadsView.AddTrafficlight(new TrafficLightView(TrafficLightType.PedestrianTrafficLight, 49, 14, 51, 14));



            TrafficLightController controller = new TrafficLightController();
            Presenter presenter = new Presenter(crossroadsView, controller);




            crossroadsView.DrawCrossroads();
            controller.StartWork();
            crossroadsView.ControlPanel();





        }
    }
}