using System.Numerics;

namespace Assignment1;

public class ShuntingYard
{
    public string[] Postfix(string[] tokens)
    {
        string[] outputPostfix = new string[tokens.Length];
        int outputIndex = 0; //counter елементів в масиві
        Stack opStack = new Stack();

        int i = 0;
        while (i < tokens.Length)
        {
            string token = tokens[i];
            i++;

            if (int.TryParse(token, out _))
            {
                outputPostfix[outputIndex] = token;
                outputIndex++;
            }
            else if (IsOperator(token))
            {
                while (!opStack.IsEmpty())
                {
                    string topElement = opStack.Peek();
                    if (topElement == "(")
                    {
                        break;
                    }

                    if (GetPrecedence(topElement) >= GetPrecedence(token))
                    {
                        outputPostfix[outputIndex] = opStack.Pull();
                        outputIndex++;
                    }
                    else
                    {
                        break;
                    }
                }

                opStack.Push(token);
            }

            else if (token == "(")
            {
                opStack.Push(token);
            }

            else if (token == ")")
            {
                while (!opStack.IsEmpty() && opStack.Peek() != "(")
                {
                    outputPostfix[outputIndex++] = opStack.Pull();
                }
                if (!opStack.IsEmpty() && opStack.Peek() == "(")
                {
                    opStack.Pull(); // видалити цю віжкриту дужку з стеку
                }
            }
        }


        while (!opStack.IsEmpty())
        {
            outputPostfix[outputIndex] = opStack.Pull();
            outputIndex++;
        }

        string[] result = new string[outputIndex];
        Array.Copy(outputPostfix, result, outputIndex); //1. звідки копіюємо, 2. куди копіюємо, 3. скільки елементів
        return result;
    }
    private bool IsOperator(string token)
    {
        return token == "+" ||
               token == "-" ||
               token == "*" ||
               token == "/" ||
               token == "^";
    }
    
    private int GetPrecedence(string op)
    {
        if (op == "+" || op == "-")
        {
            return 1;
        }
        if (op == "*" || op == "/")
        {
            return 2;
        }
        if (op == "^")
        {
            return 3;
        }
        return 0;
    }
}