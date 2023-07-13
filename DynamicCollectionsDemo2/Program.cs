namespace DynamicCollectionsDemo2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            // 1. Untyped dynamic collection
            // 2. Typed dynamic collection

            // want to store n process many ints
            List<int> ints = new List<int>();

            // add data
            ints.Add(1);
            ints.Add(2);
            ints.Add(3);

            // read
            int n = ints[0];

            // count
            int c = ints.Count;

            // mathematical 
            int sum = ints.Sum();

            ints.Sort();

            // stack declaration
            Stack<int> stack = new Stack<int>();
            // add
            stack.Push(100);
            // read
            int x = stack.Peek(); // gets top element
            x = stack.Pop(); // gets top element and removes from stack

            // Queue

            Queue<int> q = new Queue<int>();
            q.Enqueue(100); // add data
            // read and removes
            q.Dequeue();
            // only read
            q.Peek();


            // want to store student id with result
            Dictionary<int, string> results = new Dictionary<int, string>();
            // add
            results.Add(111, "Pass");
            results.Add(222, "Fail");
            //results.Add(111, "Fail");

            // read
            string result = results[111];
        }
    }
}