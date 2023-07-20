namespace FileIODemo1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Write();

            // read all names from file and display
            StreamReader sr = new StreamReader("E:\\Demos\\Oman\\OmanBatchDemos\\FileIODemo1\\Program.cs");
            // read all lines atonce
            string allLines = sr.ReadToEnd();
            // close the stream
            sr.Close();
            Console.WriteLine(allLines);
        }

        private static void Write()
        {
            // collect name from the user and write into file
            Console.Write("Enter name: ");
            string name = Console.ReadLine();
            Console.WriteLine(name);

            StreamWriter sw = new StreamWriter("e://test//names.txt", true);
            sw.WriteLine(name);
            sw.Close();
        }
    }
}