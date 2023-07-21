using System.Diagnostics;

namespace MTDemo1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main running in thread :" + Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Running Seq...");
            Stopwatch sw = Stopwatch.StartNew();
            M1();
            M2();
            Console.WriteLine("Completed in " + sw.ElapsedMilliseconds);
            sw = Stopwatch.StartNew();

            Console.WriteLine("Running using Threads...");
            ThreadStart ts1 = new ThreadStart(M1);
            Thread t1 = new Thread(ts1);
            t1.Start();

            Thread t2 = new Thread(M2);
            t2.Start();


            t1.Join();
            t2.Join();
            Console.WriteLine("Completed in " + sw.ElapsedMilliseconds);

            sw = Stopwatch.StartNew();
            Console.WriteLine("Running using Task...");
            Task tsk1 = new Task(M1);
            tsk1.Start();
            Task tsk2 = new Task(M2);
            tsk2.Start();

            tsk1.Wait();
            tsk2.Wait();
            Console.WriteLine("Completed in " + sw.ElapsedMilliseconds);

            sw = Stopwatch.StartNew();
            Console.WriteLine("Running using Parallel...");
            Parallel.Invoke(M1, M2);
            Console.WriteLine("Completed in " + sw.ElapsedMilliseconds);

            sw = Stopwatch.StartNew();
            Console.WriteLine("Running using Parallel For...");
            Parallel.Invoke(M11, M22);
            Console.WriteLine("Completed in " + sw.ElapsedMilliseconds);
        }

        public static void M1()
        {
            Console.WriteLine("M1 running in thread :" + Thread.CurrentThread.ManagedThreadId);
            for (int i = 1; i <= 10; i++)
            {
                Thread.Sleep(500);
            }
        }
        public static void M2()
        {
            Console.WriteLine("M2 running in thread :" + Thread.CurrentThread.ManagedThreadId);
            for (int i = 1; i <= 10; i++)
            {
                Thread.Sleep(500);
            }
        }

        public static void M11()
        {
            Console.WriteLine("M11 running in thread :" + Thread.CurrentThread.ManagedThreadId);
            //for (int i = 1; i <= 10; i++)
            //Action<int> loopDelegate = new Action<int>(LoopAction);
            Parallel.For(1, 11, i =>
            {
                Thread.Sleep(500);
            });

        }

        //public static void LoopAction(int i)
        //{
        //    Thread.Sleep(500);
        //}
        public static void M22()
        {
            Console.WriteLine("M22 running in thread :" + Thread.CurrentThread.ManagedThreadId);
            //for (int i = 1; i <= 10; i++)
            Parallel.For(1, 11, i =>
            {
                Thread.Sleep(500);
            });
        }
    }
}