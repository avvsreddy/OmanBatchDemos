using ProductsManagementApp.DataLayer;

namespace ProductsManagementApp
{
    public class Supplier : Person
    {
        //public int SupplierId { get; set; }
        //public string Name { get; set; }
        //public string Mobile { get; set; }
        //public string Email { get; set; }

        public int Rating { get; set; }

        public virtual List<Product> Products { get; set; } = new List<Product>();
    }
}