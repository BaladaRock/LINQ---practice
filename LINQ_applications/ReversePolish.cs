using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_applications
{
    public class ReversePolish
    {
        public static string CalculateExpression(string expression)
        {
            var expressionStack = new Stack<char>();

            foreach (var element in expression.Select(x => x).Where(y => y != ' '))
            {
                if (IsOperand(element))
                {
                    expressionStack.Push(element);
                }
                else
                {
                    string operands = string.Concat(expressionStack.Pop(), expressionStack.Pop());
                    char result = CalculateOperation(operands, element);
                    expressionStack.Push(result);
                }
            }

            return expressionStack.Pop().ToString();
        }

        private static char CalculateOperation(string operands, char element)
        {
            return '3';
        }

        private static bool IsOperand(char element)
        {
            return !"+-*/ ".Contains(element);
        }
    }
}