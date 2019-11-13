using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_applications
{
    public class ReversePolish
    {
        public static double CalculateExpression(string expression)
        {
            const int ToSkip = 2;

            ThrowNull(expression);
            IEnumerable<string> sum = expression.Split();

            return sum.Aggregate(
                   Enumerable.Empty<double>(),
                   (operands, current) => IsOperator(current)
                      ? UpdateSum(operands, current, ToSkip)
                      : operands.Append(Convert.ToDouble(current)))
                  .First();
        }

        private static IEnumerable<double> UpdateSum(IEnumerable<double> operands, string current, int skip)
        {
            return operands.SkipLast(skip)
                .Append(ApplyOperator(
                    operands.TakeLast(skip),
                    current));
        }

        private static double ApplyOperator(IEnumerable<double> operands, string @operator)
        {
            double firstOperand = operands.First();
            double secondOperand = operands.Last();

            switch (@operator)
            {
                case "+":
                    return firstOperand + secondOperand;

                case "-":
                    return firstOperand - secondOperand;

                case "*":
                    return firstOperand * secondOperand;

                default:
                    return firstOperand / secondOperand;
            }
        }

        private static bool IsOperator(string element)
        {
            return "+-*/".Contains(element);
        }

        private static void ThrowNull(string expression)
        {
            if (expression != null)
            {
                return;
            }

            throw new ArgumentNullException(nameof(expression));
        }
    }
}