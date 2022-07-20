using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
// Compiler version 4.0, .NET Framework 4.5


namespace CalculatorApp
{
    public class ArithmeticEvaluator
    {

        static char[] Operators { get; } =
          {'+', '-', '/',  '*', '^' };

        public bool HasParanthesis(string expr)
        {
            expr = expr.Trim();
            return expr.StartsWith("(") && expr.EndsWith(")");
        }

        public bool HasOperators(string expr)
        {
            Regex rx = new Regex(@"[*/^+-]");
            return rx.IsMatch(expr);
        }
        public bool IsExpr(string expr)
        {
            return HasParanthesis(expr) || HasOperators(expr);
        }

        public double Eval(string expr)
        {

            expr = expr.Trim();

            if (HasParanthesis(expr))
            {
                expr = expr.Substring(1, expr.Length - 2);
                return Eval(expr);
            }

            foreach(Match match in Regex.Matches(expr, @"[(].+[)]"))
            {
                string replacedExpression = Eval(match.Value).ToString();
                expr = expr.Replace(match.Value, replacedExpression);
            }

            if (expr.Contains('+'))
            {
                string[] expressions = expr.Split('+');
                return Operate(expressions, '+');
            }

            if (expr.Contains('-'))
            {
                string[] expressions = expr.Split('-');
                return Operate(expressions, '-');
            }

            if (expr.Contains('*'))
            {
                string[] expressions = expr.Split('*');
                return Operate(expressions, '*');
            }

            if (expr.Contains('/'))
            {
                string[] expressions = expr.Split('/');
                return Operate(expressions, '/');
            }

            if (expr.Contains('^'))
            {
                string[] expressions = expr.Split('^');
                return Operate(expressions, '^');
            }

            //split string with operators 
            //and call operate() according
            return 0;
        }

        public double Operate(string[] args, char OpSymbol)
        {
            double res = 0;
            double x;

            if (OpSymbol == '+')
            {
                res = GetDoubleValue(args[0]);
                for (int i = 1; i < args.Length; i++)
                {
                    x = GetDoubleValue(args[i]);
                    res += x;
                }
                return res;
            }
            if (OpSymbol == '-')
            {
                res = GetDoubleValue(args[0]);
                for (int i = 1; i < args.Length; i++)
                {
                    x = GetDoubleValue(args[i]);
                    res -= x;
                }
                return res;
            }

            if (OpSymbol == '*')
            {
                res = GetDoubleValue(args[0], "1");
                for (int i = 1; i < args.Length; i++)
                {
                    x = GetDoubleValue(args[i], "1");
                    res *= x;
                }
                return res;
            }
            if (OpSymbol == '/')
            {
                res = GetDoubleValue(args[0], "1");
                for (int i = 1; i < args.Length; i++)
                {
                    x = GetDoubleValue(args[i], "1");
                    res /= x;
                }
                return res;
            }
            if (OpSymbol == '^')
            {
                res = GetDoubleValue(args[0], "1");
                for (int i = 1; i < args.Length; i++)
                {
                    x = GetDoubleValue(args[i], "1");
                    res = Math.Pow(res, x);
                }
                return res;
            }
            return res;
        }

        public double GetDoubleValue(string a, string baseValue = "0")
        {
            double res = 0;
            a = a.Trim();
            if (a == string.Empty || a == null)
            {
                a = baseValue;
            }
            res = IsExpr(a) ? Eval(a) : double.Parse(a);
            return res;
        }
    }
}