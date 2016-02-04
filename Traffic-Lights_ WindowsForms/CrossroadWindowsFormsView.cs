using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Traffic_Light.Model;

namespace Traffic_Lights__WindowsForms
{
    public partial class ControllerMainForm : Form
    {

        public ITrafficLightController trafficLightController;
      

        private CarTrafficLight roadATrafficLight;
        private CarTrafficLight roadBTrafficLight;
        private PedestrianTrafficLight pedestrianTrafficLight;

        View view;
        public ControllerMainForm()
        {
            trafficLightController = new TrafficLightController();

            InitializeComponent();

            view = new View();
            this.Controls.Add(view);

        }


        private void button1_Click(object sender, EventArgs e)
        {
            trafficLightController.StartWork();
        }
    }
}
