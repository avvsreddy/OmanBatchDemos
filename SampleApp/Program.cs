namespace SampleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // accept two int numbers and find the sum - console app

            // Step 1: variable declarations
            int fno;
            int sno;
            int sum = 0;

            // Step 2: accept the input
            Console.Write("Enter First Number:");
            fno = int.Parse(Console.ReadLine());
            Console.Write("Enter Second Number:");
            sno = int.Parse(Console.ReadLine());

            // Step 3: find the sum
            sum = fno + sno;

            // Step 4: Display the result
            Console.WriteLine($"The sum of {fno} and {sno} is {sum}");


        }
    }
}