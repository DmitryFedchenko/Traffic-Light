using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traffic_Light
{
    public class LampCordinate
    {
        public int X { get; set; }
        public int Y { get; set; }

        public LampCordinate(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
