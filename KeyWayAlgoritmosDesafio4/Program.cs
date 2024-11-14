class Program
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine() ?? "";
        if (int.TryParse(input, out int number))
        {
            List<int> factorials = [];
            int factorial = 1, i = 1;

            while (factorial <= number)
            {
                factorials.Add(factorial);
                i++;
                factorial *= i;
            }

            int count = 0;
            int index = factorials.Count - 1;

            while (number > 0)
            {
                if (factorials[index] <= number)
                {
                    number -= factorials[index];
                    count++;
                }
                else
                {
                    index--;
                }
            }

            Console.WriteLine(count);
        }
    }
}
