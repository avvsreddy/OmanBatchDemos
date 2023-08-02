namespace LinqToObjectsDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1. get all product names and display
            var pnames = from p in ProductsDB.GetProducts()
                         select p.Name;
            // 2. Get all product names and brand and display

            // sql: select name,brand from products
            var namebrand = from p in ProductsDB.GetProducts()
                            select new NameBrand { Name = p.Name, Brand = p.Brand };


            // 3. Get all product names, price and brand and display
            // using anonymous types to hold the result
            var name_price_brand = from p in ProductsDB.GetProducts()
                                   select new { Name = p.Name, Price = p.Price, Brand = p.Brand };

            // 4. Get all product name,cost and catagory name
            var name_price_catname = from p in ProductsDB.GetProducts()
                                     select new
                                     {
                                         Name = p.Name,
                                         Cost = p.Price,
                                         CatName = p.Catagory.CatagoryName
                                     };

            // 5. Get total worth of all products

            var totAmt = (from p in ProductsDB.GetProducts()
                          select p.Price).Sum();
            totAmt = ProductsDB.GetProducts().Sum(p => p.Price);

            // 6. Get total worth of all mobiles

            totAmt = (from p in ProductsDB.GetProducts()
                      where p.Catagory.CatagoryName == "Mobiles"
                      select p.Price).Sum();

            totAmt = ProductsDB.GetProducts().Where(p => p.Catagory.CatagoryName == "Mobiles").Sum(p => p.Price);

            // 7. get the first product name
            var first = ProductsDB.GetProducts().First();


            // display
            foreach (var item in name_price_catname)
            {
                Console.WriteLine(item.Name + "\t" + item.Cost + "\t" + item.CatName);
            }
        }
    }

    class NameBrand
    {
        public string Name { get; set; }

        public string Brand { get; set; }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Brand { get; set; }
        public Catagory Catagory { get; set; }
    }
    public class Catagory
    {
        public int CatagoryID { get; set; }
        public string CatagoryName { get; set; }
    }

    public static class ProductsDB
    {
        public static List<Product> GetProducts()
        {

            List<Product> products = new List<Product>();
            Catagory c1 = new Catagory { CatagoryID = 111, CatagoryName = "Mobiles" };
            Catagory c2 = new Catagory { CatagoryID = 222, CatagoryName = "Laptops" };
            Catagory c3 = new Catagory { CatagoryID = 333, CatagoryName = "Smart Watches" };

            Product p1 = new Product { Id = 1, Name = "IPhone", Price = 79999, Brand = "Apple", Catagory = c1 };
            Product p2 = new Product { Id = 2, Name = "Galaxy S20", Price = 50000, Brand = "Samsung", Catagory = c1 };
            Product p3 = new Product { Id = 3, Name = "Dell XPS 13", Price = 54000, Brand = "Dell", Catagory = c2 };
            Product p4 = new Product { Id = 4, Name = "IWathch 10", Price = 43000, Brand = "Apple", Catagory = c3 };

            products.Add(p1);
            products.Add(p2);
            products.Add(p3);
            products.Add(p4);

            return products;
        }
    }
}