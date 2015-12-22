using Traffic_Light.Modules;

namespace Traffic_Light
{
    public class CrossroadsController
    {
       
        public CrossroadsMode Mode { get; set; }
        protected Crossroads crossroads;
       
     
       public void SetCrossroadsState(CrossroadsState crossroadsState)
        {
          crossroads.ChangeCurrentState(crossroadsState);
   
        }

        public CrossroadsController(Crossroads crossroads)
        {
            this.crossroads = crossroads;
            Mode = new CrossroadsMode(this);

        }



    }
}
