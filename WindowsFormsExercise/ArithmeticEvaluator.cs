using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
// Compiler version 4.0, .NET Framework 4.5


namespace CalculatorApp
{
    public class ArithmeticEvaluator
    {

        static char[] _operators = {'+', '-', '/',  '*', '^' };

        public bool WrappedInParanthesis(string expr)
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
            return WrappedInParanthesis(expr) || HasOperators(expr);
        }

        public ArithmaticExpressionvalidationStatus ValidateExpression(string expr)
        {
            var res = new ArithmaticExpressionvalidationStatus(anyOpenParenthesis(expr), anyConsecutiveOperator(expr));
            return res;
        }

        public bool anyOpenParenthesis(string expr)
        {
            int openParenthesis = 0;
            foreach (char c in expr)
            {
                if (c == '(')
                {
                    openParenthesis++;
                }
                if (c == ')')
                {
                    openParenthesis--;
                }
            }

            return openParenthesis != 0;
        }

        public bool anyConsecutiveOperator(string expr)
        {
            char prevC = ' ';
            foreach (char c in expr)
            {
                if (prevC == ' ')
                {
                    prevC = c;
                    continue;
                }
                if(_operators.Contains(c) && _operators.Contains(prevC) )
                {
                    return true;
                }
                prevC = c;
            }
            return false;
        }

        public double Eval(string expr)
        {
            expr = expr.Trim();

            if (WrappedInParanthesis(expr))
            {
                expr = expr.Substring(1, expr.Length - 2);
                return Eval(expr);
            }
            foreach (Match match in Regex.Matches(expr, @"\d+\s*[(]"))
            {
                string replacedExpression = match.Value.Replace("(", "*(");
                expr = expr.Replace(match.Value, replacedExpression);
            }
            foreach (Match match in Regex.Matches(expr, @"[(].+[)]"))
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

            if (expr.StartsWith("√"))
            {
                string value = expr.Substring(1);
                return CalculateSqrt(value);
            }
            throw new InvalidOperationException("Artihmetic expression couldn't be parsed");
        }

        public double CalculateSqrt(string value)
        {
            double val = GetDoubleValue(value);
            return Math.Sqrt(val);
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

        public struct ArithmaticExpressionvalidationStatus
        {
            public bool HasOpenParenthesis { get; set; }
            public bool HasConsecutiveOperators { get; set; }

            public ArithmaticExpressionvalidationStatus(bool hasOpenParenthesis, bool hasConsecutiveOperators)
            {
                this.HasOpenParenthesis = hasOpenParenthesis;
                this.HasConsecutiveOperators = hasConsecutiveOperators;
            }
            public bool IsValid()
            {
                return !HasOpenParenthesis && !HasConsecutiveOperators;
            }
            public override string ToString() =>
                $"Expression {(HasOpenParenthesis ? "has open paranthesis, " : string.Empty)}" +
                $"{(HasConsecutiveOperators ? "has consecutive operators" : string.Empty)}";
        }
    }
}