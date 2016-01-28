using System;
using System.Collections.Generic;



namespace Traffic_Light.Console
{
    
    public class CrossroadsView : ICrossroadsView
    {
        public TrafficLightView RoadATrafficLight { get; set; } = new TrafficLightView("RoadATrafficLight", 19, 9, 19, 10, 19, 11);
        public TrafficLightView RoadBTrafficLight { get; set; } = new TrafficLightView("RoadBTrafficLight", 27, 7, 29, 7, 31, 7);
        public TrafficLightView PedestrianTrafficLight { get; set; } = new TrafficLightView("PedestrianTrafficLight", 18, 3, 18, 4);

        public List<TrafficLightView> ViewTraffiLIghts { get; set; }
        
        public event EventHandler AddTraffilight;
        public event EventHandler UserChangeMode;

        public string UserSelectedState {get; set;}



        public void AddViewTrafficLight(TrafficLightView viewTrafficLIght)
        {
            ViewTraffiLIghts.Add(viewTrafficLIght);
            viewTrafficLIght.Id = ViewTraffiLIghts.Count - 1;

            if (AddTraffilight != null)
                AddTraffilight(this, EventArgs.Empty);
        }


        public CrossroadsView()
        {
            ViewTraffiLIghts = new List<TrafficLightView>();
     
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
