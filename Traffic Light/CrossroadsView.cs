using System;
using System.Collections.Generic;



namespace Traffic_Light.Console
{
    
    public class CrossroadsView : ICrossroadsView
    {
        public List<ITrafficLightView> ViewTraffiLIghts { get; set; }
        
        public event EventHandler AddTraffilight;
        public event EventHandler UserChangeMode;

        public string UserSelectedState {get; set;}
        


        public void AddViewTrafficLight(ITrafficLightView viewTrafficLIght)
        {
            ViewTraffiLIghts.Add(viewTrafficLIght);
            viewTrafficLIght.Id = ViewTraffiLIghts.Count-1;

            if (AddTraffilight != null)
                AddTraffilight(this, EventArgs.Empty);
        }


        public void RepresentSignal(int TraffiLightId, int lampId, string colorSiganl, bool light)
        {
          
                ConsoleColor tempColor;
                if (Enum.TryParse(colorSiganl, out tempColor))
                {
                    var tempViewTrafficLight = ViewTraffiLIghts.Find(x => x.Id == TraffiLightId);
                    int lampX = tempViewTrafficLight.LampCoordinates[lampId].X;
                    int lampY = tempViewTrafficLight.LampCoordinates[lampId].Y;

                    if(light)
                    SetSignal(lampX, lampY, tempColor);

                    else
                    ResetSiganl(lampX, lampY);
                }


            //ConsoleColor tempColor = ConsoleColor.Black;
            //int lampId = 0;

            //if (redLamp)
            //{
            //    lampId = 0;
            //    tempColor = ConsoleColor.Red;
            //}
            //if (yellowLamp)
            //{
            //    lampId = 1;
            //    tempColor = ConsoleColor.Yellow;
            //}
            //if (greenLamp)
            //{
            //    lampId = 2;
            //    tempColor = ConsoleColor.Green;
            //}

            //var tempViewTrafficLight = ViewTraffiLIghts.Find(x => x.Id == TraffiLightId);
            //int lampX = tempViewTrafficLight.LampCoordinates[lampId].X;
            //int lampY = tempViewTrafficLight.LampCoordinates[lampId].Y;

            //SetSignal(lampX, lampY, tempColor);


            //ResetSiganl(lampX, lampY);

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

        public void InitTrafficLight()
        {
            //  Initialize the roadA
            AddViewTrafficLight(new TrafficLightView("TrafficLightRoadA", 19, 9, 19, 10, 19, 11));
            AddViewTrafficLight(new TrafficLightView("TrafficLightRoadA", 40, 9, 40, 10, 40, 11));

            //  Initialize the roadA
            AddViewTrafficLight(new TrafficLightView("TrafficLightRoadB", 27, 7, 29, 7, 31, 7));
            AddViewTrafficLight(new TrafficLightView("TrafficLightRoadB", 27, 12, 29, 12, 31, 12));

            //  Initialize the PedestrianTrafficLights
            AddViewTrafficLight(new TrafficLightView("PedestrianTrafficLight", 18, 3,  18, 4));
            AddViewTrafficLight(new TrafficLightView("PedestrianTrafficLight", 40, 3,  40, 4));
            AddViewTrafficLight(new TrafficLightView("PedestrianTrafficLight", 18, 14,  18, 15));
            AddViewTrafficLight(new TrafficLightView("PedestrianTrafficLight", 40, 14,  40, 15));

            AddViewTrafficLight(new TrafficLightView("PedestrianTrafficLight", 7, 6, 9, 6));
            AddViewTrafficLight(new TrafficLightView("PedestrianTrafficLight", 7, 14, 9, 14));
            AddViewTrafficLight(new TrafficLightView("PedestrianTrafficLight", 49, 6, 51, 6));
            AddViewTrafficLight(new TrafficLightView("PedestrianTrafficLight", 49, 14, 51, 14));

        }



        public CrossroadsView()
        {
            ViewTraffiLIghts = new List<ITrafficLightView>();
        

          
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
                        UserSelectedState = "Daytime";

                    if (UserChangeMode != null)
                        UserChangeMode(this, EventArgs.Empty);
                    }
                    //start the state of Nighttime
                    if (key.Key.ToString() == "N")
                    {
                        UserSelectedState = "Night";
                    if (UserChangeMode != null)
                        UserChangeMode(this, EventArgs.Empty);
                }
                    //start the state of Stop
                    if (key.Key.ToString() == "S")
                    {
                        UserSelectedState = "Stop";

                    if (UserChangeMode != null)
                        UserChangeMode(this, EventArgs.Empty);
                }

                    //exit from program
                    if (key.Key.ToString() == "E")
                    {
                        UserSelectedState = "StopIterate";
                        return;
                    }
                }
         
         

        }

    }
}
