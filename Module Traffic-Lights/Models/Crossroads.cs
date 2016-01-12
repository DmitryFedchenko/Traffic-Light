using System;
using System.Collections.Generic;
using System.Timers;
using Traffic_Light.Model;





namespace Traffic_Lights.Model.Models
{
   
    public class Crossroads : ICrossroads
    {
        private object obj = new object();
        private Timer timer;

        protected List<ITrafficLight> TrafficLights { get; }
        public List<CrossroadsState> States;
        
        public event EventHandler TrafficLightChange;
        

        public string CrossroadsStateSelected { get; set; } = "Daytime";

        private int stateCrossroadsNumber = 0;

        public ITrafficLight CurrentChangedTraffiLight { get; set; }

        public CrossroadsManager ManagerCrossroads { get; set; }

        public void ChangeSelectedCrossroadsState(string state)
        {
            try
            {
                CrossroadsStateSelected =  state;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);               
            }
         

        }

        public void AddTrafficLight(string participan, int trafficLightId, int lampCount)
        {
               if (TrafficLights.Find(x => x.Id == trafficLightId) == null)
                 {
                    var tempTraffiLight = new TrafficLightModel(participan, trafficLightId, lampCount);
                    tempTraffiLight.ChangeTrafficLightSignal += TrafficLightModel_ChangeTrafficLightSignal;
                    TrafficLights.Add(tempTraffiLight);
                 } 
                      
        }

        private void TrafficLightModel_ChangeTrafficLightSignal(object sender, EventArgs e)
        {
            lock (obj)
            {
                CurrentChangedTraffiLight = sender as ITrafficLight;

             if (TrafficLightChange != null)
                TrafficLightChange(this,EventArgs.Empty);
            }
            
        }




        #region Change Crossroads State

        public void SetCrossroadsState(object obj, ElapsedEventArgs args)
        {
            lock (obj)
            {
                if (stateCrossroadsNumber < States.Count)
                {
                    if (States.Count > stateCrossroadsNumber)
                        ChangeCrossroadsState(States[stateCrossroadsNumber]);

                    if (States.Count > stateCrossroadsNumber)
                    {
                        int tempInterval = States[stateCrossroadsNumber].TimeWait;
                        timer.Interval = tempInterval != 0 ? tempInterval : 1;
                    }
                    ++stateCrossroadsNumber;
                }
                else
                {
                    stateCrossroadsNumber = 0;
                    timer.Stop();
                    timer.Dispose();
                    ManagerCrossroads.StartWorkTraffiLights();
                }

            }


        }
          
         public void StopIterate()
        {
            timer.Stop();
            timer.Dispose();
        }
        
        public void IterateCrossroadsStates()
        {
            lock (obj)
            {
                timer = new Timer();
                timer.AutoReset = true;
                timer.Enabled = true;
                timer.Elapsed += SetCrossroadsState;

            }

        }

        #endregion



        #region Change TrafficLight State

        public void ChangeCrossroadsState(CrossroadsState crossroadsState)
        {
             foreach (var item in crossroadsState.trafficLightStates)
            {
                SwithcSiganlTrafficLights(item.Participan, item.lampSignals, item.BlinkPeriod);
            }
                         
        }
        
        private void SwithcSiganlTrafficLights(string participan, Dictionary<int, string> lampSignals, int period)
        {
            ResetSignalTrafficLights(participan);
            SetSignalTrafficLight(participan, lampSignals, period);
        }
        
        public void SetSignalTrafficLight(string participan,Dictionary<int,string> lampSignals,int period)
        {
            List<ITrafficLight> tempTrafficLights = TrafficLights.FindAll(x => x.Participan == participan);

            foreach (var trafficlight in tempTrafficLights)
                    trafficlight.SwitchSignal(lampSignals, period);         
                
        }
  
        public void ResetSignalTrafficLights(string participan)
        {
            List<ITrafficLight> tempTrafficLights = TrafficLights.FindAll(x => x.Participan == participan);
            foreach (var trafficlight in tempTrafficLights)
                trafficlight.ResetAllSignal();
        }

        #endregion


        public Crossroads()
        {
            TrafficLights = new List<ITrafficLight>();
            States = new List<CrossroadsState>();
            ManagerCrossroads = new CrossroadsManager(this);
            

        }
        
    
            



        
    }
}