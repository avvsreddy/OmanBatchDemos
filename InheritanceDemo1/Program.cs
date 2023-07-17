namespace InheritanceDemo1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Inheritance Demo");

            // to access all person functionality
            Person p = new Person();

            Customer c = new Customer();


        }
    }

    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Country { get; set; }

        //    public Person(string name, int age, string email, string mobile, string country)
        //    {
        //        Name = name;
        //        Age = age;
        //        Email = email;
        //        Mobile = mobile;
        //        Country = country;
        //    }
        //}

        class Customer : Person
        {

            public int CustType { get; set; }
        }

        class RegCustomer : Customer
        {
            public int Discount { get; set; }
        }
        class Employee : Person
        {
            public int Salary { get; set; }
        }
    }