namespace Assignment1;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter expression:");
        string input = Console.ReadLine()!;

        var tokens = Tokenization.Tokenize(input);
        
        ShuntingYard shuntingYard = new ShuntingYard();
        string[] postfix = shuntingYard.Postfix(tokens);

        Calculate calculate = new Calculate();
        double result = calculate.Calculator(postfix);
        
        Console.WriteLine($"Result: {result}");
    }
}