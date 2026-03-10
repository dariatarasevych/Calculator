namespace Assignment1;

public class Calculate
{
    public double Calculator(string[] postfix)
    {
        Stack stack = new Stack();

        foreach (string token in postfix)
        {
            if (double.TryParse(token, out _)) //якщо токен число - кладемо в стек
            {
                stack.Push(token);
            }

            else
            {
                double right = double.Parse(stack.Pull());
                double left = double.Parse(stack.Pull());
                double result = 0;

                switch (token)
                {
                    case "+": result = left + right; break;
                    case "-": result = left - right; break;
                    case "*": result = left * right; break;
                    case "/": 
                        if (right == 0)
                        {
                            throw new Exception("Cannot divide by 0");
                        }
                        result = left / right; 
                        break;
                }
                
                stack.Push(result.ToString()); //покласти результат у стек і перетворити на стрінг знову
            }
        }

        return double.Parse(stack.Pull()); // останнє число дістаємо це і є відповідь
    }
}