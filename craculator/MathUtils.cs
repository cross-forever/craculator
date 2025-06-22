using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craculator
{
    public static class MathUtils
    {
        // https://www.geeksforgeeks.org/parsing-string-of-symbols-to-expression/
        public static int Evaluate(string expression)
        {
            // Create a stack to hold operands
            Stack<int> operands = new Stack<int>();

            // Create a stack to hold operators
            Stack<char> operators = new Stack<char>();

            for (int i = 0; i < expression.Length; i++)
            {
                char ch = expression[i];

                // If the current character is a whitespace,
                // skip it
                if (ch == ' ')
                {
                    continue;
                }

                // If the current character is a digit, push it
                // to the operand stack
                if (Char.IsDigit(ch))
                {
                    int num = 0;
                    while (i < expression.Length
                           && Char.IsDigit(expression[i]))
                    {
                        num = num * 10
                          + (int)Char.GetNumericValue(
                          expression[i]);
                        i++;
                    }
                    i--;
                    operands.Push(num);
                }

                // If the current character is an operator, push
                // it to the operator stack
                else if (ch == '+' || ch == '-' || ch == '*'
                         || ch == '/')
                {
                    while (operators.Count > 0
                           && hasPrecedence(ch,
                                            operators.Peek()))
                    {
                        operands.Push(applyOperation(
                          operators.Pop(), operands.Pop(),
                          operands.Pop()));
                    }
                    operators.Push(ch);
                }
            }

            while (operators.Count > 0)
            {
                operands.Push(applyOperation(operators.Pop(),
                                             operands.Pop(),
                                             operands.Pop()));
            }

            return operands.Pop();
        }

        public static bool hasPrecedence(char op1, char op2)
        {
            if ((op1 == '*' || op1 == '/')
                && (op2 == '+' || op2 == '-'))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static int applyOperation(char op, int b, int a)
        {
            switch (op)
            {
                case '+':
                    return a + b;
                case '-':
                    return a - b;
                case '*':
                    return a * b;
                case '/':
                    if (b == 0)
                    {
                        throw new InvalidOperationException(
                          "Cannot divide by zero");
                    }
                    return a / b;
            }
            return 0;
        }
    }
}
