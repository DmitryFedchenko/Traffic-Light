using Traffic_Light.Model.Modes;
using Traffic_Lights.Model.Constants;
using Traffic_Lights.Model.Controllers;
using Traffic_Lights.Model.Models;

namespace Traffic_Lights.Model.Modes
{
  public  class DayTimeMode : CrossroadsMode
    {
     
        public void AddState()
        {
            crossroadsController.States.Add(new CrossroadsStateModel(SignalTypes.Green, SignalTypes.Red, SignalTypes.Red, 3000));

            crossroadsController.States.Add(new CrossroadsStateModel(SignalTypes.BlinkGreen, SignalTypes.Red, SignalTypes.Red, 2000,500));

            crossroadsController.States.Add(new CrossroadsStateModel(SignalTypes.Yellow, SignalTypes.RedAndYellow, SignalTypes.Red, 1000));

            crossroadsController.States.Add(new CrossroadsStateModel(SignalTypes.Red, SignalTypes.Green, SignalTypes.Red, 3000));

            crossroadsController.States.Add(new CrossroadsStateModel(SignalTypes.Red, SignalTypes.BlinkGreen, SignalTypes.Red, 2000,500));

            crossroadsController.States.Add(new CrossroadsStateModel(SignalTypes.Red, SignalTypes.Yellow, SignalTypes.Red, 1000));

            crossroadsController.States.Add(new CrossroadsStateModel(SignalTypes.Red, SignalTypes.Red, SignalTypes.Green, 3000));

            crossroadsController.States.Add(new CrossroadsStateModel(SignalTypes.Red, SignalTypes.Red, SignalTypes.BlinkGreen, 2000,500));

            crossroadsController.States.Add(new CrossroadsStateModel(SignalTypes.RedAndYellow, SignalTypes.Red, SignalTypes.Red, 1000));
        }

      public DayTimeMode(CrossroadsController crossroadsController) : base(crossroadsController)
      {
           AddState();
           crossroadsController.CurrentMode = ModeTypes.Daytime;
      }
    }
}
