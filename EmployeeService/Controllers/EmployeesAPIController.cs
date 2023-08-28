using EmployeeService.Models.Data;
using EmployeeService.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesAPIController : ControllerBase
    {
        private readonly EmployeeDbContext db;


        public EmployeesAPIController(EmployeeDbContext db)
        {
            this.db = db;
        }
        // add endpoints - action methods
        // design the endpoints url

        // purpose: return list of employees
        // url:GET https://omanemployeeservice.gov/employeesapi

        // GET POST PUT DELETE ......
        [HttpGet]
        public List<Employee> Get()
        {
            return db.Employees.ToList();
        }


        // purpose return employee by id
        //URL- GET api/employeesapi/1
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetEmployeeById(int id)
        {
            var emp = db.Employees.Find(id);
            if (emp == null)
            {
                // 404 not found
                return NotFound();
            }

            // 200 with data
            return Ok(emp);
        }

        // purpose return employee by service no
        //URL- GET api/employeesapi/serviceno/1
        [HttpGet]
        [Route("serviceno/{sno}")]
        public IActionResult GetEmployeeByService(string sno)
        {
            var emp = db.Employees.Where(e => e.ServiceNo == sno).FirstOrDefault();
            if (emp == null)
            {
                // 404 not found
                return NotFound();
            }

            // 200 with data
            return Ok(emp);
        }


        [HttpDelete]
        // api/employeesapi/123
        [Route("{id}")]
        public IActionResult DeleteEmpByID(int id)
        {
            var empToDel = db.Employees.Find(id);
            if (empToDel == null)
            {
                return NotFound();
            }
            db.Employees.Remove(empToDel);
            db.SaveChanges();
            return Ok();
        }
        // POST api/employeesapi
        [HttpPost] // save
        public IActionResult SaveEmp([FromBody] Employee emp)
        {
            if (emp == null)
            {
                return BadRequest("emp data not provided");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest("invalid emp data");
            }

            db.Employees.Add(emp);
            db.SaveChanges();
            // return http status code -201 + location + data
            return Created($"api/employeeapi/{emp.EmployeeID}", emp);
        }
        [HttpPut] // edit
        // url Put api/employeesapi
        public IActionResult Edit([FromBody] Employee emp)
        {
            if (emp == null)
            {
                return BadRequest("emp data not provided");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest("invalid emp data");
            }
            db.Entry(emp).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return Ok();
        }

    }
}
