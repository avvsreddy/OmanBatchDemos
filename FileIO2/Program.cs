namespace FileIO2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("List All Drives");

            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (var drive in drives)
            {
                Console.WriteLine($"{drive.Name}\tSize:\t{drive.TotalSize}");

            }

            Console.WriteLine("List all files in a given folder");

            string[] files = Directory.GetFiles("E:\\Demos");
            foreach (var file in files)
            {
                Console.WriteLine(file);
            }



        }
    }
}