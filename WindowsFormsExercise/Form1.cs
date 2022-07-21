using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorApp
{
    public partial class Form1 : Form
    {
        private double lastResult;
        private ArithmeticEvaluator Evaluator = new ArithmeticEvaluator();
        private bool _isLastEntrySolved = false;
        public Form1()
        {
            InitializeComponent();
        }

        public void PrintLine(string str)
        {
            outputBox.Text += "" + str + Environment.NewLine;
        }

        public void Print(string str)
        {
            outputBox.Text += "" + str;
        }

        public void OpenCloseConsole()
        {
            outputBox.Visible = outputBox.Visible ? false : true;
        }

        protected double GetResult(string expr)
        {
            PrintLine($"{expr} evaluated");
            _isLastEntrySolved = true;
            return Evaluator.Eval(expr);
        }
        protected void ShowLastResult()
        {
            PrintLine($"lastResult : {lastResult}");
            ansScreen.Text = "Ans = " + lastResult.ToString();
        }
        protected void PushCharToScreen(char inputChar)
        {
            if (_isLastEntrySolved)
            {
                InputBox.Text = "";
            }
            InputBox.Text += inputChar;
            _isLastEntrySolved = false;

        }
        private void PushCharToScreen(string inputString)
        {
            InputBox.Text += inputString;
            _isLastEntrySolved = false;
        }

        private void ClearScreen()
        {
            InputBox.Text = String.Empty;
        }

        private void DeleteLastEntry()
        {
            string text = InputBox.Text;
            if (text.Length == 0)
            {
                return;
            }            
            char lastRemoved = text[text.Length - 1];
            
            InputBox.Text = text.Remove(text.Length - 1, 1);

            if(lastRemoved == ' ')
            {
                text = InputBox.Text;
                InputBox.Text = text.Remove(text.Length - 1, 1);
            }
            if (text[text.Length - 1] == ' ')
            {
                text = InputBox.Text;
                InputBox.Text = text.Remove(text.Length - 1, 1);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            PushCharToScreen('1');
        }
        private void button2_Click(object sender, EventArgs e)
        {
            PushCharToScreen('2');
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PushCharToScreen('3');
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PushCharToScreen('4');
        }

        private void button5_Click(object sender, EventArgs e)
        {
            PushCharToScreen('5');
        }

        private void button6_Click(object sender, EventArgs e)
        {
            PushCharToScreen('6');
        }

        private void button7_Click(object sender, EventArgs e)
        {
            PushCharToScreen('7');
        }

        private void button8_Click(object sender, EventArgs e)
        {
            PushCharToScreen('8');
        }

        private void button9_Click(object sender, EventArgs e)
        {
            PushCharToScreen('9');
        }

        private void buttonComma_Click(object sender, EventArgs e)
        {
            PushCharToScreen(',');
        }

        private void buttonZero_Click(object sender, EventArgs e)
        {
            PushCharToScreen('0');
        }

       

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            PushCharToScreen(" - ");
        }

        private void buttonMultiply_Click(object sender, EventArgs e)
        {
            PushCharToScreen(" * ");
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            PushCharToScreen(" + ");
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            DeleteLastEntry();
        }

        private void ButtonEqual_Click(object sender, EventArgs e)
        {
            string expressionText = InputBox.Text;

            lastResult = GetResult(expressionText);
            ShowLastResult();
            

        }

        private void buttonCA_Click(object sender, EventArgs e)
        {
            ClearScreen();
        }

        private void buttonAns_Click(object sender, EventArgs e)
        {
            PushCharToScreen(lastResult.ToString());
        }

        private void buttonDvider_Click(object sender, EventArgs e)
        {
            PushCharToScreen(" / ");
        }

        private void buttonLeftParantheses_Click(object sender, EventArgs e)
        {
            PushCharToScreen(" ( ");
        }

        private void buttonRightParantheses_Click(object sender, EventArgs e)
        {
            PushCharToScreen(" ) ");
        }

        private void buttonSqr_Click(object sender, EventArgs e)
        {
            PushCharToScreen(" ^ ");
        }

        private void buttonSQRT_Click(object sender, EventArgs e)
        {
            PushCharToScreen(" ^ (1/2)");
        }

        private void buttonConsol_Click(object sender, EventArgs e)
        {
            OpenCloseConsole();
        }

        private void InputBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            ButtonEqual_Click(sender, e);
        }
    }
}
