using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Traffic_Light.Modules
{
    class AutoTrafficLight : ITrafficLight
    {
        public State State { get; set; }
        public AutoTrafficLight( State currentState)
        {
            State = currentState;
        }

        private string[] colors = {"Green", "Red", "Yellow"};

        
        public void Start()
        {
            Console.Clear();
            Console.WriteLine(colors[0] + " !");
            Thread.Sleep(3000);
            Console.Clear();
            for (int i = 0; i < 2; i++)
            {
                Console.Clear();
                Thread.Sleep(500);
                Console.WriteLine("Gren!");
                Thread.Sleep(500);
                Console.Clear();


            }
        }

        public void Stop()
        {
            Console.Clear();
            Console.WriteLine(colors[1] + " !");
            Thread.Sleep(3000);
           
        }

        public void Prepare()
        {
           
            Console.WriteLine(colors[2] + " !");
            Thread.Sleep(2000);
            Console.Clear();
        }
        public void SwithSignal()
        {
            
        }

        public void Work()
        {
            while (true)
            {
                if(State == State.RedOnly)
                Stop();

                if(State == State.RedAndYellow)
                Prepare();

                if(State == State.GreenOnly)
                Start();

                if(State == State.RedOnly)
                Prepare();
               
            }
           
        }
    }
}
