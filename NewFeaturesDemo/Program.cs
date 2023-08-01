namespace NewFeaturesDemo
{
    internal class Program
    {

        //var a=10;
        static void Main(string[] args)
        {
            Product p = new Product { ID = 111, Name = "IPhone", Price = 999999 };
            p.ID = 1;
            p.Price = 99;
            Console.WriteLine(p.ID);
            p.ID = 2;
            Console.WriteLine(p.ID);

            Item i1 = new Item(111, "IPhone", 99999);
            i1.Price = 0;


        }
    }

    class Product
    {

        public int ID { get; init; }
        public string Name { get; init; }
        public int Price { get; init; }
    }

    record Item(int ID, string Name, int Price);
}



