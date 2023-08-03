namespace EFDALClassLibrary
{
    public class EmpRepo : IEmpRepo
    {
        private EmployeeDBContext db = new EmployeeDBContext();
        public void Delete(int empid)
        {
            // get the emp to delete from dbset
            var empToDel = db.Employees.Find(empid);
            // remove that obj from dbset
            db.Employees.Remove(empToDel);
            //db.Entry(empToDel).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            // save changes to database
            db.SaveChanges();
        }

        public void Edit(int empid, Employee employee)
        {
            // get the original emp to edit dbset
            //var original = db.Employees.Find(empid);
            //// transfer the modified data with original data
            //original.Name = employee.Name;
            //original.Experience = employee.Experience;
            //original.Salary = employee.Salary;

            db.Entry(employee).State = Microsoft.EntityFrameworkCore.EntityState.Modified;



            db.SaveChanges();



        }

        public List<Employee> GetAllEmployees()
        {
            //var employees = from emp in db.Employees
            //                select emp;
            //return employees.ToList();

            return db.Employees.ToList();
        }

        public Employee GetEmployee(int empid)
        {
            //var emp = from e in db.Employees
            //          where e.EmployeeID == empid
            //          select e;
            //return emp.FirstOrDefault();
            return db.Employees.Find(empid);

        }

        public List<Employee> GetEmployeesByExperience(int experience)
        {
            var emps = from e in db.Employees
                       where e.Experience == experience
                       select e;
            return emps.ToList();


            //return db.Employees.Where(e => e.Experience == experience).ToList();
        }

        public void Save(Employee employee)
        {
            db.Employees.Add(employee);
            db.SaveChanges();

        }
    }
}
