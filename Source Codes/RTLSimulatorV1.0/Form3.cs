using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using RTLClass;

namespace RTLSimulatorV1._0
{
    public partial class Form3 : Form
    {
        public const int MAX_REGS = 100;
        public const int MAX_LINES = 1000;
        public const int ASCII_CR = 13;
        public const int MAX_EXEC_CYCLES = 50;

        public static string[] registers = new string[MAX_REGS];
        public static string[] registerValues = new string[MAX_REGS];
        public static Dictionary<string, int> regFile = new Dictionary<string, int>();
        public static List<string> regNames;
        public static List<string> regVals;
        public static List<string> code;
        public static bool assembleError = false;
        public static string assembleErrorMessage = null;


        public void ClearAllTextBoxes()
        {
            RegTextBox.Clear();
            ValTextBox.Clear();
            TextTextBox.Clear();
        }

        public void CheckAssembleErrors()
        {
            assembleError = false;
            assembleErrorMessage = null;

            if (regNames.Count != regVals.Count)                                                    //Checking for inequal reg-value pairs
            {
                assembleError = true;
                assembleErrorMessage = "Registers field isn't matchable with Initial Values field." + Environment.NewLine;
                assembleErrorMessage += "There are " + Convert.ToString(regNames.Count) + " register";
                if (regNames.Count > 1)
                    assembleErrorMessage += "s";
                assembleErrorMessage += " and " + Convert.ToString(regVals.Count) + " value";
                if (regVals.Count > 1)
                    assembleErrorMessage += "s";
                assembleErrorMessage += "!";
                return;
            }

            if (regNames.Distinct().Count() != regNames.Count)                                      //Checking for duplicate registers
            {
                assembleError = true;
                var duplicates = regNames.GroupBy(s => s).SelectMany(grp => grp.Skip(1)).Distinct();
                assembleErrorMessage = "There are some duplicate registers: " + Environment.NewLine;
                foreach (var i in duplicates)
                    assembleErrorMessage += i + Environment.NewLine;
                return;
            }

            do                                                                                      //Checking for correctness of register name
            {
                for (int i = 0; i < regNames.Count; i++)
                {
                    if (Char.IsDigit(regNames[i][0]))
                    {
                        assembleError = true;
                        assembleErrorMessage += "Register name shouldn't be started with numeric: " + regNames[i] + Environment.NewLine;
                        return;
                    }
                }

            } while (false);

            do                                                                                      //Checking for correctness of register name
            {
                for (int i = 0; i < regNames.Count; i++)
                {
                    if (regNames[i][0] != 'r' && regNames[i][0] != 'R')
                    {
                        assembleError = true;
                        assembleErrorMessage += "Register name should start with 'r' or 'R': " + regNames[i] + Environment.NewLine;
                        return;
                    }
                }
            } while (false);

            do                                                                                      //Checking for correctness of register name
            {
                for (int i = 0; i < regNames.Count; i++)
                {
                    for (int j = 0; j < regNames.Count; j++)
                    { 
                        if (regNames[i].Contains(regNames[j]) && i != j)
                        {
                            assembleError = true;
                            assembleErrorMessage += "One register name can not be substring of others. " + regNames[j] + " is substring of " + regNames[i] + Environment.NewLine;
                            return;
                        }
                    }
                }
            } while (false);

            

            do                                                                                      //Checking for correctness of RTL code                                
            {
                List<string> tempCode = new List<string>(code);

                for (int i = 0; i < tempCode.Count; i++)
                {
                    if (tempCode[i].Split('(').Length != tempCode[i].Split(')').Length)
                    {
                        assembleError = true;
                        assembleErrorMessage = "Parenthesis error in line " + Convert.ToString(i + 1) + ".";
                        return;
                    }

                    if (tempCode[i].Split(':').Length > 2)
                    {
                        assembleError = true;
                        assembleErrorMessage = "More than one condition statement in line " + Convert.ToString(i + 1) + ".";
                        return;
                    }

                    for (int j = 0; j < regNames.Count; j++)
                        tempCode[i] = tempCode[i].Replace(regNames[j], string.Empty);

                    tempCode[i] = tempCode[i].Replace(Environment.NewLine, string.Empty);     //New Line
                    tempCode[i] = tempCode[i].Replace(":", string.Empty);                     //Condition
                    tempCode[i] = tempCode[i].Replace(",", string.Empty);                     //Comma
                    tempCode[i] = tempCode[i].Replace(" ", string.Empty);                     //Space
                    tempCode[i] = tempCode[i].Replace("!", string.Empty);                     //Not
                    tempCode[i] = tempCode[i].Replace("~", string.Empty);                     //Not
                    tempCode[i] = tempCode[i].Replace("&", string.Empty);                     //And
                    tempCode[i] = tempCode[i].Replace("|", string.Empty);                     //Or
                    tempCode[i] = tempCode[i].Replace("^", string.Empty);                     //Xor
                    tempCode[i] = tempCode[i].Replace("+", string.Empty);                     //Add
                    tempCode[i] = tempCode[i].Replace("-", string.Empty);                     //Sub
                    tempCode[i] = tempCode[i].Replace("*", string.Empty);                     //Mul
                    tempCode[i] = tempCode[i].Replace("/", string.Empty);                     //Div
                    tempCode[i] = tempCode[i].Replace("%", string.Empty);                     //Mod
                    tempCode[i] = tempCode[i].Replace("=", string.Empty);                     //Equ
                    tempCode[i] = tempCode[i].Replace(">", string.Empty);                     //Greater
                    tempCode[i] = tempCode[i].Replace("<", string.Empty);                     //Little
                    tempCode[i] = tempCode[i].Replace("(", string.Empty);                     //Parenthesis
                    tempCode[i] = tempCode[i].Replace(")", string.Empty);                     //Parenthesis
                    tempCode[i] = tempCode[i].Replace("0", string.Empty);                     //Numeric
                    tempCode[i] = tempCode[i].Replace("1", string.Empty);                     //Numeric
                    tempCode[i] = tempCode[i].Replace("2", string.Empty);                     //Numeric
                    tempCode[i] = tempCode[i].Replace("3", string.Empty);                     //Numeric
                    tempCode[i] = tempCode[i].Replace("4", string.Empty);                     //Numeric
                    tempCode[i] = tempCode[i].Replace("5", string.Empty);                     //Numeric
                    tempCode[i] = tempCode[i].Replace("6", string.Empty);                     //Numeric
                    tempCode[i] = tempCode[i].Replace("7", string.Empty);                     //Numeric
                    tempCode[i] = tempCode[i].Replace("8", string.Empty);                     //Numeric
                    tempCode[i] = tempCode[i].Replace("9", string.Empty);                     //Numeric
                    tempCode[i] = tempCode[i].Replace("true", string.Empty);                  //True
                    tempCode[i] = tempCode[i].Replace("false", string.Empty);                 //False

                    if (tempCode[i].Length != 0 && ((int)tempCode[i][0] != ASCII_CR))
                    {
                        assembleError = true;
                        assembleErrorMessage = "Error in line " + Convert.ToString(i + 1) + ":" + Environment.NewLine;
                        assembleErrorMessage += code[i];
                        assembleErrorMessage += Environment.NewLine + Environment.NewLine;
                        assembleErrorMessage += "Can not find value or functional of '" + tempCode[i] + "'.";
                        return;
                    }
                }

            } while (false);

        }

