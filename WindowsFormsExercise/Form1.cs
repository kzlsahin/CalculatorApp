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
        private int _openParanthesis;
        public ArithmeticEvaluator Evaluator = new ArithmeticEvaluator();
        private bool _isLastEntrySolved = false;
        public Form1()
        {
            InitializeComponent();
        }

        public void PrintLine(string str)
        {
            consolBox.Text += "" + str + Environment.NewLine;
        }

        public void Print(string str)
        {
            consolBox.Text += "" + str;
        }
        public void FocusOnInput()
        {
            InputBox.Focus();
        }
        public void OpenCloseConsole()
        {
            consolBox.Visible = consolBox.Visible ? false : true;
        }

        protected void NotifyOpenParanthesis()
        {
            ansScreen.Text = "close the paranthesis";
        }
        protected double GetResult(string expr)
        {
            try
            {
                var validationStatus = Evaluator.ValidateExpression(expr);
                if (validationStatus.IsValid() == false)
                {
                    PrintLine(validationStatus.ToString());
                    throw new ArgumentException("Expression syntax is not valid.");
                }
                lastResult = Evaluator.Eval(expr);

                PrintLine($"{expr} evaluated");

                _isLastEntrySolved = true;
            }
            catch (Exception ex)
            {
                PrintLine(ex.Message);
            }
            return lastResult;
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
                InputBox.Text = lastResult.ToString();
            }
            InputBox.Text += inputChar;
            _isLastEntrySolved = false;
            ansScreen.Focus();


        }
        private void PushCharToScreen(string inputString)
        {
            if (_isLastEntrySolved)
            {
                InputBox.Text = lastResult.ToString();
            }
            InputBox.Text += inputString;
            _isLastEntrySolved = false;
            ansScreen.Focus();

        }

        private void ClearScreen()
        {

            InputBox.Text = String.Empty;

        }

        private void NextExpression()
        {
            string expressionText = InputBox.Text;

            if (Evaluator.anyOpenParenthesis(expressionText))
            {
                NotifyOpenParanthesis();
                return;
            }
            else
            {
                lastResult = GetResult(expressionText);
                ShowLastResult();
            }
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

            if (lastRemoved == ' ')
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

        private void ButtonValue_Click(Object sender, EventArgs e)
        {
            PushCharToScreen(((Button)sender).Text);

        }

        private void ButtonOperator_Click(Object sender, EventArgs e)
        {
            if (_isLastEntrySolved)
            {
                PushCharToScreen(lastResult.ToString());
            }
            PushCharToScreen($" {((Button)sender).Text} ");
        }

        private void ButtonCompoundOperator_Click(Object sender, EventArgs e)
        {
            Button button;
            try
            {
                button = (Button)sender;
            }
            catch (Exception ex)
            {
                PrintLine(ex.Message);
                PrintLine("Button event called by non-button controller");
                return;
            }
            if (_isLastEntrySolved)
            {
                PushCharToScreen(lastResult.ToString());
            }

            if (button.Tag == "sqr")
            {
                PushCharToScreen(" ^ ");
            }

            if (button.Tag == "sqrt")
            {
                PrintLine(button.Text);
                PrintLine("?X");
                PrintLine($" {(char)8730}");
                PushCharToScreen($" {(char)8730}");
            }

        }

        private void ButtonEqual_Click(object sender, EventArgs e)
        {
            NextExpression();            
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            DeleteLastEntry();
        }



        private void buttonCA_Click(object sender, EventArgs e)
        {
            ClearScreen();
        }

        private void buttonAns_Click(object sender, EventArgs e)
        {
            PushCharToScreen(lastResult.ToString());
        }

        private void InputBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                NextExpression();
                return;
            }
            if (e.KeyCode == Keys.Back)
            {
                DeleteLastEntry();
                return;
            }


        }

        private void InputBox_KeyPress(object sender, KeyPressEventArgs e)
        {

            //if decimal entry
            char keyChar;

            if ((int)e.KeyChar >= 96 && (int)e.KeyChar <= 105)
            {
                int a = e.KeyChar - 96 + 48;
                keyChar = (char)a;
            }
            else
            {
                keyChar = e.KeyChar;
            }
            if (keyChar >= '0' && keyChar <= '9')
            {
                PushCharToScreen(keyChar);
                e.Handled = true;
                return;
            }

            //if entry is a symbol
            string op = String.Empty;
            switch (e.KeyChar)
            {
                case '+':
                    op = " + ";
                    break;
                case '-':
                    op = " - ";
                    break;
                case '*':
                    op = " * ";
                    break;
                case '/':
                    op = " / ";
                    break;
                case '(':
                    op = " ( ";
                    break;
                case ')':
                    op = " ) ";
                    break;
                case '^':
                    op = " ^ ";
                    break;
                case '.':
                    op = ".";
                    break;

            }
            if (op != String.Empty)
            {
                PushCharToScreen(op);
            }
            e.Handled = true;

        }
        private void buttonConsol_Click(object sender, EventArgs e)
        {
            OpenCloseConsole();
        }

    }
}
