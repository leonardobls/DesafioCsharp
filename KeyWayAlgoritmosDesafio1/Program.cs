internal class Program
{
    static void Main(string[] args)
    {
        string input;

        while ((input = Console.ReadLine()) != null)
        {
            int numberOfActivities = VerifyIfIsANumber(input);

            List<int> activities = [];

            int i = 0;

            while (true)
            {
                input = Console.ReadLine() ?? "";
                int number = VerifyIfIsANumber(input);

                if (number != 0)
                    activities.Add(number);

                if (i >= numberOfActivities - 1)
                    break;

                i++;
            }

            int totalSum = activities.Sum();
            int leftSum = 0;
            int rightSum = totalSum;

            int minDifference = int.MaxValue;

            foreach (int a in activities)
            {
                leftSum += a;
                rightSum -= a;

                int currentDifference = Math.Abs(leftSum - rightSum);
                minDifference = Math.Min(minDifference, currentDifference);
            }

            Console.WriteLine(minDifference);
        }
    }

    static int VerifyIfIsANumber(string input)
    {
        if (int.TryParse(input, out int number))
            return number;
        else
        {
            Console.WriteLine("Os valores inseridos precisam ser inteiros!\n");
            return 0;
        }
    }
}