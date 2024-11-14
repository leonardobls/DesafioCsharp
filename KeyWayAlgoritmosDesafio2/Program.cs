internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Insira os 2 valores: \n");
        string input = Console.ReadLine() ?? "";

        string[] values = input.Split(" ");

        int firstNumber = 0, secondNumber = 0;

        if ((values.Length < 2 || values.Length > 2) || !(int.TryParse(values[0], out firstNumber)) || !(int.TryParse(values[1], out secondNumber)))
            Console.WriteLine("É necessário inserir 2 números, nada a mais, nada a menos!");
        Environment.Exit(0);

        double pointOfEnd = firstNumber % secondNumber;


        Console.WriteLine($"{pointOfEnd}\n");
    }
}