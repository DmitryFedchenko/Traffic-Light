using System;
using Traffic_Lights.Model.Constants;
using Traffic_Lights.Model.Controllers;
using Traffic_Lights.Model.Models;

namespace Traffic_Light.Console
{

    public class CrossroadsConsoleView
    {
       
        private object obj = new object();

        private CrossroadsController crossroadsController;
        private CrossroadsModel crossroadsModel;

        public void RepresentSignalsTrafficLights(TrafficLightModel e)
        {
            lock (obj)
            {
                LightSignal(e);
            }
                
        }

      

        public void LightSignal(TrafficLightModel trafficLightModel)
        {
        
                switch (trafficLightModel.currentSignal)
                {
                    case SignalTypes.Green:
                        SetSignal(trafficLightModel.posittionTrafficLight[PositionTypes.LampBottomX],
                            trafficLightModel.posittionTrafficLight[PositionTypes.LampBottomY], ConsoleColor.Green);
                        return;


                    case SignalTypes.Yellow:
                        SetSignal(trafficLightModel.posittionTrafficLight[PositionTypes.MiddleX],
                            trafficLightModel.posittionTrafficLight[PositionTypes.MiddleY], ConsoleColor.Yellow);
                        return;


                    case SignalTypes.Red:

                        SetSignal(trafficLightModel.posittionTrafficLight[PositionTypes.LampTopX],
                            trafficLightModel.posittionTrafficLight[PositionTypes.LampTopY], ConsoleColor.Red);
                        return;

                    case SignalTypes.RedAndYellow:

                        SetSignal(trafficLightModel.posittionTrafficLight[PositionTypes.LampTopX],
                            trafficLightModel.posittionTrafficLight[PositionTypes.LampTopY], ConsoleColor.Red);
                        SetSignal(trafficLightModel.posittionTrafficLight[PositionTypes.MiddleX],
                            trafficLightModel.posittionTrafficLight[PositionTypes.MiddleY], ConsoleColor.Yellow);
                        return;


                    case SignalTypes.Black:
                        ResetSiganl(trafficLightModel.posittionTrafficLight[PositionTypes.LampTopX],
                            trafficLightModel.posittionTrafficLight[PositionTypes.LampTopY]);

                        if (trafficLightModel.posittionTrafficLight.ContainsKey(PositionTypes.MiddleX))
                        {
                            ResetSiganl(trafficLightModel.posittionTrafficLight[PositionTypes.MiddleX],
                                trafficLightModel.posittionTrafficLight[PositionTypes.MiddleY]);
                        }

                        ResetSiganl(trafficLightModel.posittionTrafficLight[PositionTypes.LampBottomX],
                            trafficLightModel.posittionTrafficLight[PositionTypes.LampBottomY]);
                        return;

                }
         
        }

        public void SetSignal(int x, int y, ConsoleColor color)
        {
            System.Console.ForegroundColor = color;
            System.Console.SetCursorPosition(x, y);
            System.Console.Write("*");
            System.Console.CursorVisible = false;
            
        }

        public void ResetSiganl(int x, int y)
        {

            System.Console.ResetColor();
            System.Console.SetCursorPosition(x, y);
            System.Console.Write("0");

        }

        public void AddEventTrafficlights()
        {
            foreach (var keyValuePair in crossroadsModel.TrafficLights)
            {
                foreach (var trafficLight in keyValuePair.Value)
                {
                    trafficLight.RepresentCrossroadsSignal += RepresentSignalsTrafficLights;
                }
            }
        }
     
