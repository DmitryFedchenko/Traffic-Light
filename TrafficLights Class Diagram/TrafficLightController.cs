using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace TrafficLights
{
    public class TrafficLightController : ITrafficLightControl
    {
        private Timer TimerChangeState;
        private Timer TimerBlinkSignal;

        public event EventHandler ChangeControllerState;

        public TrafficLight TrafficLight
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public List<TrafficLight> TrafficLights
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public List<TrafficLightControllerState> States
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public ControllerMode Mode
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public ControllerMode ControllerMode
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        private void SetState()
        {
            throw new System.NotImplementedException();
        }

        public void SwithMode()
        {
            throw new System.NotImplementedException();
        }

        public void BlinkTrafficLightSignal()
        {
            throw new System.NotImplementedException();
        }

        public void AddTrafficLight()
        {
            throw new System.NotImplementedException();
        }

        public void ResetTimerBlinkSignal()
        {
            throw new System.NotImplementedException();
        }

        public void ResetTimerChangeState()
        {
            throw new System.NotImplementedException();
        }
    }
}