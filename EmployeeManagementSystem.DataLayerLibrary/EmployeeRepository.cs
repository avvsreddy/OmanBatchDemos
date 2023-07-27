using System.Data.SqlClient;

namespace EmployeeManagementSystem.DataLayerLibrary
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public void Delete(int empid)
        {
            throw new NotImplementedException();
        }

        public void Edit(int empid, Employee employee)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetAllEmployees()
        {
            throw new NotImplementedException();
        }

        public Employee GetEmployee(int empid)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetEmployeesByExperience(int experience)
        {
            throw new NotImplementedException();
        }

        public void Save(Employee employee)
        {
            // Step 1: connect to db
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=EmployeeManagementSystemDB;Integrated Security=True";


            // Step 2: Prepare SQL Insert Statement and send to db

            // SQL Injection

            //Name=';drop employees;--'

            //string sqlInsert = $"insert into employees values ('{employee.Name}',{employee.Age},{employee.Salary},{employee.Experience},{employee.CivilID},'{employee.Address}')";


            string sqlInsert = $"insert into employees values (@name,@age,@salary,@exp,@civilid,@addr)";

            SqlCommand cmd = new SqlCommand(sqlInsert, conn);

            cmd.Parameters.AddWithValue("@name", employee.Name);

            SqlParameter sqlParameter = new SqlParameter();
            sqlParameter.ParameterName = "@age";
            sqlParameter.Value = employee.Age;
            cmd.Parameters.Add(sqlParameter);

            cmd.Parameters.AddWithValue("@salary", employee.Salary);
            cmd.Parameters.AddWithValue("@exp", employee.Experience);
            cmd.Parameters.AddWithValue("@civilid", employee.CivilID);
            cmd.Parameters.AddWithValue("@addr", employee.Address);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery(); // for insert/update/delete
            }
            catch (Exception ex)
            {
                // log the errors
                throw ex;
            }
            finally
            {
                // Step 3: close db connection
                conn.Close();
            }
        }
    }
}
