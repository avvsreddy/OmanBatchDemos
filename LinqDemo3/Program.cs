using System.Xml.Linq;

namespace LinqDemo3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //List<string> words = new List<string>() { "one", "two", "three", "four", "five", "six" };

            // get all short words
            // Linq to Objects

            // Load XML document into memory
            XDocument xml = XDocument.Load("XMLFile1.xml");

            // Linq to XML Expression

            var shortWords = from word in xml.Descendants("word")
                             where word.Value.Length <= 3
                             select word.Value;

            // display short words
            foreach (var item in shortWords)
            {
                Console.WriteLine(item);
            }
        }
    }
}