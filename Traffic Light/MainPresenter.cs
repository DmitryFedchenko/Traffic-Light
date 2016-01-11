using System;
using Traffic_Light.Console;
using Traffic_Lights.Model.Models;

namespace Traffic_Light
{
    class MainPresenter
    {
        private object obj = new object();

        readonly ICrossroads Crossroads;
        readonly ICrossroadsView CrossroadsView;
       

        public MainPresenter(ICrossroads crossroads, ICrossroadsView crossroadsView )
        {
            CrossroadsView = crossroadsView;
            this.Crossroads = crossroads;

            CrossroadsView.AddTraffilight += CrossroadsView_addTraffilight;
            CrossroadsView.ChangedState += CrossroadsView_ChangedState;
            Crossroads.TrafficLightChange += CrossroadsTrafficLightChange;

            CrossroadsView.InitTrafficLight();
        }

        private void CrossroadsView_ChangedState(object sender, EventArgs e)
        {
           Crossroads.ChangeSelectedCrossroadsState(CrossroadsView.UserSelectedState);
        }


        private void CrossroadsTrafficLightChange(object sender, EventArgs e)
        {
            lock (obj)
            {
                 foreach (var lamp in Crossroads.CurrentChangedTraffiLight.Lamps)
                {
                CrossroadsView.LightSignal(Crossroads.CurrentChangedTraffiLight.Id, lamp.Id, lamp.Signal, lamp.Light);
                }
            }
       
        }

        private void CrossroadsView_addTraffilight(object sender, EventArgs e)
        {
            foreach (var viewTrafficLight in CrossroadsView.ViewTraffiLIghts)
            {
                        string tempParticipan = viewTrafficLight.Participan;
                        int tempTrafficLightId = viewTrafficLight.Id;
                        int tempTrafficLightCount = viewTrafficLight.LampCount;

                Crossroads.AddTrafficLight(tempParticipan, tempTrafficLightId, tempTrafficLightCount);
             
            }
        }





        

       
    }
}
