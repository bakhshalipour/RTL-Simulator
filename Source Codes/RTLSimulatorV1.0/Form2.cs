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
using System.Diagnostics;
using System.IO;

namespace RTLSimulatorV1._0
{
    public partial class RTLSimulatorIDE : Form
    {
        public RTLSimulatorIDE()
        {
            InitializeComponent();
        }

        private void New_Button_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void New_Button_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void New_Button_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new Form3()).Show();
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string locationToSavePdf = Path.Combine(Path.GetTempPath(), "TestTutorial.pdf");
            File.WriteAllBytes(locationToSavePdf, Properties.Resources.TestTutorial);
            Process.Start(locationToSavePdf);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string fileName = openFileDialog1.FileName;
            List<string> inputFileLines = new List<string>();

            using (StreamReader sr = File.OpenText(fileName))
            {
                string input = null;
                while ((input = sr.ReadLine()) != null)
                {
                    inputFileLines.Add(input);
                }   
            }

            this.Hide();
            Form3 myForm3 = new Form3();
            myForm3.Show();

            int startRegisterNameIndex = inputFileLines.IndexOf(".Registers_Name") + 1;
            int endRegisterNameIndex = inputFileLines.IndexOf(".Registers_Name_End");
            int startRegisterValueIndex = inputFileLines.IndexOf(".Registers_Value") + 1;
            int endRegisterValueIndex = inputFileLines.IndexOf(".Registers_Value_End");
            int startRTLTextIndex = inputFileLines.IndexOf(".Text") + 1;
            int endRTLTextIndex = inputFileLines.IndexOf(".Text_End");

            for (int i = startRegisterNameIndex; i < endRegisterNameIndex - 1; i++)
            {
                myForm3.RegTextBox.Text += inputFileLines[i];
                myForm3.RegTextBox.Text += ", ";
            }
            myForm3.RegTextBox.Text += inputFileLines[endRegisterNameIndex - 1];

            for (int i = startRegisterValueIndex; i < endRegisterValueIndex - 1; i++)
            {
                myForm3.ValTextBox.Text += inputFileLines[i];
                myForm3.ValTextBox.Text += ", ";
            }
            myForm3.ValTextBox.Text += inputFileLines[endRegisterValueIndex - 1];

            for (int i = startRTLTextIndex; i < endRTLTextIndex - 1; i++)
            {
                if (inputFileLines[i] != string.Empty)
                {
                    myForm3.TextTextBox.Text += inputFileLines[i];
                    myForm3.TextTextBox.Text += Environment.NewLine;
                }
            }

            myForm3.TextTextBox.Text += inputFileLines[endRTLTextIndex - 1];
            if (myForm3.TextTextBox.Text.EndsWith(Environment.NewLine))
            {
                string tempString = myForm3.TextTextBox.Text;
                tempString = tempString.Substring(0, tempString.Length - 1);
                myForm3.TextTextBox.Text = tempString;
            }

            myForm3.AssembleButton.Enabled = true;
        }
    }
}
