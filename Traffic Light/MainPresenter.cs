﻿using System;
using System.Collections.Generic;
using Traffic_Light.Console;
using Traffic_Light.Model;

namespace Traffic_Light
{
    class MainPresenter
    {
        public ITrafficLightController Controller;
        public ICrossroadsView CrossroadsView;

        CarTrafficLight RoadATrafficLight;
        CarTrafficLight RoadBTrafficLight;
        PedestrianTrafficLight PedestrianTrafficLight;
       
        

        public MainPresenter(ICrossroadsView crossroadsView, ITrafficLightController controller)
        {
            CrossroadsView = crossroadsView;
            Controller = controller;

            RoadATrafficLight = new CarTrafficLight(0, "RoadATrafficLight");
            RoadBTrafficLight = new CarTrafficLight(1, "RoadBTrafficLight");
            PedestrianTrafficLight = new PedestrianTrafficLight(2, "PedestrianTrafficLight");

            Controller.AddTrafficlight(RoadATrafficLight);
            Controller.AddTrafficlight(RoadBTrafficLight);
            Controller.AddTrafficlight(PedestrianTrafficLight);

            CrossroadsView.UserChangeMode += CrossroadsView_UserChangeMode;
            RoadATrafficLight.ChangeSignal += RoadATrafficLight_ChangeSignal;
            RoadBTrafficLight.ChangeSignal += RoadBTrafficLight_ChangeSignal;
            PedestrianTrafficLight.ChangeSignal += PedestrianTrafficLight_ChangeSignal;
                       
        }

        private void CrossroadsView_UserChangeMode(object sender, EventArgs e)
        {
            Controller.SwithMode(CrossroadsView.UserSelectedState);
        }

        private void PedestrianTrafficLight_ChangeSignal(object sender, EventArgs e)
        {
            CrossroadsView.PedestrianTrafficLight.ChangeSignal(PedestrianTrafficLight.RedLamp, PedestrianTrafficLight.GreenLamp);
        }

        private void RoadBTrafficLight_ChangeSignal(object sender, EventArgs e)
        {
                CrossroadsView.RoadBTrafficLight.ChangeSignal(RoadBTrafficLight.RedLamp, RoadBTrafficLight.YellowLamp, RoadBTrafficLight.GreenLamp);
        }

        private void RoadATrafficLight_ChangeSignal(object sender, EventArgs e)
        {
                CrossroadsView.RoadATrafficLight.ChangeSignal(RoadATrafficLight.RedLamp, RoadATrafficLight.YellowLamp, RoadATrafficLight.GreenLamp);
        }
    }
}
