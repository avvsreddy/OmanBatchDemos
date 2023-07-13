namespace ArraysDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Two-Dimensional Array
            int[,] twod = new int[4, 6];
        }

        private static void Array4()
        {
            int[] numbers = { 23, 56, 23, 65, 87, 96, 34, 75 };
            // find sum
            int sum = numbers.Sum();
            //foreach (int n in numbers)
            //{
            //    sum+= n;
            //}
            //Console.WriteLine(sum);

            // find max
            int max = numbers.Max();
            // find min
            int min = numbers.Min();
            // find avg
            double avg = numbers.Average();
            // find count
            int count = numbers.Count();

            Array.Sort(numbers);
            Array.BinarySearch(numbers, 12);
        }

        private static void ArrayDemo2()
        {
            int[] numbers = new int[5] { 1, 2, 3, 4, 5 };
            int[] numbers2 = new int[] { 1, 2, 3, 4, 5 };
            int[] numbers3 = { 1, 2, 3, 4, 5 };
        }

        private static void ArrayDemo1()
        {
            // i want to store 10 int numbers
            //int n1, n2, n3, n4;
            int[] numbers = new int[5];
            numbers[0] = 1;
            numbers[1] = 2;
            numbers[2] = 3;
            numbers[3] = 4;

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(numbers[i]);
            }

            foreach (int n in numbers)
            {
                Console.WriteLine(n);
            }
        }
    }
}