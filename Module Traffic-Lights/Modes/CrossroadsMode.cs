using System.Collections.Generic;
using Traffic_Lights.Model.Constants;
using Traffic_Lights.Model.Controllers;
using Traffic_Lights.Model.Models;
using Traffic_Lights.Model.Modes;


namespace Traffic_Light.Model.Modes
{
   public abstract  class CrossroadsMode
    {
        object obj = new object();

        protected CrossroadsController crossroadsController;
      
        
      public CrossroadsMode(CrossroadsController crossroadsController)
        {
               this.crossroadsController = crossroadsController;
               crossroadsController.States = new List<CrossroadsStateModel>();
        }

        public void StartWorkMode()
        {
            lock (obj)
            {
                switch (crossroadsController.CurrentMode)
                {

                    case ModeTypes.Daytime:
                        crossroadsController.Mode = new DayTimeMode(crossroadsController);
                        crossroadsController.SetMode();
                        break;

                    case ModeTypes.Night:
                        crossroadsController.Mode = new NightMode(crossroadsController);
                        crossroadsController.SetMode();
                        break;

                    case ModeTypes.Stop:
                        crossroadsController.Mode = new StopMode(crossroadsController);
                        crossroadsController.SetMode();
                        break;

                    case ModeTypes.Exit:
                        crossroadsController.Exit();
                        break;
                        
                }
            }
        }


  
        }
    }
