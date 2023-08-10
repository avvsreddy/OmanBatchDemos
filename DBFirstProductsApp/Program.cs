using DBFirstProductsApp.Entities;

namespace DBFirstProductsApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            DiamondPickDbContext db = new DiamondPickDbContext();
            Catagory c = new Catagory { CatagoryName = "New Catagory" };
            db.Catagories.Add(c);
            db.SaveChanges();

        }
    }
}