using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Traffic_Light.Modules
{
    class CrossroadsView
    {
       

        public void DrawCrossroads()
        {
            Console.WriteLine("                                                               ");
            Console.WriteLine("                                                               ");
            Console.WriteLine("                  _  |               |  _                      ");
            Console.WriteLine("                 |0| |## ## ## ## ## | |0|                     ");
            Console.WriteLine("                 |0| |## ## ## ## ## | |0|                     ");
            Console.WriteLine("       _ _           |## ## ## ## ## |           _ _           ");
            Console.WriteLine("      |0|0|          |     _____     |          |0|0|          ");
            Console.WriteLine("      _______________|    |0|0|0|    |__________________       ");
            Console.WriteLine("       ######      _                    _      ######          ");
            Console.WriteLine("       ######     |0|                  |0|     ######          ");
            Console.WriteLine("       ######     |0|                  |0|     ######          ");
            Console.WriteLine("       ######     |0|      _____       |0|     ######          ");
            Console.WriteLine("      _______________     |0|0|0|     ___________________      ");
            Console.WriteLine("       _ _        _  |               |  _        _ _           ");
            Console.WriteLine("      |0|0|      |0| |## ## ## ## ## | |0|      |0|0|          ");
            Console.WriteLine("                 |0| |## ## ## ## ## | |0|                     ");
            Console.WriteLine("                     |## ## ## ## ## |                         ");
            Console.WriteLine("                     |               |                         ");
            Console.WriteLine("                     |               |                         ");
            Console.WriteLine("                     |               |                         ");
            Console.WriteLine(" \n\nTo select a mode of day, click on the: 'd',\n for night: 'n'\n and for the stop work: 's'.");
        }

        
    }
}