        public Form3()
        {
            InitializeComponent();
            SaveButton.Enabled = true;
            AssembleButton.Enabled = false;
            RunButton.Enabled = false;
            debugButton.Enabled = false;
        }

        private void SaveButton_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void SaveButton_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void AssembleButton_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void AssembleButton_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void RunButton_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void RunButton_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void ClearButton_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void ClearButton_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void ReturnButton_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void ReturnButton_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            AssembleButton.Enabled = false;
            RunButton.Enabled = false;
            debugButton.Enabled = false;
            ClearAllTextBoxes();
        }

        private void ReturnButton_Click(object sender, EventArgs e)
        {
            ClearAllTextBoxes();
            this.Hide();
            (new RTLSimulatorIDE()).Show();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string fileName = saveFileDialog1.FileName;
            string RTLCode = string.Empty;

            string registerNamesString = RegTextBox.Text.Replace(" ", string.Empty);
            string registerValuesString = ValTextBox.Text.Replace(" ", string.Empty);
            
            registers = registerNamesString.Split(',');
            registerValues = registerValuesString.Split(',');

            RTLCode += ".Data" + Environment.NewLine;

            RTLCode += ".Registers_Name" + Environment.NewLine;
            foreach (string i in registers)
                RTLCode += i + Environment.NewLine;
            RTLCode += ".Registers_Name_End" + Environment.NewLine;

            RTLCode += ".Registers_Value" + Environment.NewLine;
            foreach (string i in registerValues)
                RTLCode += i + Environment.NewLine;
            RTLCode += ".Registers_Value_End" + Environment.NewLine;

            RTLCode += ".Data_End" + Environment.NewLine;

            RTLCode += ".Text" + Environment.NewLine;

            while (TextTextBox.Text.Contains(Environment.NewLine + Environment.NewLine))
                TextTextBox.Text = TextTextBox.Text.Replace(Environment.NewLine + Environment.NewLine, Environment.NewLine);

            if (TextTextBox.Text.EndsWith(Environment.NewLine))
            {
                string tempString = TextTextBox.Text;
                tempString = tempString.Substring(0, tempString.Length - 1);
                TextTextBox.Text = tempString;
            }

            RTLCode += TextTextBox.Text;

            RTLCode += Environment.NewLine + ".Text_End";

            File.WriteAllText(fileName, RTLCode);

            RegTextBox.Clear();
            for (int i = 0; i < registers.Length - 1; i++)
                RegTextBox.Text += registers[i] + ", ";
            RegTextBox.Text += registers[registers.Length - 1];

            ValTextBox.Clear();
            for (int i = 0; i < registerValues.Length - 1; i++)
                ValTextBox.Text += registerValues[i] + ", ";
            ValTextBox.Text += registerValues[registerValues.Length - 1];

            while (TextTextBox.Text.Contains(Environment.NewLine + Environment.NewLine))
                TextTextBox.Text = TextTextBox.Text.Replace(Environment.NewLine + Environment.NewLine, Environment.NewLine);

            AssembleButton.Enabled = true;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void RegTextBox_TextChanged(object sender, EventArgs e)
        {
            AssembleButton.Enabled = RunButton.Enabled = false;
            debugButton.Enabled = false;
        }

        private void ValTextBox_TextChanged(object sender, EventArgs e)
        {
            AssembleButton.Enabled = RunButton.Enabled = false;
            debugButton.Enabled = false;
        }

        private void TextTextBox_TextChanged(object sender, EventArgs e)
        {
            AssembleButton.Enabled = RunButton.Enabled = false;
            debugButton.Enabled = false;
        }

        private void AssembleButton_Click(object sender, EventArgs e)
        {
            regNames = (RegTextBox.Text.Replace(" ", string.Empty).Split(',')).ToList();
            regVals = (ValTextBox.Text.Replace(" ", string.Empty).Split(',')).ToList();
            code = (TextTextBox.Text.Replace(" ", string.Empty).Split('\n')).ToList();

            CheckAssembleErrors();

            if (assembleError)
            {
                Form4 myForm4 = new Form4();
                myForm4.Show();
                myForm4.textBox1.Text = assembleErrorMessage;
                RunButton.Enabled = false;
                debugButton.Enabled = false;
            }
            else
            {
                RunButton.Enabled = true;
                debugButton.Enabled = true;
                MessageBox.Show("RTL Design assembled successfully.", "Assembling ...", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void RunButton_Click(object sender, EventArgs e)
        {
            List<string> regNamesCopy0 = new List<string>(regNames);
            List<string> regValsCopy0 = new List<string>(regVals);
            List<string> codeCopy0 = new List<string>(code);

            RTL r0 = new RTL(regNamesCopy0, regValsCopy0, codeCopy0);

            int loopCounter = 0;

            Form5 myForm5 = new Form5();
            myForm5.Show();
            myForm5.Cursor = Cursors.WaitCursor;
            myForm5.resultTextBox.Text = null;
            myForm5.resultTextBox.Text += "> Running ..." + Environment.NewLine;

            myForm5.resultTextBox.SelectionStart = myForm5.resultTextBox.Text.Length;
            myForm5.resultTextBox.ScrollToCaret();

            while (!r0.simulationEnd && loopCounter < MAX_EXEC_CYCLES)
            {
                r0.ExecuteOneClock();
                loopCounter++;
            }

            if (!r0.simulationEnd)
                MessageBox.Show("Your design has exeeceded maximum cycles of execution. Software can simulate at max 50 cycles of execution.", "Run-Time Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            myForm5.resultTextBox.Text += "> Simulation has been ended at clock cycle: " + Convert.ToString(loopCounter - 1) + Environment.NewLine;
            myForm5.resultTextBox.Text += "> Final value of registers:" + Environment.NewLine;

            for (int i = 0; i < r0.regNames.Count; i++)
            {
                myForm5.resultTextBox.Text += "(" + r0.regNames[i] + ", ";
                if (r0.regVals[i] == "True")
                    myForm5.resultTextBox.Text += "true";
                else if (r0.regVals[i] == "False")
                    myForm5.resultTextBox.Text += "false";
                else myForm5.resultTextBox.Text += r0.regVals[i];
                myForm5.resultTextBox.Text += ")" + Environment.NewLine;
            }

            myForm5.Cursor = Cursors.Default;

            myForm5.resultTextBox.Text += "> End of result" + Environment.NewLine;

            myForm5.resultTextBox.SelectionStart = myForm5.resultTextBox.Text.Length;
            myForm5.resultTextBox.ScrollToCaret();

            RunButton.Enabled = false;
            debugButton.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Form6 myForm6 = new Form6();
            myForm6.Show();
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }
    }
}
