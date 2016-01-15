using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using TrafficLights;

namespace TrafficLightClassDiagram
{
    public class TrafficLightController : ITrafficLightControl
    {
        private Timer ChangeStateTimer;
        private int StateNumber;

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

        public TrafficLightDB TrafficLightDB
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        private void SwithMode()
        {
            throw new System.NotImplementedException();
        }

        private void IterateControllerStates()
        {
            throw new System.NotImplementedException();
        }

        private void SetState()
        {
            throw new System.NotImplementedException();
        }
    }
}