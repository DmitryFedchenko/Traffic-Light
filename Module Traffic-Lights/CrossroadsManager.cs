using Module_Traffic_Lights;
using System.Collections.Generic;

using Traffic_Lights.Model.Constants;

using Traffic_Lights.Model.Models;



namespace Traffic_Light.Model
{
   public class CrossroadsManager
    {
        object obj = new object();

        protected CrossroadsModel crossroads;
        public XmlCrossroadsDataReader xmlReader;
        

        public CrossroadsManager(CrossroadsModel crossroads)
        {
            xmlReader = new XmlCrossroadsDataReader();
            this.crossroads = crossroads;
                        xmlReader.ReadXMl();
            
        }

        public void StartWork()
        {
            lock (obj)
            {
                switch (crossroads.CrossroadsStateSelected)
                {

                    case CrossroadsStateTypes.Daytime:
                        crossroads.States = xmlReader.controllerModes[CrossroadsStateTypes.Daytime] ;
                        crossroads.IterateCrossroadsStates();
                        break;

                    case CrossroadsStateTypes.Night:
                        crossroads.States = xmlReader.controllerModes[CrossroadsStateTypes.Night];
                        crossroads.IterateCrossroadsStates();
                        break;

                    case CrossroadsStateTypes.Stop:
                        crossroads.States = xmlReader.controllerModes[CrossroadsStateTypes.Stop];
                        crossroads.IterateCrossroadsStates();
                        break;

                    case CrossroadsStateTypes.Exit:
                        crossroads.StopIterate();
                        break;
                        
                }
            }
        }
   
    }
    }



