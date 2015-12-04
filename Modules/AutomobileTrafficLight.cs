using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Traffic_Light.Modules
{
    class AutomobileTrafficLight : ITrafficLight
    {
        static object samObg = new object();
        public string LightKey { get; set; } = "*";

        public string DefualtLightKey { get; set; } = "0";
        
        public int[] Possition { get; } = new int[6];


        public AutomobileTrafficLight(int lampTopX, int lampTopY, int lampMiddleX,int lampMiddleY, int lampBottomX, int lampBottomY)
        {
            
                Possition[0] = lampTopX;
                Possition[1] = lampTopY;
                Possition[2] = lampMiddleX;
                Possition[3] = lampMiddleY;
                Possition[4] = lampBottomX;
                Possition[5] = lampBottomY;
            
            
        }



    }
}