        public CrossroadsConsoleView(CrossroadsModel crossroadsModel, CrossroadsController crossroadsController)
        {

            this.crossroadsModel = crossroadsModel;
            this.crossroadsController = crossroadsController;

            //  Initialize the roadA
            crossroadsController.AddTrafficLight(ParticipanTypes.TrafficLightRoadA, 19, 9, 19, 10, 19, 11);
            crossroadsController.AddTrafficLight(ParticipanTypes.TrafficLightRoadA, 40, 9, 40, 10, 40, 11);

            //  Initialize the roadA
            crossroadsController.AddTrafficLight(ParticipanTypes.TrafficLightRoadB, 27, 7, 29, 7, 31, 7);
            crossroadsController.AddTrafficLight(ParticipanTypes.TrafficLightRoadB, 27, 12, 29, 12, 31, 12);

            //  Initialize the PedestrianTrafficLights
            crossroadsController.AddTrafficLight(ParticipanTypes.PedestrianTrafficLight, 18, 3, 0,0,18, 4);
            crossroadsController.AddTrafficLight(ParticipanTypes.PedestrianTrafficLight, 40, 3,0,0, 40, 4);
            crossroadsController.AddTrafficLight(ParticipanTypes.PedestrianTrafficLight, 18, 14, 0, 0, 18, 15);
            crossroadsController.AddTrafficLight(ParticipanTypes.PedestrianTrafficLight, 40, 14, 0, 0, 40, 15);

            crossroadsController.AddTrafficLight(ParticipanTypes.PedestrianTrafficLight, 7, 6, 0, 0,9, 6);
            crossroadsController.AddTrafficLight(ParticipanTypes.PedestrianTrafficLight, 7, 14, 0, 0, 9, 14);
            crossroadsController.AddTrafficLight(ParticipanTypes.PedestrianTrafficLight, 49, 6, 0, 0, 51, 6);
            crossroadsController.AddTrafficLight(ParticipanTypes.PedestrianTrafficLight, 49, 14, 0, 0, 51, 14);

            AddEventTrafficlights();
        }

        public void DrawCrossroads()
        {
            System.Console.WriteLine("                                                               ");
            System.Console.WriteLine("                                                               ");
            System.Console.WriteLine("                  _  |               |  _                      ");
            System.Console.WriteLine("                 |0| |## ## ## ## ## | |0|                     ");
            System.Console.WriteLine("                 |0| |## ## ## ## ## | |0|                     ");
            System.Console.WriteLine("       _ _           |## ## ## ## ## |           _ _           ");
            System.Console.WriteLine("      |0|0|          |     _____     |          |0|0|          ");
            System.Console.WriteLine("      _______________|    |0|0|0|    |__________________       ");
            System.Console.WriteLine("       ######      _                    _      ######          ");
            System.Console.WriteLine("       ######     |0|                  |0|     ######          ");
            System.Console.WriteLine("       ######     |0|                  |0|     ######          ");
            System.Console.WriteLine("       ######     |0|      _____       |0|     ######          ");
            System.Console.WriteLine("      _______________     |0|0|0|     ___________________      ");
            System.Console.WriteLine("       _ _        _  |               |  _        _ _           ");
            System.Console.WriteLine("      |0|0|      |0| |## ## ## ## ## | |0|      |0|0|          ");
            System.Console.WriteLine("                 |0| |## ## ## ## ## | |0|                     ");
            System.Console.WriteLine("                     |## ## ## ## ## |                         ");
            System.Console.WriteLine("                     |               |                         ");
            System.Console.WriteLine("                     |               |                         ");
            System.Console.WriteLine("                     |               |                         ");
            System.Console.WriteLine(
                " \n\nTo select a mode of day, press key: 'd',\n for night: 'n'\n and for the stop work: 's'.");
        }

        public void ControlPanel()
        {
            
            while (true)
                {
                    var key = System.Console.ReadKey(true);

                    //start the state of Daytime
                    if (key.Key.ToString() == "D")
                    {
                        crossroadsController.CurrentMode = ModeTypes.Daytime;

                    }
                    //start the state of Nighttime
                    if (key.Key.ToString() == "N")
                    {
                        crossroadsController.CurrentMode = ModeTypes.Night;

                    }
                    //start the state of Stop
                    if (key.Key.ToString() == "S")
                    {
                        crossroadsController.CurrentMode = ModeTypes.Stop;

                    }

                    //exit from program
                    if (key.Key.ToString() == "E")
                    {
                        crossroadsController.CurrentMode = ModeTypes.Exit;
                        return;
                    }
            }
            
        }

    }
}
