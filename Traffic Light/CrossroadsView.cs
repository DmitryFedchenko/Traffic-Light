using System;

namespace Traffic_Light.Modules
{

    public class CrossroadsView
    {
        private Crossroads crossroads;
        private CrossroadsController crossroadsController;

        public void RepresentSignalsTrafficLights()
        {

            foreach (var trafficLights in crossroads.TrafficLights)
            {
                foreach (var trafficLight in trafficLights.Value)
                {
                    LightSignal(trafficLight);
                }


            }
        }



        public void LightSignal(TrafficLight trafficLight)
        {
            switch (trafficLight.currentSignal)
            {
                case SignalTypes.Green:
                    SetSignal(trafficLight.posittionTrLight[PositionTypes.LampBottomX], trafficLight.posittionTrLight[PositionTypes.LampBottomY], ConsoleColor.Green);
                    return;


                case SignalTypes.Yellow:
                    SetSignal(trafficLight.posittionTrLight[PositionTypes.MiddleX], trafficLight.posittionTrLight[PositionTypes.MiddleY], ConsoleColor.Yellow);
                    return;


                case SignalTypes.Red:
                 
                    SetSignal(trafficLight.posittionTrLight[PositionTypes.LampTopX], trafficLight.posittionTrLight[PositionTypes.LampTopY], ConsoleColor.Red);
                    return;

                case SignalTypes.RedAndYellow:
                    
                    SetSignal(trafficLight.posittionTrLight[PositionTypes.LampTopX], trafficLight.posittionTrLight[PositionTypes.LampTopY], ConsoleColor.Red);
                    SetSignal(trafficLight.posittionTrLight[PositionTypes.MiddleX], trafficLight.posittionTrLight[PositionTypes.MiddleY], ConsoleColor.Yellow);
                    return;


                case SignalTypes.Black:
                    ResetSiganl(trafficLight.posittionTrLight[PositionTypes.LampTopX], trafficLight.posittionTrLight[PositionTypes.LampTopY]);

                    if (trafficLight.posittionTrLight.ContainsKey(PositionTypes.MiddleX))
                    {
                        ResetSiganl(trafficLight.posittionTrLight[PositionTypes.MiddleX], trafficLight.posittionTrLight[PositionTypes.MiddleY]);
                    }

                    ResetSiganl(trafficLight.posittionTrLight[PositionTypes.LampBottomX], trafficLight.posittionTrLight[PositionTypes.LampBottomY]);
                    return;



            }

        }

        public void SetSignal(int x, int y, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(x, y);
            Console.Write("*");
            Console.CursorVisible = false;
        }

        public void ResetSiganl(int x, int y)
        {

            Console.ResetColor();
            Console.SetCursorPosition(x, y);
            Console.Write("0");

        }

     
        public CrossroadsView(Crossroads crossroads, CrossroadsController crossroadsController)
        {

            this.crossroads = crossroads;
            crossroads.RepresentCrossroadsSignal += RepresentSignalsTrafficLights;
            this.crossroadsController = crossroadsController;

            //  Initialize the roadA
            crossroads.AddCarTrafficLight(ParticipantTypes.TrafficLightRoadA, 19, 9, 19, 10, 19, 11);
            crossroads.AddCarTrafficLight(ParticipantTypes.TrafficLightRoadA, 40, 9, 40, 10, 40, 11);


            //  Initialize the roadA
            crossroads.AddCarTrafficLight(ParticipantTypes.TrafficLightRoadB, 27, 7, 29, 7, 31, 7);
            crossroads.AddCarTrafficLight(ParticipantTypes.TrafficLightRoadB, 27, 12, 29, 12, 31, 12);

            //  Initialize the PedestrianTrafficLights
            crossroads.AddPedestrianTrafficLight(ParticipantTypes.PedestrianTrafficLight, 18, 3, 18, 4);
            crossroads.AddPedestrianTrafficLight(ParticipantTypes.PedestrianTrafficLight, 40, 3, 40, 4);
            crossroads.AddPedestrianTrafficLight(ParticipantTypes.PedestrianTrafficLight, 18, 14, 18, 15);
            crossroads.AddPedestrianTrafficLight(ParticipantTypes.PedestrianTrafficLight, 40, 14, 40, 15);

            crossroads.AddPedestrianTrafficLight(ParticipantTypes.PedestrianTrafficLight, 7, 6, 9, 6);
            crossroads.AddPedestrianTrafficLight(ParticipantTypes.PedestrianTrafficLight, 7, 14, 9, 14);
            crossroads.AddPedestrianTrafficLight(ParticipantTypes.PedestrianTrafficLight, 49, 6, 51, 6);
            crossroads.AddPedestrianTrafficLight(ParticipantTypes.PedestrianTrafficLight, 49, 14, 51, 14);

        }

        public void DrawCrossroads()
        {
            Console.WriteLine("                                                               ");
            Console.WriteLine("                                                               ");
            Console.WriteLine("                  _  |               |  _                      ");
            Console.WriteLine("                 |0| |## ## ## ## ## | |0|                     ");
            Console.WriteLine("                 |0| |## ## ## ## ## | |0|                     ");
            Console.WriteLine("       _ _           |## ## ## ## ## |           _ _           ");
            Console.WriteLine("      |0|0|          |     _____     |          |0|0|          ");
            Console.WriteLine("      _______________|    |0|0|0|    |__________________       ");
            Console.WriteLine("       ######      _                    _      ######          ");
            Console.WriteLine("       ######     |0|                  |0|     ######          ");
            Console.WriteLine("       ######     |0|                  |0|     ######          ");
            Console.WriteLine("       ######     |0|      _____       |0|     ######          ");
            Console.WriteLine("      _______________     |0|0|0|     ___________________      ");
            Console.WriteLine("       _ _        _  |               |  _        _ _           ");
            Console.WriteLine("      |0|0|      |0| |## ## ## ## ## | |0|      |0|0|          ");
            Console.WriteLine("                 |0| |## ## ## ## ## | |0|                     ");
            Console.WriteLine("                     |## ## ## ## ## |                         ");
            Console.WriteLine("                     |               |                         ");
            Console.WriteLine("                     |               |                         ");
            Console.WriteLine("                     |               |                         ");
            Console.WriteLine(
                " \n\nTo select a mode of day, press key: 'd',\n for night: 'n'\n and for the stop work: 's'.");
        }

        public void ControlPanel()
        {
            while (true)
            {
                var key = Console.ReadKey(true);

                //start the state of Daytime
                if (key.Key.ToString() == "D")
                {
                    crossroadsController.Mode.CurrentMode = ModeTypes.Daytime;

                }
                //start the state of Nighttime
                if (key.Key.ToString() == "N")
                {
                    crossroadsController.Mode.CurrentMode = ModeTypes.Night;

                }
                //start the state of Stop
                if (key.Key.ToString() == "S")
                {
                    crossroadsController.Mode.CurrentMode = ModeTypes.Stop;

                }
            }
        }

    }
}
