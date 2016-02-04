using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Traffic_Lights__WindowsForms
{
    public partial class View : UserControl
    {
        List<TrafficLightView> viewTrafficLights;

        public void Add(TrafficLightView trafficLight)
        {
            viewTrafficLights.Add(trafficLight);
        }
        public View()
        {

            InitializeComponent();

            viewTrafficLights = new List<TrafficLightView>();
           

            Add(new CarTraffiicLightView());
          
        }

        private void View_Paint(object sender, PaintEventArgs e)
        {
            foreach (var trafficLight in viewTrafficLights)
                e.Graphics.DrawImage(trafficLight.CurrentImage, new Point(trafficLight.X, trafficLight.Y));
            
        }
    }
}
