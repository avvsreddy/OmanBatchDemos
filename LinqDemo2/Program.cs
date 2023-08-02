namespace LinqDemo2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            var evens = (from number in numbers
                         where IsEven(number) //number % 2 == 0
                         select number);//.ToList();

            //numbers.Add(10);

            //foreach (var item in evens)
            //{
            //    Console.WriteLine(item);
            //}
            Console.WriteLine("Done");
        }

        public static bool IsEven(int n)
        {
            Console.WriteLine("IsEven called");
            return n % 2 == 0;
        }
    }
}