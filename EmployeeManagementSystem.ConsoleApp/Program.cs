using EmployeeManagementSystem.DataLayerLibrary;

namespace EmployeeManagementSystem.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Welcome to Employee Management System");

            Employee e = new Employee();
            e.Name = "Test";
            e.Salary = 1;
            e.CivilID = 1;
            e.Age = 1;
            e.Address = "address1";
            e.Experience = 1;

            IEmployeeRepository repo = new EmployeeRepository();

            repo.Save(e);
            Console.WriteLine("saved");
        }
    }
}