using System;
using System.Collections.Generic;
using Traffic_Light.Model;


namespace Traffic_Light.Console
{
    
    public class CrossroadsView : ICrossroadsView
    {
       
        public List<ITrafficLightView> ViewTrafficLights { get; }
        public void AddTrafficlight(ITrafficLightView trafficLight)
        {
            if(!ViewTrafficLights.Contains(trafficLight))
            ViewTrafficLights.Add(trafficLight);
        }
  
        public event EventHandler UserChangeMode;
        public TrafficLightModeType UserSelectedState {get; set;}

        public CrossroadsView()
        {
            ViewTrafficLights = new List<ITrafficLightView>();
     
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
                " \n\n For select the mode of day, press key: 'd',\n for night: 'n',\n for the stop work: 's' and exit from the program: 'e'");
        }

        public void ControlPanel()
        {
                while (true)
                {

                    var key = System.Console.ReadKey(true);

                    //start the state of Daytime
                    if (key.Key.ToString() == "D")
                    {
                        UserSelectedState = TrafficLightModeType.DayTime;

                    if (UserChangeMode != null)
                        UserChangeMode(this, EventArgs.Empty);
                    }
                    //start the state of Nighttime
                    if (key.Key.ToString() == "N")
                    {
                        UserSelectedState = TrafficLightModeType.Night;
                    if (UserChangeMode != null)
                        UserChangeMode(this, EventArgs.Empty);
                }
                    //start the state of Stop
                    if (key.Key.ToString() == "S")
                    {
                        UserSelectedState = TrafficLightModeType.Stop;

                    if (UserChangeMode != null)
                        UserChangeMode(this, EventArgs.Empty);
                }

                    //exit from program
                    if (key.Key.ToString() == "E")
                        return;
                }
         
         

        }

    }
}
