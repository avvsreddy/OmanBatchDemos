namespace LinqDemo1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Linq To Objects Demos

            //List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            // extract all even numbers and store in a separate list and display

            // table:numbers
            // column: number
            // sql select: select number from numbers where number mod 2 = 0;

            // linq to objects way
            //var evenNumbers1 = from n in numbers
            //                 where n % 2 == 0
            //               select n; // linq expression
            //string[] colors = { "green", "brown", "blue", "red" };
            //var c = colors.OrderBy(c => c.Length).Single();
            //Console.WriteLine(c);

            string[] colors = { "green", "brown", "blue", "red" };
            var query = from c in colors
                        where c.Length == colors.Max(cc => cc.Length)
                        select c;

            foreach (var element in query)
                Console.WriteLine(element);

            //Func<int,bool> filter = new Func<int,bool>(IsEven);

            //var evenNumbers2 = numbers.Where(filter);

            //var evenNumbers3 = numbers.Where(n => n % 2 == 0);

            //foreach (var item in evenNumbers1)
            //{
            //    Console.WriteLine(item);
            //}
            // Traditional way
            //List<int> evens = new List<int>();
            //foreach (var number in numbers)
            //{
            //    if (number % 2 == 0)
            //        evens.Add(number);
            //}
            //// display
            //foreach (var item in evens)
            //{
            //    Console.WriteLine(item);
            //}
        }

        //public static bool IsEven(int n)
        //{
        //    return n % 2 == 0;
        //}
    }
}