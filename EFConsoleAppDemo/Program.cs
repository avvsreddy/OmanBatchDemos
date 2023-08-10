using EFDALClassLibrary;

namespace EFConsoleAppDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EmpRepo repo = new EmpRepo();
            EmployeeDBContext db = new EmployeeDBContext();
            // get all emp;

            //var emps = from e in db.Employees
            //           where e.Salary >= 60000
            //           select e;




            var emplist = repo.GetAllEmployees();
            foreach (var item in emplist)
            {
                Console.WriteLine(item.Name);
            }

        }

        private static void Save()
        {
            // save emp data
            Employee e = new Employee { Name = "Employee 3", Experience = 7, Salary = 700000 };
            EmpRepo repo = new EmpRepo();
            repo.Save(e);
            Console.WriteLine("emp saved");
        }
    }
}