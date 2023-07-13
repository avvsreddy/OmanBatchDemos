namespace OOProgrammingDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Object Initialization Syntax

            Product p1 = new Product();
            int pid = 444;
            Product p2 = new Product { ProductID = pid, Name = "IPhone" };
            Product p3 = new Product { ProductID = 333, Name = "IPhone 14", Rate = 999999 };

            Product p4 = new Product { Name = "I Phone" };

            p1.ProductID = 1;
            p1.Name = "IPhone";
            p1.Rate = 100000;
            Console.WriteLine(p1.Name);


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

        //public Product()
        //{

        //}
        //public Product(int productID)
        //{
        //    ProductID = productID;

        //}

        //public Product(int pid, string pname) : this(pid)
        //{
        //    //ProductID = pid;
        //    Name = pname;
        //}

        //public Product(int pid, string name, int rate) : this(pid, name)
        //{
        //    //ProductID = pid;
        //    //Name = name;
        //    Rate = rate;
        //}

        //public Product(int productID, string name, int rate, string model) : this(productID, name, rate)
        //{
        //    //ProductID = productID;
        //    //Name = name;
        //    //Rate = rate;
        //    Model = model;
        //}

        //public Product(int productID, string name, int rate, string model, string country) : this(productID, name, rate, model)
        //{
        //    Country = country;
        //}

        //public Product(int productID, string name, int rate, string model, string country, int year) : this(productID, name, rate, model, country)
        //{
        //    Year = year;
        //}


        public int ProductID { get; set; }
        public string Name { get; set; }
        public int Rate { get; set; }
        public string Model { get; set; }
        public string Country { get; set; }
        public int Year { get; set; }
    }
}