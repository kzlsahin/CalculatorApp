using ArithmeticEvaluator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorApp
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        static Form1 FormApp;
        static Action<string> PrintLine;
        static Action<string> Print;
        static ArithmeticEvaluator.Evaluator evaluator = new ArithmeticEvaluator.Evaluator();
        [STAThread]
        static void Main()
        {
            //    [DllImport("kernel32.dll")]
            //    static extern bool AttachConsole(int dwProcessId);
            //private const int ATTACH_PARENT_PROCESS = -1;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FormApp = new Form1();
            PrintLine = FormApp.PrintLine;
            Print = FormApp.Print;

            string[] testExpressions_1 = { "24 + 3", "0 + 0", "0 + 1", "+ 2", "2 + ", "5 - 2", "2 - 8", "5 + 11 - 3", "2*5 + 3 - 9", "-10 + 5", "5 - 6 + 10 / 2", "4 - 2 - 5", "4 - 4 - 3" };
            double[] testResults_1 = { 24 + 3, 0 + 0, 0 + 1, 2, 2, 5 - 2, 2 - 8, 5 + 11 - 3, 2 * 5 + 3 - 9, -10 + 5, 5 - 6 + 5, 4 - 2 - 5, 4 - 4 - 3 };
            string[] testExpressions_2 = { "2 * 3", "1 * 2", "* 2", "4 / 2", "5 * 3 * 4", "0 * 2 ", "0*2", "1*4", "5*5", "5^2", "5^0", "(4 + 2) / 2", "(4 + 2)/2", "4 ^ ( -2)" };
            double[] testResults_2 = { 6, 2, 2, 2, 60, 0, 0, 4, 25, 25, 1, 3, 3, 2 };
            string[] testExpressions_3 = {"(5)", "1 - 2 * (5 + 12 / 4)","(2 + 2 * (3 - 1))", "16^(1/2) * 2", "((5 + 6/2) + 2 * 3) + 9 - 22 / 2 * 3", "(3+2)*(2)" };
            double[] testResults_3 = {5, (1 - 2 * (5 + 12 / 4)), 6, 8, (((5 + 6 / 2) + 2 * 3) + 9 - 22 / 2 * 3), 10 };

            int countFailed = 0;

            for (int i = 0; i < testExpressions_1.Length; i++)
            {
                if (!TestAritma(testExpressions_1[i], testResults_1[i])) countFailed++;
            }
            for (int i = 0; i < testExpressions_2.Length; i++)
            {
                if (!TestAritma(testExpressions_2[i], testResults_2[i])) countFailed++;
            }
            for (int i = 0; i < testExpressions_3.Length; i++)
            {
                if (!TestAritma(testExpressions_3[i], testResults_3[i])) countFailed++;
            }

            PrintLine($"number of failed tests : {countFailed}");



            Application.Run(FormApp);

        }

        public static bool TestAritma(string expr, double expected)
        {
            string message;
            double result;
            PrintLine(" ");
            Print("test expr: " + expr);
            Print("   expected: " + expected);

            try
            {
                result = Evaluator.Eval(expr);
                bool res = expected == result;

                PrintLine($"  result: {result}");

                if (res)
                {
                    PrintLine($"   Passed");
                }
                else
                {
                    PrintLine($"   Failed");
                }
                return res;
            }
            catch(Exception ex) {
                message = ex.Message;
                PrintLine($"Exception!! {message}");
                return false;
            }
           
        }
    }
}
