using EmployeeManagementSystem.DataLayerLibrary;

namespace EmployeeManagementSystem.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Welcome to Employee Management System");
            //Save();

            EmployeeRepository repo = new EmployeeRepository();
            try
            {
                repo.Transfer(111, 222, 1000);
                Console.WriteLine("done");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }





        private static void Save()
        {
            Employee e = new Employee();
            e.Name = "New Test";
            e.Salary = 1;
            e.CivilID = 1;
            e.Age = 1;
            e.Address = "new address1";
            e.Experience = 1;

            IEmployeeRepository repo = new EmployeeRepository();

            repo.Save(e);
            Console.WriteLine("saved");
        }
    }
}