
using Traffic_Light.Model.Modes;
using Traffic_Lights.Model.Constants;
using Traffic_Lights.Model.Controllers;
using Traffic_Lights.Model.Models;

namespace Traffic_Lights.Model.Modes
{
   public class NightMode : CrossroadsMode
    {
       public NightMode(CrossroadsController crossroadsController) : base(crossroadsController)
       {
            crossroadsController.States.Add(new CrossroadsStateModel(SignalTypes.BlinkYellow, SignalTypes.BlinkYellow, SignalTypes.Black, 3500, 500));
            crossroadsController.CurrentMode = ModeTypes.Night;
        }
    }
}
