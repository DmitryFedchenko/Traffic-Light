using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Traffic_Light.Controllers
{
   public class CenterControl
    {
        private CrossroadsController crController;
        private RoadController road1;
        private RoadController road2;


        public CenterControl()
        {
            crController = new CrossroadsController();
            road1 = new RoadController(crController);
            road2 = new RoadController(crController);

            crController.tLightRoadA = road1;
            crController.tLightRoadB = road2;

            // Initialize the road1
            road1.AddCarTrLight(19, 9, 19, 10, 19, 11);
            road1.AddCarTrLight(40, 9, 40, 10, 40, 11);

            road1.AddPedTLight(7, 6, 9, 6);
            road1.AddPedTLight(7, 14, 9, 14);

            road1.AddPedTLight(49, 6, 51, 6);
            road1.AddPedTLight(49, 14, 51, 14);

            // Initialize the road2
            road2.AddCarTrLight(27, 7, 29, 7, 31, 7);
            road2.AddCarTrLight(27, 12, 29, 12, 31, 12);

            road2.AddPedTLight(18, 3, 18, 4);
            road2.AddPedTLight(40, 3, 40, 4);
            road2.AddPedTLight(18, 14, 18, 15);
            road2.AddPedTLight(40, 14, 40, 15);
        

        }


        public void StartWork()
        {
            crController.State = new CrossroadsDay(crController);
            
            //Create a secondary thread to control the crossroads
            Thread someThread = new Thread(Control);

            someThread.Start();

            crController.Work();
        }

        public void Control()
        {
          while (true)
            {
                var cki = Console.ReadKey(true);
               
                //start the state of Daytime
                if (cki.Key.ToString() == "D")
                {
                    crController.State.ChangeMode(WorkModeEnum.Daytime);

                }
                //start the state of Nighttime
                if (cki.Key.ToString() == "N")
                {
                    crController.State.ChangeMode(WorkModeEnum.Night);

                }
                //start the state of Stop
                if (cki.Key.ToString() == "S")
                {
                    crController.State.ChangeMode(WorkModeEnum.Stop);

                }
            }
        }


    }
}
