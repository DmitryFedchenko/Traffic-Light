using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traffic_Lights.Model.Constants;

namespace Traffic_Lights.Model.Models
{
    public class Lamp
    {
        public bool Light = false;
        public int Id { get; set; }
        public string Signal;

        public Lamp(int id)
        {
            Id = id;
        }
    }
}
