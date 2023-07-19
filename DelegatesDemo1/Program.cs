namespace DelegatesDemo1
{


    //class MyDelegate : Delegate
    //{

    //}

    // Step 1: Delegate Declaration
    public delegate void MyDelegate(string str);
    public delegate void OtherDelegate();


    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
            // 1. Method name : Greeting
            // 2. Signature : void Greeting(string str)
            // 3. class name : Program
            // 4. type : instance / static
            // 5. namespace: DelegatesDemo1
            // 6. Assembly : Project/DelegatesDemo1.exe
            // 7. Access Specifier: public/protected/private


            // Direct method invocation
            //Greeting("Direct - Hello World!");

            // Indirect method invocation
            //Delegate d = new Delegate();
            // Step 2: Instantiate delegate and initialize
            MyDelegate d = new MyDelegate(Greeting);
            Program p = new Program();
            d += p.Hello; // subscription
            d -= Greeting; // unsubscribe
            //d += SomeMethod;

            OtherDelegate od = new OtherDelegate(SomeMethod);

            // STep 3: invoke
            //d.Invoke("Hello from delegate");
            d("....from delegate");

            SomeMethod();
            od();
            Greeting("hi");
        }

        static void Greeting(string text)
        {
            Console.WriteLine($"Greeting: {text}");
        }

        public void Hello(string msg)
        {
            Console.WriteLine("Hello :" + msg);
        }

        public static void SomeMethod()
        {
            Console.WriteLine("Some Method");
        }
    }
}