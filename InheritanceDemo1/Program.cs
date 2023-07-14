namespace InheritanceDemo1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Inheritance Demo");
        }
    }

    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Country { get; set; }
    }

    class Customer : Person
    {


        public int CustType { get; set; }
    }

    class Employee : Person
    {
        public int Salary { get; set; }
    }
}