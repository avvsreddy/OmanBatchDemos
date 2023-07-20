using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace FileSerializationDemo
{
    public class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Hello, World!");
            //Product p = new Product { Name = "IPhone 14 Pro", ProductID = 1, Description = "The most expensive phone" };
            // save the proudct into file
            FileStream stream = File.OpenRead("products.xml");
            XmlSerializer xml = new XmlSerializer(typeof(Product));
            Product p = (Product)xml.Deserialize(stream);
            stream.Close();
            Console.WriteLine(p.Name);
        }

        private static void XmlSerialize()
        {
            Console.WriteLine("Hello, World!");
            Product p = new Product { Name = "IPhone 14 Pro", ProductID = 1, Description = "The most expensive phone" };
            // save the proudct into file
            FileStream stream = File.Create("products.xml");
            XmlSerializer xml = new XmlSerializer(typeof(Product));
            xml.Serialize(stream, p);
            stream.Close();
        }

        private static void Deseriallize()
        {
            Console.WriteLine("Hello, World!");
            //Product p = new Product { Name = "IPhone 14 Pro", ProductID = 1, Description = "The most expensive phone" };
            // save the proudct into file
            FileStream stream = File.OpenRead("products.dat");
            BinaryFormatter binary = new BinaryFormatter();
            Product p = (Product)binary.Deserialize(stream);
            stream.Close();
            Console.WriteLine(p.Name);
        }

        private static void Serialize()
        {
            Console.WriteLine("Hello, World!");
            Product p = new Product { Name = "IPhone 14 Pro", ProductID = 1, Description = "The most expensive phone" };
            // save the proudct into file
            FileStream stream = File.Create("products.dat");
            BinaryFormatter binary = new BinaryFormatter();
            binary.Serialize(stream, p);
            stream.Close();
        }
    }

    [Serializable]
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}