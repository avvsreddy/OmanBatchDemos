namespace OOProgrammingDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee e = new Employee();
            e.Name = "sdsdfsd";
            e.Salary = -1000;
            Console.WriteLine(e.Salary);


            Product p1 = new Product();
            p1.ProductID = 1;
            p1.Name = "IPhone 14 Pro";
            p1.Rate = 1000;
            p1.Year = 2023;
            p1.Model = "Smart Phone";


        }
    }

    class Employee
    {
        //Employee e;
        //private string name;
        //private string lname;
        private int salary; // field

        public DateTime DOB { set; get; }

        public int DeptNo { get; set; }

        //private string backingfiled234234234234;


        public string Name // automatic properties
        {
            get;// { return backingfiled234234234234; }
            set;// { backingfiled234234234234 = value; }
        }
        public int Salary // Property
        {
            get { return salary; }
            set
            {
                if (value < 1000)
                    salary = 1000;
                else
                    salary = value;
            }
        }

    }



    class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public int Rate { get; set; }
        public string Model { get; set; }
        public string Country { get; set; }
        public int Year { get; set; }
    }
}