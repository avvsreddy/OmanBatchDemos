using System.Data;

namespace EmployeeManagementSystem.DataLayerLibrary
{
    public interface IEmployeeRepository
    {
        void Save(Employee employee);
        void Delete(int empid);

        Employee GetEmployee(int empid);
        List<Employee> GetAllEmployees();

        List<Employee> GetEmployeesByExperience(int experience);

        void Edit(int empid, Employee employee);

        DataSet GetAllEmployeesDisconnected();
        void Update(DataSet ds);

    }
}
