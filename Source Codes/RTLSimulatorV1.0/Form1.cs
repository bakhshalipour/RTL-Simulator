using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace RTLSimulatorV1._0
{
    public partial class RTLSimulator : Form
    {
        public RTLSimulator()
        {
            InitializeComponent();
        }

        private void RTLSimulator_Load(object sender, EventArgs e)
        {        
            //Do nothing
        }

        private void RTLSimulator_Shown(object sender, EventArgs e)
        {
            Thread.Sleep(1000);
            this.Hide();
            (new RTLSimulatorIDE()).Show();
        }
    }
}
