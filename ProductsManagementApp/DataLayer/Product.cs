namespace ProductsManagementApp.DataLayer
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        public string Brand { get; set; }
        public virtual Catagory Catagory { get; set; } // for lazy loading

        public virtual List<Supplier> Suppliers { get; set; } = new List<Supplier>();
    }

    public class Catagory
    {
        public int CatagoryID { get; set; }
        public string Name { get; set; }

        public virtual List<Product> Products { get; set; } = new List<Product>();
    }


    abstract public class Person
    {
        public int PersonID { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
    }

    public class Customer : Person
    {
        public string CType { get; set; }
        public int Discount { get; set; }
    }
}



