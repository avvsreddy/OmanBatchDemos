using System.Xml.Linq;

namespace LinqToXMLDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // load xml doc
            XDocument xml = XDocument.Load("XMLFile1.xml");
            //Console.WriteLine(xml);
            // extract title and display

            var titles = from b in xml.Descendants("title")
                         orderby b.Value descending
                         select b.Value;

            // display the titles
            //foreach (var item in titles)
            //{
            //    Console.WriteLine(item);
            //}

            // get all titles belongs to genre - Fantacy

            var FantacyBooks = from b in xml.Descendants("book")
                               where b.Element("genre").Value == "Fantasy"
                               select b.Element("title").Value;

            // display
            foreach (var item in FantacyBooks)
            {
                Console.WriteLine(item);
            }


        }
    }
}