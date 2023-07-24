namespace MTDemo4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread t1 = new Thread(M1);
            t1.Start();
            Task tt1 = new Task(M1);
            tt1.Start();

            //Thread t2 = new Thread(M2);
            Task tt2 = new Task(() => { M2(345); });
            tt2.Start();

            Task<int> tt3 = new Task<int>(M3);
            tt3.Start();
            //sdfsddsf
            //sdfsdfsdf
            //sdfsdfsdf
            int r = tt3.Result;
            //fsdfsdf
            Task<int> tt4 = new Task<int>(() => { return M4(1); });
            tt4.Start();

            //sdfsdf
            //sdfsdf
            r = tt4.Result;
        }



        public static void M1() { }
        public static void M2(int i) { }
        public static int M3() { return 0; }
        public static int M4(int i) { return i; }
    }
}