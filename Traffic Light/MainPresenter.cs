using System;
using System.Collections.Generic;
using Traffic_Light.Console;
using TrafficLightClassDiagram;

namespace Traffic_Light
{
    class MainPresenter
    {
        

        readonly ITrafficLightController TrafficLightController;
        readonly ICrossroadsView CrossroadsView;
        object obj = new object();

        public MainPresenter(ITrafficLightController trafficLightControl, ICrossroadsView crossroadsView )
        {
            CrossroadsView = crossroadsView;
            this.TrafficLightController = trafficLightControl;

            CrossroadsView.AddTraffilight += CrossroadsView_addTraffilight;
            CrossroadsView.UserChangeMode += CrossroadsView_UserChangeMode;

            CrossroadsView.InitTrafficLight();

            foreach (var trafficLight in TrafficLightController.TrafficLights)
                trafficLight.ChangeSignal += TrafficLightStateChange;



           
        }

        private void CrossroadsView_UserChangeMode(object sender, EventArgs e)
        {
            TrafficLightController.SwithMode(CrossroadsView.UserSelectedState);
        }

    
        private void TrafficLightStateChange(object sender, EventArgs e)
        {                        
            Dictionary<LampType, bool> tempLamps = new Dictionary<LampType, bool>();
         //   tempLamps = ((TrafficLight)sender).Lamps;

            var tempTrafficLight = (TrafficLight)sender;

            
                foreach (var lamp in tempLamps)
                    CrossroadsView.RepresentSignal(tempTrafficLight.Id, (int)lamp.Key, lamp.Value);
            

        }

        //private void CrossroadsView_addTraffilight(object sender, EventArgs e)
        //{
        //    foreach (var viewTrafficLight in CrossroadsView.ViewTraffiLIghts)
        //    {
        //                string tempTrafficLightType = viewTrafficLight.TrafficLightType;
        //                int tempTrafficLightId = viewTrafficLight.Id;

        //        if (!TrafficLightController.TrafficLights.Exists(x => x.Id == tempTrafficLightId))
        //        {
        //            TrafficLightController.AddTrafficlight(tempTrafficLightId, tempTrafficLightType);

        //        }

        //   }
        //}





        

       
    }
}
