using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace EmployeeManagementSystem.DataLayerLibrary
{
    public class EmployeeRepository : IEmployeeRepository
    {

        public bool Transfer(int facc, int tacc, int amt)
        {
            bool isDone = true;
            IDbConnection conn = GetConnection();
            IDbCommand cmd1 = conn.CreateCommand();
            IDbCommand cmd2 = conn.CreateCommand();

            cmd1.Connection = conn;
            cmd1.CommandText = $"update accounts set balance = balance - {amt} where accno = {facc}";
            cmd2.Connection = conn;
            cmd2.CommandText = $"update accounts set balance = balance + {amt} where accno = {tacc}";

            conn.Open();
            IDbTransaction tx = conn.BeginTransaction();
            cmd1.Transaction = tx;
            cmd2.Transaction = tx;
            try
            {
                cmd1.ExecuteNonQuery();
                throw new Exception("Server error...try later");
                cmd2.ExecuteNonQuery();
                tx.Commit();
            }
            catch (Exception ex)
            {
                tx.Rollback();
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return isDone;
        }


        public void Delete(int empid)
        {
            // get connection
            IDbConnection conn = GetConnection();
            // get the command
            IDbCommand cmd = conn.CreateCommand();
            cmd.Connection = conn;
            cmd.CommandText = "delete employees where empid = @eid";

            IDbDataParameter p1 = cmd.CreateParameter();
            p1.ParameterName = "@eid";
            p1.Value = empid;
            cmd.Parameters.Add(p1);
            cmd.ExecuteNonQuery();
            conn.Close();

        }

        public void Edit(int empid, Employee employee)
        {
            // get connection
            IDbConnection conn = GetConnection();
            IDbCommand cmd = conn.CreateCommand();
            cmd.Connection = conn;
            cmd.CommandText = "update employees set name=@name,age=@age,salary=@sal,experience=@exp,civilid=@civilid,address=@addr where empid=@empid";

            IDbDataParameter p1 = cmd.CreateParameter();
            p1.ParameterName = "@name";
            p1.Value = employee.Name;
            cmd.Parameters.Add(p1);

            //cmd.Parameters.AddWithValue("@name", employee.Name);

            IDbDataParameter p2 = cmd.CreateParameter();
            p2.ParameterName = "@age";
            p2.Value = employee.Age;
            cmd.Parameters.Add(p2);

            //cmd.Parameters.AddWithValue("@salary", employee.Salary);
            IDbDataParameter p3 = cmd.CreateParameter();
            p3.ParameterName = "@sal";
            p3.Value = employee.Salary;
            cmd.Parameters.Add(p3);

            //cmd.Parameters.AddWithValue("@exp", employee.Experience);
            IDbDataParameter p4 = cmd.CreateParameter();
            p4.ParameterName = "@exp";
            p4.Value = employee.Experience;
            cmd.Parameters.Add(p4);

            //cmd.Parameters.AddWithValue("@civilid", employee.CivilID);
            IDbDataParameter p5 = cmd.CreateParameter();
            p5.ParameterName = "@civilid";
            p5.Value = employee.CivilID;
            cmd.Parameters.Add(p5);

            //cmd.Parameters.AddWithValue("@addr", employee.Address);
            IDbDataParameter p6 = cmd.CreateParameter();
            p6.ParameterName = "@addr";
            p6.Value = employee.Address;
            cmd.Parameters.Add(p6);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();


        }

        public List<Employee> GetAllEmployees()
        {
            // get connection
            IDbConnection conn = GetConnection();
            // get command
            IDbCommand cmd = conn.CreateCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from employees";
            List<Employee> list = new List<Employee>();
            conn.Open();
            using (conn)
            {
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Employee e = new();
                    e.EmpID = (int)reader[0];
                    e.Name = reader[1].ToString();
                    e.Age = reader.GetInt32(2);
                    e.Salary = (int)reader["salary"];
                    e.Experience = reader.GetInt32(4);
                    e.CivilID = reader.GetInt32(5);
                    e.Address = reader.GetString(6);
                    list.Add(e);
                }
                reader.Close();
            }
            //conn.Close();
            return list;
        }

        public Employee GetEmployee(int empid)
        {
            // get connection
            IDbConnection conn = GetConnection();
            // get command
            IDbCommand cmd = conn.CreateCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from employees where empid=@eid";

            IDbDataParameter p1 = cmd.CreateParameter();
            p1.ParameterName = "@eid";
            p1.Value = empid;
            cmd.Parameters.Add(p1);

            conn.Open();
            IDataReader reader = cmd.ExecuteReader();

            reader.Read();
            Employee e = new();
            e.EmpID = (int)reader[0];
            e.Name = reader[1].ToString();
            e.Age = reader.GetInt32(2);
            e.Salary = (int)reader["salary"];
            e.Experience = reader.GetInt32(4);
            e.CivilID = reader.GetInt32(5);
            e.Address = reader.GetString(6);
            reader.Close();
            conn.Close();
            return e;
        }

        public List<Employee> GetEmployeesByExperience(int experience)
        {
            // get connection
            IDbConnection conn = GetConnection();
            // get command
            IDbCommand cmd = conn.CreateCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from employees where Experience = @exp";

            IDbDataParameter p1 = cmd.CreateParameter();
            p1.ParameterName = "@exp";
            p1.Value = experience;
            cmd.Parameters.Add(p1);

            List<Employee> list = new List<Employee>();
            conn.Open();
            using (conn)
            {
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Employee e = new();
                    e.EmpID = (int)reader[0];
                    e.Name = reader[1].ToString();
                    e.Age = reader.GetInt32(2);
                    e.Salary = (int)reader["salary"];
                    e.Experience = reader.GetInt32(4);
                    e.CivilID = reader.GetInt32(5);
                    e.Address = reader.GetString(6);
                    list.Add(e);
                }
                reader.Close();
            }
            //conn.Close();
            return list;
        }

        public void Save(Employee employee)
        {
            IDbConnection conn = GetConnection();


            // Step 2: Prepare SQL Insert Statement and send to db

            // SQL Injection

            //Name=';drop employees;--'

            //string sqlInsert = $"insert into employees values ('{employee.Name}',{employee.Age},{employee.Salary},{employee.Experience},{employee.CivilID},'{employee.Address}')";


            string sqlInsert = $"insert into employees values (@name,@age,@salary,@exp,@civilid,@addr)";

            //SqlCommand cmd = new SqlCommand(sqlInsert, conn);
            IDbCommand cmd = conn.CreateCommand();
            cmd.Connection = conn;
            cmd.CommandText = sqlInsert;

            IDbDataParameter p1 = cmd.CreateParameter();
            p1.ParameterName = "@name";
            p1.Value = employee.Name;
            cmd.Parameters.Add(p1);

            //cmd.Parameters.AddWithValue("@name", employee.Name);

            IDbDataParameter p2 = cmd.CreateParameter();
            p2.ParameterName = "@age";
            p2.Value = employee.Age;
            cmd.Parameters.Add(p2);

            //cmd.Parameters.AddWithValue("@salary", employee.Salary);
            IDbDataParameter p3 = cmd.CreateParameter();
            p3.ParameterName = "@salary";
            p3.Value = employee.Salary;
            cmd.Parameters.Add(p3);

            //cmd.Parameters.AddWithValue("@exp", employee.Experience);
            IDbDataParameter p4 = cmd.CreateParameter();
            p4.ParameterName = "@exp";
            p4.Value = employee.Experience;
            cmd.Parameters.Add(p4);

            //cmd.Parameters.AddWithValue("@civilid", employee.CivilID);
            IDbDataParameter p5 = cmd.CreateParameter();
            p5.ParameterName = "@civilid";
            p5.Value = employee.CivilID;
            cmd.Parameters.Add(p5);

            //cmd.Parameters.AddWithValue("@addr", employee.Address);
            IDbDataParameter p6 = cmd.CreateParameter();
            p6.ParameterName = "@addr";
            p6.Value = employee.Address;
            cmd.Parameters.Add(p6);
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

        private static IDbConnection GetConnection()
        {
            // Step 1: connect to db
            // get the db connection from factory
            string providerName = ConfigurationManager.ConnectionStrings["constr"].ProviderName;

            DbProviderFactories.RegisterFactory(providerName, SqlClientFactory.Instance);
            //DbProviderFactories.RegisterFactory(providerName, DbProviderFactory);

            DbProviderFactory providerFactory = DbProviderFactories.GetFactory(providerName);

            IDbConnection conn = providerFactory.CreateConnection();
            //SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            return conn;
        }
    }
}
