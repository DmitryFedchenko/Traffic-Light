using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Traffic_Light.Modules;

namespace Traffic_Light.Controllers
{
   public class CenterControl
   {
        public System.Timers.Timer aTimer;
        private  Crossroads crossroads;
       public CrossroadsController Controller { get; set; }
       private CrossroadsView crossroadsView;

        public CenterControl()
        {
            crossroads = new Crossroads();
            Controller = new CrossroadsController(crossroads);
            crossroadsView = new CrossroadsView(crossroads,Controller);
            crossroadsView.DrawCrossroads();
            

            // Initialize the roadA
            crossroads.AddCarTrafficLight(ParticipantTypes.TrafficLightRoadA, 19, 9, 19, 10, 19, 11);
            crossroads.AddCarTrafficLight(ParticipantTypes.TrafficLightRoadA, 40, 9, 40, 10, 40, 11);


            // Initialize the roadA
            crossroads.AddCarTrafficLight(ParticipantTypes.TrafficLightRoadB, 27, 7, 29, 7, 31, 7);
            crossroads.AddCarTrafficLight(ParticipantTypes.TrafficLightRoadB, 27, 12, 29, 12, 31, 12);

            // Initialize the PedestrianTrafficLights
            crossroads.AddPedestrianTrafficLight(ParticipantTypes.PedestrianTrafficLight, 18, 3, 18, 4);
            crossroads.AddPedestrianTrafficLight(ParticipantTypes.PedestrianTrafficLight, 40, 3, 40, 4);
            crossroads.AddPedestrianTrafficLight(ParticipantTypes.PedestrianTrafficLight, 18, 14, 18, 15);
            crossroads.AddPedestrianTrafficLight(ParticipantTypes.PedestrianTrafficLight, 40, 14, 40, 15);

            crossroads.AddPedestrianTrafficLight(ParticipantTypes.PedestrianTrafficLight, 7, 6, 9, 6);
            crossroads.AddPedestrianTrafficLight(ParticipantTypes.PedestrianTrafficLight, 7, 14, 9, 14);
            crossroads.AddPedestrianTrafficLight(ParticipantTypes.PedestrianTrafficLight, 49, 6, 51, 6);
            crossroads.AddPedestrianTrafficLight(ParticipantTypes.PedestrianTrafficLight, 49, 14, 51, 14);


        }


        public void StartWork()
        {

            //Create a secondary thread to control the crossroads
            Controller.Mode.ChangeState(ModeTypes.Daytime);

        }

     


    }
}
