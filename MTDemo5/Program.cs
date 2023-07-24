namespace MTDemo5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // i want to store 5M numbers
            LargeData ld = new LargeData();
            //ld.Fill(); // fills 5M numbers
            //ld.Fill(); // fills 5M numbers
            Parallel.Invoke(ld.Fill, ld.Fill);
            //Thread t1 = new Thread(ld.Fill);
            //t1.Start();
            //Thread t2 = new Thread(ld.Fill);
            //t2.Start();
            //t1.Join();
            //t2.Join();
            Console.WriteLine("Filled :" + ld.Data.Count);
        }
    }

    class LargeData
    {
        //public Stack<int> Data = new Stack<int>();
        //System.Collections.Generic.Stack<int> Data = new Stack<int>();
        public System.Collections.Concurrent.ConcurrentStack<int> Data = new System.Collections.Concurrent.ConcurrentStack<int>();
        //[MethodImpl(MethodImplOptions.Synchronized)]
        public void Fill()
        {
            for (int i = 1; i <= 5000000; i++)
            {
                //Monitor.Enter(this);
                //lock (this)
                //{
                Data.Push(i); // hot-spots / critical section
                //}
                //Monitor.Exit(this);
            }
        }

    }
}