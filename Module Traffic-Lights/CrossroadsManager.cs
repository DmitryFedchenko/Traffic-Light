using Module_Traffic_Lights;
using System.Collections.Generic;
using Traffic_Lights.Model.Models;



namespace Traffic_Light.Model
{
   public class CrossroadsManager
    {
        

        private Crossroads crossroads;
        private XmlCrossroadsDataReader xmlReader;
        

        public CrossroadsManager(Crossroads crossroads)
        {
            xmlReader = new XmlCrossroadsDataReader();
            this.crossroads = crossroads;
                        xmlReader.ReadXMl();
            
        }

        public void StartWorkTraffiLights()
        {
              switch (crossroads.CrossroadsStateSelected)
                {

                    case "Daytime":
                        crossroads.States = xmlReader.CrossroadsModes[crossroads.CrossroadsStateSelected] ;
                        crossroads.IterateCrossroadsStates();
                        break;

                    case "Night":
                        crossroads.States = xmlReader.CrossroadsModes[crossroads.CrossroadsStateSelected];
                        crossroads.IterateCrossroadsStates();
                        break;

                    case "Stop":
                        crossroads.States = xmlReader.CrossroadsModes[crossroads.CrossroadsStateSelected];
                        crossroads.IterateCrossroadsStates();
                        break;

                    case "Exit":
                        crossroads.StopIterate();
                        break;                        
                }
          
        }
   
    }
    }



