using Microsoft.EntityFrameworkCore;
using ProductsManagementApp.DataLayer;

namespace ProductsManagementApp.Presentation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // update all products of apple brand
            ProductsDbContext db = new DataLayer.ProductsDbContext();
            // get the products
            //var appleProducts = db.Products.Where(p => p.Brand == "Apple").ToList();
            // update the price
            //foreach (var item in appleProducts)
            //{
            //    item.Price += 1000;
            //}

            //db.SaveChanges();

            // execute raw sql statements in ef
            // DQL - select
            //db.Products.FromSql("");
            //db.Products.FromSqlRaw("select * from products where brand='Apple'");
            // DML - insert/update/delete
            db.Database.ExecuteSqlRaw("update products set price = price + 1111 where brand='Apple'");
            Console.WriteLine("done");




        }

        private static void NewMethod12()
        {
            // add new supplier
            ProductsDbContext db = new DataLayer.ProductsDbContext();
            var s = new Supplier { Name = "supplier 1", City = "city2", Email = "supp@abc.com", Mobile = "233234", Rating = 9 };
            db.Suppliers.Add(s);
            //db.People.Add(s);
            db.SaveChanges();
        }

        private static void NewMethod11()
        {
            // add new customer
            ProductsDbContext db = new DataLayer.ProductsDbContext();
            var c = new Customer { Name = "customer 1", City = "city1", CType = "silver", Discount = 10, Email = "email.com", Mobile = "234234234" };
            db.Customers.Add(c);
            db.SaveChanges();
        }

        private static void NewMethod6()
        {
            // add new supplier with two new products
            ProductsDbContext db = new DataLayer.ProductsDbContext();
            var s = new Supplier { Name = "Supplier 1", Email = "email", Mobile = "23423423", Rating = 9 };
            var cat = db.Catagories.Find(1);
            var p1 = new Product { Name = "Product 1", Brand = "brand", Price = 9999, Catagory = cat };
            var p2 = new Product { Name = "Product 2", Brand = "brand", Price = 8888, Catagory = cat };
            s.Products.Add(p1);
            s.Products.Add(p2);
            db.Suppliers.Add(s);
            db.SaveChanges();
            Console.WriteLine("done");
        }

        private static void NewMethod3()
        {
            // get product name and cat name
            ProductsDbContext db = new DataLayer.ProductsDbContext();
            var pnamecname = from p in db.Products  //.Include("Catagory")
                             select p;

            // display only pname and cname
            foreach (var item in pnamecname)
            {
                Console.WriteLine(item.Name + "\t" + item.Catagory.Name);
            }
        }

        private static void NewMethod()
        {
            // add new product with existing catagory
            ProductsDbContext db = new DataLayer.ProductsDbContext();
            // first get the existing catagory
            var cat = db.Catagories.Find(1);
            // create new product
            var p = new Product { Name = "IPhone 14", Price = 89999, Brand = "Apple", Catagory = cat };
            db.Products.Add(p);
            db.SaveChanges();
        }

        private static void NerProductWithNewCatagory()
        {
            ProductsDbContext db = new DataLayer.ProductsDbContext();

            // add new product with new catagory

            var c = new Catagory { Name = "Mobiles" };
            var p = new Product { Name = "IPhone", Brand = "Apple", Price = 9000, Catagory = c };

            db.Products.Add(p);
            //db.Catagories.Add(c);

            db.SaveChanges();
        }
    }
}