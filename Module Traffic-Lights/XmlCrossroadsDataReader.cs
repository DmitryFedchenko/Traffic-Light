using Module_Traffic_Lights.Models;
using System.Collections.Generic;
using System.Xml.Linq;
using Traffic_Lights.Model.Models;


namespace Module_Traffic_Lights
{
    public class XmlCrossroadsDataReader
    {

        public Dictionary<string, List<CrossroadsState>> CrossroadsModes;

        public XmlCrossroadsDataReader()
        {
            CrossroadsModes = new Dictionary<string, List<CrossroadsState>>();
        }
        public void ReadXMl()
        {
            string fileName = "../../AppData/XMLTrafficLightStates.xml";
           
            XDocument doc = XDocument.Load(fileName);



            // Crossroads mode
            foreach (XElement tempCrossroadsMode in doc.Root.Elements())
            {
                string crossroadsStateName = tempCrossroadsMode.Attribute("name").Value;
                var crossroadsStates = new List<CrossroadsState>();

                //State
                foreach (XElement state in tempCrossroadsMode.Elements())
                {
                    var tempCrossroadsState = new CrossroadsState();
                    tempCrossroadsState.Id = int.Parse(state.Attribute("id").Value.Trim());
                    tempCrossroadsState.TimeWait = int.Parse(state.Attribute("time").Value.Trim());


                    //traffick light
                    foreach (XElement trafficLight in state.Elements())
                    {
                        var tempTrafficLight = new TrafficLightState();

                        tempTrafficLight.BlinkPeriod = int.Parse(trafficLight.Attribute("period").Value.Trim());

                        tempTrafficLight.Participan = trafficLight.Attribute("participan").Value.Trim();



                        //Lamp
                        foreach (XElement lamp in trafficLight.Elements())
                        {
                            int lampId = int.Parse(lamp.Attribute("id").Value.Trim());
                            string lampSignal =  lamp.Value.Trim();
                            tempTrafficLight.lampSignals.Add(lampId, lampSignal);
                        }

                        tempCrossroadsState.AddtrafficLightState(tempTrafficLight);
                    }
                    crossroadsStates.Add(tempCrossroadsState);
                }

                CrossroadsModes.Add(crossroadsStateName, crossroadsStates);
            }

        }

    }
}
