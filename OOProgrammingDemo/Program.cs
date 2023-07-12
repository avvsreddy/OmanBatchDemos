namespace OOProgrammingDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            // object instatiation
            Employee e = new Employee();
            int a;
            a = 10;
            e.name = "venkat";
            e.salary = 500000;
        }
    }

    class Employee
    {
        //Employee e;
        public string name;
        public int salary;
    }
}