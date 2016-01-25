using System;
using Traffic_Light.Console;
using TrafficLitht;

namespace Traffic_Light
{
    class MainPresenter
    {


        readonly ITrafficLightController TrafficLightController;
        readonly ICrossroadsView CrossroadsView;
       

        public MainPresenter(ITrafficLightController trafficLightControl, ICrossroadsView crossroadsView )
        {
            CrossroadsView = crossroadsView;
            this.TrafficLightController = trafficLightControl;

            CrossroadsView.AddTraffilight += CrossroadsView_addTraffilight;
            CrossroadsView.UserChangeMode += CrossroadsView_UserChangeMode;


            foreach (var trafficLight in TrafficLightController.CarTrafficlights)
            trafficLight.ChangeSignal += TrafficLightStateChange;

            foreach (var trafficLight in TrafficLightController.PedestrianTrafficlights)
                trafficLight.ChangeSignal += TrafficLightStateChange;


            CrossroadsView.InitTrafficLight();
        }

        private void CrossroadsView_UserChangeMode(object sender, EventArgs e)
        {
            TrafficLightController.ModeSelectUser = CrossroadsView.UserSelectedState;
        }


        private void TrafficLightStateChange(object sender, EventArgs e)
        {

            
                foreach (var trafficLight in TrafficLightController.CarTrafficlights)
                {
         //           this.CrossroadsView.ViewTraffiLIghts[trafficLight.Id]. 
                }


        }

        private void CrossroadsView_addTraffilight(object sender, EventArgs e)
        {
            foreach (var viewTrafficLight in CrossroadsView.ViewTraffiLIghts)
            {
                        string tempTrafficLightType = viewTrafficLight.TrafficLightType;
                        int tempTrafficLightId = viewTrafficLight.Id;
                     

                TrafficLightController.AddTrafficlight(tempTrafficLightId, tempTrafficLightType);
           }
        }





        

       
    }
}
