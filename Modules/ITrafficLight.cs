﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traffic_Light.Modules
{
     interface ITrafficLight
     {
         string LightKey { get; set; }
         string DefualtLightKey { get; set; }
         int[] Possition { get; } 
        
     }
}
