using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
// Compiler version 4.0, .NET Framework 4.5


namespace ArithmeticEvaluator
{
    public class Evaluator
    {

        public static readonly char[] Operators = { '+', '-', '/', '*', '^', '√' };

        public Func<string, bool> WrappedInParanthesis = ArithmeticExpression.WrappedInParanthesis;
        public Func<string, bool> HasOperators = ArithmeticExpression.HasOperators;
        public Func<string, bool> IsExpr = ArithmeticExpression.IsExpr;

        public ArithmaticExpressionvalidationResult ValidateExpression(string expr)
        {
            var res = new ArithmaticExpressionvalidationResult(AnyOpenParenthesis(expr), AnyConsecutiveOperator(expr));
            return res;
        }

        public bool AnyOpenParenthesis(string expr)
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

        public bool AnyConsecutiveOperator(string expr)
        {
            char prevC = ' ';
            foreach (char c in expr)
            {
                if (c == ' ')
                {
                    continue;
                }
                if (prevC == ' ')
                {
                    prevC = c;
                    continue;
                }
                if (Operators.Contains(c) && Operators.Contains(prevC))
                {
                    return true;
                }
                prevC = c;
            }
            return false;
        }

        public double Eval(string expr, double ifNullOrEmptyReturn = 0)
        {
            string defaultValue = ifNullOrEmptyReturn.ToString();
            return GetDoubleValue(expr, defaultValue);
        }
        private double GetDoubleValue(string a, string baseValue = "0")
        {
            double res = 0;
            a = a.Trim();

            if (a == string.Empty || a == null)
            {
                a = baseValue;
            }
            res = IsExpr(a) ? EvalExpression(a) : double.Parse(a);
            return res;
        }
        private double EvalExpression(string expr)
        {
            expr = expr.Trim();
            // if the whole  expression is inside a single parathesis block
            // we shall unwrap the expression
            if (WrappedInParanthesis(expr))
            {
                expr = expr.Substring(1, expr.Length - 2);
                expr = expr.Trim();
            }

            // transform expression like number() to number * () 
            foreach (Match match in Regex.Matches(expr, @"\d+\s*[(]"))
            {
                string replacedExpression = match.Value.Replace("(", "*(");
                expr = expr.Replace(match.Value, replacedExpression);
            }
            // transform expressions like )( to number )*(
            foreach (Match match in Regex.Matches(expr, @"[)]\s*[(]"))
            {
                string replacedExpression = match.Value.Replace("(", "*(");
                expr = expr.Replace(match.Value, replacedExpression);
            }

            // evaluate sub parathesis blocks first
            foreach (String parantblock in GetParanthesisBlocks(expr))
            {
                string replacedExpression = GetDoubleValue(parantblock).ToString();
                expr = expr.Replace(parantblock, replacedExpression);
            }

            //Coution evaluator reaches here after all the sub paranthesis are evaluated before

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
            try
            {
                return GetDoubleValue(expr);
            }
            catch (Exception ex)
            {
                throw new Exception("Arithmetic Expression couldn't be solved");
            }

        }

        private double CalculateSqrt(string value)
        {
            double val = GetDoubleValue(value);
            return Math.Sqrt(val);
        }

        private double Operate(string[] args, char OpSymbol)
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

        private static string[] GetParanthesisBlocks(string expr)
        {
            //returns only top level blocks
            //return expression wraped in parenthesis, (...)
            expr = expr.Trim();
            string[] result;
            int counter = 0;
            var indexStack = new Stack<int[]>();
            bool isOpenBlock = false;

            {
                int index = 0;
                int lengthOfBlock = 0;
                foreach (char c in expr)
                {
                    if (c == '(')
                    {                        
                        //open a paranthesis
                        if(counter == 0)
                        {
                            indexStack.Push(new int[2] { index, 0 });
                            isOpenBlock = true;
                            //Parenthesis is included so length of the block begins with 1
                            lengthOfBlock = 1;
                        }
                        counter++;
                    }

                    if (c == ')')
                    {
                        counter--;

                    }
                    //if counter == 0 means that there is no more open paranthesis
                    // that means the first paranthesis is closed
                    if (isOpenBlock)
                    {

                        if (counter == 0)
                        {
                            int[] lastIndexes = indexStack.Pop();
                            lastIndexes[1] = lengthOfBlock;
                            indexStack.Push(lastIndexes);
                            isOpenBlock = false;
                        }
                        lengthOfBlock++;
                    }
                    index++;
                }
            }
            if (counter != 0)
            {
                throw new Exception("Unclosed Paranthesis Problem!");
            }
            result = new string[indexStack.Count];
            {
                int i = 0;
                foreach (int[] indexes in indexStack)
                {
                    result[i] = expr.Substring(indexes[0], indexes[1]);
                    i++;
                }
            }
            return result;
        }

        public struct ArithmaticExpressionvalidationResult
        {
            public bool HasOpenParenthesis { get; set; }
            public bool HasConsecutiveOperators { get; set; }

            public ArithmaticExpressionvalidationResult(bool hasOpenParenthesis, bool hasConsecutiveOperators)
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

        private class ArithmeticExpression
        {
            public string Expression { get; } = "";

            ArithmeticExpression(string expr)
            {
                this.Expression = expr;
            }


            static ArithmeticExpression getExpression(string expr)
            {
                return new ArithmeticExpression(expr);
            }

            public static bool IsExpr(string expr)
            {
                return WrappedInParanthesis(expr) || HasOperators(expr);
            }

            public static bool WrappedInParanthesis(string expr)
            {
                expr = expr.Trim();
                bool isfirstParanthesisOpen;
                bool isfirstAndLastCharParanthesis = expr.StartsWith("(") && expr.EndsWith(")");
                int counter = 0;
                if (isfirstAndLastCharParanthesis == false)
                {
                    return false;
                }
                isfirstParanthesisOpen = true;
                foreach (char c in expr)
                {
                    //if there is more chars after first paranthesis is closed
                    if (isfirstParanthesisOpen == false)
                    {
                        return false;
                    }
                    if (c == ')')
                    {
                        counter--;

                    }
                    if (c == '(')
                    {
                        counter++;
                    }
                    //if counter == 0 means that there is no more open paranthesis
                    // that means the first paranthesis is closed
                    if (counter == 0)
                    {
                        isfirstParanthesisOpen = false;
                    }
                }
                return true;

            }

            public static bool HasOperators(string expr)
            {
                foreach (char c in expr)
                {
                    if (Operators.Contains(c))
                    {
                        return true;
                    }
                }
                return false;
            }


        }

    }


}