using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RTLClass;

namespace RTLSimulatorV1._0
{
    public partial class Form6 : Form
    {

        List<string> regNamesCopy0 = new List<string>(Form3.regNames);
        List<string> regValsCopy0 = new List<string>(Form3.regVals);
        List<string> codeCopy0 = new List<string>(Form3.code);
        RTL r0;
        int counter;

        public Form6()
        {
            InitializeComponent();
            this.Cursor = Cursors.Default;
            regNamesCopy0 = new List<string>(Form3.regNames);
            regValsCopy0 = new List<string>(Form3.regVals);
            codeCopy0 = new List<string>(Form3.code);
            r0 = new RTL(regNamesCopy0, regValsCopy0, codeCopy0);
            counter = 1;
            //r0.ExecuteOneClock();
            debugTextBox.Text += "Initial value of registers:" + Environment.NewLine;
            for (int i = 0; i < regNamesCopy0.Count; i++)
            {
                debugTextBox.Text += "(" + r0.regNames[i] + ", ";// +r0.regVals[i] + ")" + Environment.NewLine;
                if (r0.regVals[i] == "True")
                    debugTextBox.Text += "true";
                else if (r0.regVals[i] == "False")
                    debugTextBox.Text += "false";
                else
                    debugTextBox.Text += r0.regVals[i];
                debugTextBox.Text += ")" + Environment.NewLine;
            }
            debugTextBox.Text += Environment.NewLine;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            r0.ExecuteOneClock();
            debugTextBox.Text += "Value of registers at the end of clock cycle " + Convert.ToString(counter) + Environment.NewLine;
            for (int i = 0; i < regNamesCopy0.Count; i++)
            {
                debugTextBox.Text += "(" + r0.regNames[i] + ", ";// +r0.regVals[i] + ")" + Environment.NewLine;
                if (r0.regVals[i] == "True")
                    debugTextBox.Text += "true";
                else if (r0.regVals[i] == "False")
                    debugTextBox.Text += "false";
                else
                    debugTextBox.Text += r0.regVals[i];
                debugTextBox.Text += ")" + Environment.NewLine;
            }
            debugTextBox.Text += Environment.NewLine;
            counter++;
            this.Cursor = Cursors.Default;

            debugTextBox.SelectionStart = debugTextBox.Text.Length;
            debugTextBox.ScrollToCaret();
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }
    }
}
