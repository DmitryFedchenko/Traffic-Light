using System.Collections.Generic;
using Traffic_Light.Model.Modes;
using Traffic_Lights.Model.Constants;
using Traffic_Lights.Model.Controllers;
using Traffic_Lights.Model.Models;

namespace Traffic_Lights.Model.Modes
{
   public class StopMode : CrossroadsMode
    {
      public StopMode(CrossroadsController crossroadsController) : base(crossroadsController)
        {
           crossroadsController.States = new List<CrossroadsStateModel>(){new CrossroadsStateModel(SignalTypes.Black, SignalTypes.Black, SignalTypes.Black, 0)};

        }
    }
}
