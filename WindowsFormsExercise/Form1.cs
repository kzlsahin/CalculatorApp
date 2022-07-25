using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ArithmeticEvaluator;
using System.Globalization;

namespace CalculatorApp
{
    public partial class Form1 : Form
    {
        public NumberFormatInfo NFI = NumberFormatInfo.CurrentInfo;
        private double lastResult;
        private int _openParanthesis;
        //private ArithmeticEvaluator.Evaluator evaluator = new ArithmeticEvaluator.Evaluator();
        string _decimalSeperator;
        private bool _isLastEntrySolved = false;
        private bool _errorShown = false;
        private string _lastExpression = "";
        public Form1()
        {
            InitializeComponent();
            buttonSQRT.Text = "\u221aX";
            _decimalSeperator = NFI.NumberDecimalSeparator;
            buttonDot.Text = _decimalSeperator;
            PrintLine("\n\r Number Decimal Seperator: " + _decimalSeperator);
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
            if (consolBox.Size.Height == 67)
            {
                consolBox.Size = new Size(492, 350);
            }
            else
            {
                consolBox.Size = new Size(492, 67);
            }
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
                    _isLastEntrySolved = false;
                    throw new ArgumentException("Expression syntax is not valid.");
                }
                lastResult = Evaluator.Eval(expr);

                PrintLine($"0,11 evaluated");
                PrintLine(_decimalSeperator);
                PrintLine((double.Parse("0,11") * 10).ToString());
                _isLastEntrySolved = true;
                _lastExpression = expr;
            }
            catch (Exception ex)
            {
                PrintLine(ex.Message);
            }
            return lastResult;
        }
        protected void ShowLastResult()
        {
            if (_isLastEntrySolved)
            {
                PrintLine($"lastResult : {lastResult}");
                ansScreen.Text = "Ans = " + lastResult.ToString();
            }
            else
            {
                ansScreen.Text = "expression couldn't be resolved";
                _errorShown = true;
            }

        }
        protected void PushToInputScreen(char inputChar)
        {
            if (_isLastEntrySolved)
            {
                //if first input is binary operator add last answer first
                if (Evaluator.Operators.IsBinaryOperator(inputChar))
                {
                    InputBox.Text = lastResult.ToString();
                }
                else
                {
                    InputBox.Text = String.Empty;
                }
                _isLastEntrySolved = false;
            }
            InputBox.Text += inputChar;
            ansScreen.Focus();

            if (_errorShown) ansScreen.Text = String.Empty;
        }

        private void PushToInputScreen(string inputString)
        {
            bool isBinaryOperator = false;
            if (inputString.Trim().Length == 1)
            {
                //if first input is binary operator add last answer first
                isBinaryOperator = Evaluator.Operators.IsBinaryOperator(inputString.Trim()[0]);
                bool isOperator = Evaluator.Operators.IsOperator(inputString.Trim()[0]);
                PrintLine($"is binary operator: {isBinaryOperator}  input: {inputString} isLastEntrySolve= {_isLastEntrySolved}");
                PrintLine($"is operator: {isOperator}  input: {inputString} isLastEntrySolve= {_isLastEntrySolved}");
            }
            if (_isLastEntrySolved)
            {
                if (isBinaryOperator)
                {
                    InputBox.Text = lastResult.ToString();
                }
                else
                {
                    InputBox.Text = String.Empty;

                }
                _isLastEntrySolved = false;
            }
            InputBox.Text += inputString;
            ansScreen.Focus();

            if (_errorShown) ansScreen.Text = String.Empty;
        }

        private void ClearScreen()
        {

            InputBox.Text = String.Empty;

        }

        private void NextExpression()
        {
            string expressionText = InputBox.Text;

            if (Evaluator.AnyOpenParenthesis(expressionText))
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
            PushToInputScreen(((Button)sender).Text);

        }

        private void ButtonOperator_Click(Object sender, EventArgs e)
        {
            PushToInputScreen($" {((Button)sender).Text} ");
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

            if (button.Tag == "sqr")
            {
                PushToInputScreen(" ^ ");
            }

            if (button.Tag == "sqrt")
            {
                PrintLine(button.Text);
                PrintLine("?X");
                PrintLine($" {(char)8730}");
                PushToInputScreen($" {(char)8730}");
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
            PushToInputScreen(lastResult.ToString());
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
                PushToInputScreen(keyChar);
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
                PushToInputScreen(op);
            }
            e.Handled = true;

        }
        private void buttonConsol_Click(object sender, EventArgs e)
        {
            OpenCloseConsole();
        }

        private void ButtonLastEntry_Click(object sender, EventArgs e)
        {
            InputBox.Text = _lastExpression;
        }
    }
}
