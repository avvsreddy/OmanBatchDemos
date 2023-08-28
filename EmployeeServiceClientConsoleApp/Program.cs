using System.Net.Http.Json;

namespace EmployeeServiceClientConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Getting employee by empid");
            // discover the api endpoint
            // https://localhost:44307/api/EmployeesAPI/4

            HttpClient client = new HttpClient();
            //var result = client.GetStringAsync("https://localhost:44307/api/EmployeesAPI/1").Result;
            //Console.WriteLine(result);

            var emp = client.GetFromJsonAsync<Emp>("https://localhost:44307/api/EmployeesAPI/1").Result;

            Console.WriteLine(emp.name);
            Console.WriteLine(emp.serviceNo);

        }
    }

    public class Emp
    {
        public int employeeID { get; set; }
        public string name { get; set; }
        public string mobile { get; set; }
        public string serviceNo { get; set; }
        public string address { get; set; }
    }
}