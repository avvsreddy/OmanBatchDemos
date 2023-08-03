namespace EFDALClassLibrary
{
    public interface IEmpRepo
    {
        void Save(Employee employee);
        void Delete(int empid);

        Employee GetEmployee(int empid);
        List<Employee> GetAllEmployees();

        List<Employee> GetEmployeesByExperience(int experience);

        void Edit(int empid, Employee employee);



    }
}
